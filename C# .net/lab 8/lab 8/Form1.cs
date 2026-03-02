namespace lab_8
{
    public partial class Form1 : Form
    {
        string companyName = "ABC Company";
        string companyFontName = "Arial";
        float companyFontSize = 20f;
        Color companyColor = Color.Black;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Font myFont = new Font(companyFontName, companyFontSize, FontStyle.Bold);
            Brush myBrush = new SolidBrush(companyColor);

            g.DrawString(companyName, myFont, myBrush, 50, 50);
        }

        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormatDialog dialog = new FormatDialog(companyFontName, companyFontSize, companyColor, companyName);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                companyFontName = dialog.SelectedFont;
                companyFontSize = dialog.SelectedSize;
                companyColor = dialog.SelectedColor;
                companyName = dialog.SelectedText;

                this.Invalidate();
            }
        }
    }
}
