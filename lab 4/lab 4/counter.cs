using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class counter
    {
        static int count;
        public int id;
        static counter()
        {
            count = 0;
        }
        public counter()
        {
            count++;
            id = count;
        }

    }
}