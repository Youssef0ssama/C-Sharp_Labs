using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public delegate void ClickHandler(object sender, string buttonname);
    internal class Button
    {
        public event ClickHandler click;
        public void performClick()
        {
            if (click != null) {
                click(this, "submitButton");
            }
        }

    }
}
