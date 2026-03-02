namespace linQ_labs
{
    partial class ConnectedForm
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
            label1 = new Label();
            txtID = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtDept = new TextBox();
            btnDisplay = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            Employees = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Employees).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 2;
            label1.Text = "Employee ID:";
            // 
            // txtID
            // 
            txtID.Location = new Point(115, 6);
            txtID.Name = "txtID";
            txtID.Size = new Size(133, 27);
            txtID.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(267, 9);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 6;
            label2.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(325, 6);
            txtName.Name = "txtName";
            txtName.Size = new Size(183, 27);
            txtName.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(514, 9);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 8;
            label3.Text = "Department:";
            // 
            // txtDept
            // 
            txtDept.Location = new Point(618, 6);
            txtDept.Name = "txtDept";
            txtDept.Size = new Size(170, 27);
            txtDept.TabIndex = 9;
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(12, 51);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 29);
            btnDisplay.TabIndex = 10;
            btnDisplay.Text = "Display All";
            btnDisplay.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(150, 51);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(124, 29);
            btnInsert.TabIndex = 11;
            btnInsert.Text = "Insert Employee";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(310, 51);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(144, 29);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update Employee";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(486, 51);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(139, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete Employee";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(673, 51);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 29);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search by ID";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // Employees
            // 
            Employees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Employees.Location = new Point(12, 109);
            Employees.Name = "Employees";
            Employees.RowHeadersWidth = 51;
            Employees.Size = new Size(776, 329);
            Employees.TabIndex = 15;
            // 
            // ConnectedForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Employees);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnDisplay);
            Controls.Add(txtDept);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtID);
            Controls.Add(label1);
            Name = "ConnectedForm";
            Text = "ConnectedForm";
            ((System.ComponentModel.ISupportInitialize)Employees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtID;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtDept;
        private Button btnDisplay;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private DataGridView Employees;
    }
}