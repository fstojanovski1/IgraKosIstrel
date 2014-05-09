using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IgraKosIstrel
{
    public partial class Form2 : Form
    {
        public int selection;
        public Form2()
        {
            InitializeComponent();
            cbSelection.SelectedIndex = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            selection = cbSelection.SelectedIndex;
            this.Close();
        }


    }
}
