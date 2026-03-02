using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class StrugCollection
    {
        string[] items;
        public StrugCollection(int size)
        {
            items = new string[size];
        }
        public string this[int index]
        {
            set
            {
                items[index] = value;
            }
            get
            {
                return items[index];
            }
        }
        public string this[string key]
        {
            set
            {
                if (key == "first")
                {
                    items[0] = value;
                }
                else if (key == "last")
                {
                    items[items.Length - 1] = value;
                }
            }
            get
            {
                if (key == "first")
                {
                    return items[0];
                }
                else if (key == "last")
                {
                    return items[items.Length - 1];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}