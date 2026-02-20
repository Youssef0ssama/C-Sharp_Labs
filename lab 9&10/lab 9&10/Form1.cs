using System.Diagnostics;

namespace lab_9_10
{
    public partial class Form1 : Form
    {
        string pathLeft = @"D:\MyFolder";
        string pathRight = @"D:\MyFolder";
        ListBox lastVisited;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            lstLeft.DoubleClick += LstLeft_DoubleClick;
            lstRight.DoubleClick += LstRight_DoubleClick;
            lstLeft.Enter += (s, e) => lastVisited = lstLeft;
            lstRight.Enter += (s, e) => lastVisited = lstRight;

            btnMoveRight.Click += BtnMoveRight_Click;
            btnMoveLeft.Click += BtnMoveLeft_Click;
            btnCopy.Click += BtnCopy_Click;
            btnDelete.Click += BtnDelete_Click;
            btnBack.Click += BtnBack_Click;

            LoadDirectory(@"D:\MyFolder", lstLeft, txtLeft);
            LoadDirectory(@"D:\MyFolder", lstRight, txtRight);
            lastVisited = lstLeft;
        }

        private void LoadDirectory(string path, ListBox lst, TextBox txt)
        {
            try
            {
                lst.Items.Clear();
                if (string.IsNullOrEmpty(path))
                {
                    txt.Text = "My Computer";
                    foreach (DriveInfo drive in DriveInfo.GetDrives())
                    {
                        if (drive.IsReady) lst.Items.Add(drive.Name);
                    }
                }
                else
                {
                    txt.Text = path;
                    lst.Items.Add(".");
                    lst.Items.Add("..");
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    foreach (DirectoryInfo d in dirInfo.GetDirectories()) lst.Items.Add(d.Name);
                    foreach (FileInfo f in dirInfo.GetFiles()) lst.Items.Add(f.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LstLeft_DoubleClick(object sender, EventArgs e) => HandleDoubleClick(lstLeft, txtLeft, ref pathLeft);
        private void LstRight_DoubleClick(object sender, EventArgs e) => HandleDoubleClick(lstRight, txtRight, ref pathRight);

        private void HandleDoubleClick(ListBox lst, TextBox txt, ref string currentPath)
        {
            if (lst.SelectedItem == null) return;
            string selected = lst.SelectedItem.ToString();

            if (selected == ".") GoUpOneLevel(lst, txt, ref currentPath);
            else if (selected == "..")
            {
                currentPath = "";
                LoadDirectory(currentPath, lst, txt);
            }
            else
            {
                string targetPath = string.IsNullOrEmpty(currentPath) ? selected : Path.Combine(currentPath, selected);
                if (Directory.Exists(targetPath) || string.IsNullOrEmpty(currentPath))
                {
                    currentPath = targetPath;
                    LoadDirectory(currentPath, lst, txt);
                }
                else if (File.Exists(targetPath))
                {
                    try { Process.Start(new ProcessStartInfo(targetPath) { UseShellExecute = true }); }
                    catch { MessageBox.Show("Cannot open file."); }
                }
            }
        }

        private void BtnMoveRight_Click(object sender, EventArgs e)
        {
            MoveItem(lstLeft, pathLeft, pathRight);
            LoadDirectory(pathLeft, lstLeft, txtLeft);
            LoadDirectory(pathRight, lstRight, txtRight);
        }

        private void BtnMoveLeft_Click(object sender, EventArgs e)
        {
            MoveItem(lstRight, pathRight, pathLeft);
            LoadDirectory(pathLeft, lstLeft, txtLeft);
            LoadDirectory(pathRight, lstRight, txtRight);
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (lastVisited == null || lastVisited.SelectedItem == null) return;
            string sourcePath = lastVisited == lstLeft ? pathLeft : pathRight;
            string destPath = lastVisited == lstLeft ? pathRight : pathLeft;
            CopyItem(lastVisited, sourcePath, destPath);
            LoadDirectory(pathLeft, lstLeft, txtLeft);
            LoadDirectory(pathRight, lstRight, txtRight);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lastVisited == null || lastVisited.SelectedItem == null) return;
            string selected = lastVisited.SelectedItem.ToString();
            if (selected == "." || selected == "..") return;
            string fullPath = Path.Combine(lastVisited == lstLeft ? pathLeft : pathRight, selected);
            try
            {
                if (File.Exists(fullPath)) File.Delete(fullPath);
                else if (Directory.Exists(fullPath)) Directory.Delete(fullPath, true);
                LoadDirectory(lastVisited == lstLeft ? pathLeft : pathRight, lastVisited, lastVisited == lstLeft ? txtLeft : txtRight);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (lastVisited == lstLeft) GoUpOneLevel(lstLeft, txtLeft, ref pathLeft);
            else GoUpOneLevel(lstRight, txtRight, ref pathRight);
        }

        private void GoUpOneLevel(ListBox lst, TextBox txt, ref string currentPath)
        {
            if (string.IsNullOrEmpty(currentPath)) return;
            DirectoryInfo dir = new DirectoryInfo(currentPath);
            currentPath = dir.Parent?.FullName ?? "";
            LoadDirectory(currentPath, lst, txt);
        }

        private void MoveItem(ListBox sourceList, string sourceDir, string destDir)
        {
            if (sourceList.SelectedItem == null || string.IsNullOrEmpty(destDir)) return;
            string selected = sourceList.SelectedItem.ToString();
            if (selected == "." || selected == "..") return;
            try
            {
                string s = Path.Combine(sourceDir, selected);
                string d = Path.Combine(destDir, selected);
                if (File.Exists(s)) File.Move(s, d);
                else Directory.Move(s, d);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CopyItem(ListBox sourceList, string sourceDir, string destDir)
        {
            if (sourceList.SelectedItem == null || string.IsNullOrEmpty(destDir)) return;
            string selected = sourceList.SelectedItem.ToString();
            if (selected == "." || selected == "..") return;
            try
            {
                string s = Path.Combine(sourceDir, selected);
                string d = Path.Combine(destDir, selected);
                if (File.Exists(s)) File.Copy(s, d, true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
