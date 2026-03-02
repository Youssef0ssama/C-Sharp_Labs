using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab_8
{
    public partial class FormatDialog : Form
    {
        public string SelectedFont;
        public float SelectedSize;
        public Color SelectedColor;
        public string SelectedText;

        public FormatDialog(string currentFont, float currentSize, Color currentColor, string currentText)
        {
            InitializeComponent();

            SelectedFont = currentFont;
            SelectedSize = currentSize;
            SelectedColor = currentColor;
            SelectedText = currentText;

            if (currentFont == "Times New Roman") rbTimes.Checked = true;
            else if (currentFont == "Courier") rbCourier.Checked = true;
            else rbArial.Checked = true;

            if (currentSize == 16f) rb16.Checked = true;
            else if (currentSize == 24f) rb24.Checked = true;
            else rb20.Checked = true;

            txtOld.Text = currentText;
            txtNew.Text = currentText;

            btnColor.Click += btnColor_Click;
            btnOK.Click += btnOK_Click;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = SelectedColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectedColor = colorDialog1.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbTimes.Checked) SelectedFont = "Times New Roman";
            else if (rbCourier.Checked) SelectedFont = "Courier";
            else SelectedFont = "Arial";

            if (rb16.Checked) SelectedSize = 16f;
            else if (rb24.Checked) SelectedSize = 24f;
            else SelectedSize = 20f;

            if (!string.IsNullOrWhiteSpace(txtNew.Text))
            {
                SelectedText = txtNew.Text;
            }
        }
    }
}
