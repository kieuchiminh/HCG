using System;
using System.Collections.Generic;
using System.Text;

namespace BTL_HCG_Nhom8
{
    class Road
    {
        private Node node;
        private Rule rule;

        internal Node Node
        {
            get { return node; }
            set { node = value; }
        }


        internal Rule Rule
        {
            get { return rule; }
            set { rule = value; }
        }
    }
}
