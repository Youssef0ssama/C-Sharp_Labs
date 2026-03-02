using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab_7
{
    public partial class Form1 : Form
    {
        int[] years = { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
        int[] revenues = { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 };

        Color lineChartColor = Color.Blue;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;

            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font subTitleFont = new Font("Arial", 14);
            Brush blackBrush = new SolidBrush(Color.Black);

            g.DrawString("ABC Company", titleFont, blackBrush, this.Width / 2 - 100, 20);
            g.DrawString("Annual Revenue", subTitleFont, blackBrush, this.Width / 2 - 80, 60);

            int tableX = this.Width - 250;
            int tableY = 120;
            g.DrawString("Year | Revenue", subTitleFont, blackBrush, tableX, tableY);
            for (int i = 0; i < years.Length; i++)
            {
                g.DrawString($"{years[i]} | {revenues[i]}", this.Font, blackBrush, tableX, tableY + 30 + (i * 20));
            }

            int chartX = 60;
            int chartBaseY = 450;
            Pen axesPen = new Pen(Color.Black, 2);

            g.DrawLine(axesPen, chartX, 120, chartX, chartBaseY);
            g.DrawLine(axesPen, chartX, chartBaseY, chartX + 450, chartBaseY);

            HatchBrush barBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.White);

            Pen linePen = new Pen(lineChartColor, 3);

            for (int i = 0; i < revenues.Length; i++)
            {
                int barWidth = 25;
                int spacing = 40;
                int barHeight = revenues[i];
                int currentX = chartX + (i * spacing) + 15;

                g.FillRectangle(barBrush, currentX, chartBaseY - barHeight, barWidth, barHeight);
                g.DrawRectangle(Pens.Black, currentX, chartBaseY - barHeight, barWidth, barHeight);

                if (i < revenues.Length - 1)
                {
                    int nextX = chartX + ((i + 1) * spacing) + 15;
                    g.DrawLine(linePen,
                        currentX + barWidth / 2, chartBaseY - revenues[i],
                        nextX + barWidth / 2, chartBaseY - revenues[i + 1]);
                }

                g.DrawString(years[i].ToString().Substring(2), this.Font, blackBrush, currentX, chartBaseY + 5);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R:
                        lineChartColor = Color.Red;
                        break;
                    case Keys.G:
                        lineChartColor = Color.Green;
                        break;
                    case Keys.B:
                        lineChartColor = Color.Blue;
                        break;
                }

                this.Invalidate();
            }
        }
    }
}