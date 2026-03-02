namespace linQ_labs
{
    partial class DisconnectedForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Employees = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            txtName = new TextBox();
            txtDept = new TextBox();
            btnDisplay = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)Employees).BeginInit();
            SuspendLayout();
            // 
            // Employees
            // 
            Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Employees.Location = new Point(12, 109);
            Employees.Name = "Employees";
            Employees.RowHeadersWidth = 51;
            Employees.Size = new Size(776, 329);
            Employees.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 1;
            label1.Text = "Employee ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(273, 9);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(520, 9);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 3;
            label3.Text = "Department:";
            // 
            // txtID
            // 
            txtID.Location = new Point(115, 6);
            txtID.Name = "txtID";
            txtID.Size = new Size(133, 27);
            txtID.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(331, 6);
            txtName.Name = "txtName";
            txtName.Size = new Size(183, 27);
            txtName.TabIndex = 5;
            // 
            // txtDept
            // 
            txtDept.Location = new Point(618, 6);
            txtDept.Name = "txtDept";
            txtDept.Size = new Size(170, 27);
            txtDept.TabIndex = 6;
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(15, 52);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 29);
            btnDisplay.TabIndex = 7;
            btnDisplay.Text = "Display All";
            btnDisplay.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(145, 52);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(124, 29);
            btnInsert.TabIndex = 8;
            btnInsert.Text = "Insert Employee";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(314, 52);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(144, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update Employee";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(498, 52);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(139, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete Employee";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(673, 52);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 29);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search by ID";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // DisconnectedForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnDisplay);
            Controls.Add(txtDept);
            Controls.Add(txtName);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Employees);
            Name = "DisconnectedForm";
            Text = "DisconnectedForm";
            ((System.ComponentModel.ISupportInitialize)Employees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Employees;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtDept;
        private Button btnDisplay;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
    }
}