using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public delegate void Temphandler(string msg,double temp);
    internal class TempSensor
    {
        public event Temphandler tempHigh;
        public void setTemp(double temp) {
            if (temp > 30)
            {
                if (tempHigh != null)
                {
                    tempHigh("THE TEMP IS TOO HIGH",temp);
                }
            }
       }
    }
}
