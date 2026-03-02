namespace lab_9_10
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLeft = new TextBox();
            lstLeft = new ListBox();
            txtRight = new TextBox();
            lstRight = new ListBox();
            btnMoveRight = new Button();
            btnMoveLeft = new Button();
            btnCopy = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // txtLeft
            // 
            txtLeft.Location = new Point(6, 4);
            txtLeft.Name = "txtLeft";
            txtLeft.Size = new Size(388, 27);
            txtLeft.TabIndex = 0;
            // 
            // lstLeft
            // 
            lstLeft.FormattingEnabled = true;
            lstLeft.Location = new Point(6, 37);
            lstLeft.Name = "lstLeft";
            lstLeft.Size = new Size(388, 164);
            lstLeft.TabIndex = 1;
            // 
            // txtRight
            // 
            txtRight.Location = new Point(400, 4);
            txtRight.Name = "txtRight";
            txtRight.Size = new Size(397, 27);
            txtRight.TabIndex = 2;
            // 
            // lstRight
            // 
            lstRight.FormattingEnabled = true;
            lstRight.Location = new Point(400, 37);
            lstRight.Name = "lstRight";
            lstRight.Size = new Size(397, 164);
            lstRight.TabIndex = 3;
            // 
            // btnMoveRight
            // 
            btnMoveRight.Location = new Point(179, 219);
            btnMoveRight.Name = "btnMoveRight";
            btnMoveRight.Size = new Size(94, 29);
            btnMoveRight.TabIndex = 4;
            btnMoveRight.Text = ">";
            btnMoveRight.UseVisualStyleBackColor = true;
            // 
            // btnMoveLeft
            // 
            btnMoveLeft.Location = new Point(6, 219);
            btnMoveLeft.Name = "btnMoveLeft";
            btnMoveLeft.Size = new Size(94, 29);
            btnMoveLeft.TabIndex = 5;
            btnMoveLeft.Text = "<";
            btnMoveLeft.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(348, 219);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(94, 29);
            btnCopy.TabIndex = 6;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(530, 219);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(703, 219);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnCopy);
            Controls.Add(btnMoveLeft);
            Controls.Add(btnMoveRight);
            Controls.Add(lstRight);
            Controls.Add(txtRight);
            Controls.Add(lstLeft);
            Controls.Add(txtLeft);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLeft;
        private ListBox lstLeft;
        private TextBox txtRight;
        private ListBox lstRight;
        private Button btnMoveRight;
        private Button btnMoveLeft;
        private Button btnCopy;
        private Button btnDelete;
        private Button btnBack;
    }
}
