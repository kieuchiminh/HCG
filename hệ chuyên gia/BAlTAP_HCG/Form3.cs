using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BTL_HCG_Nhom8
{
    public partial class Form3 : Form
    {
        private string reason;
        public Form3(string reason)
        {
            InitializeComponent();
            this.reason = reason;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txttuvan.Text = reason;
            txttuvan.Select(0, 0);
        }

        private void txttuvan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}