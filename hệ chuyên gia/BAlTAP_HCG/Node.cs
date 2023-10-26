using System;
using System.Collections.Generic;
using System.Text;

namespace BTL_HCG_Nhom8
{
    class Node
    {
        private string name;
        private string text;
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override string ToString()
        {
            return name + " " + text;
        }
    }
}
