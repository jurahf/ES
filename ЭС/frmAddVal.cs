using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ЭС
{
    public partial class frmAddVal : Form
    {
        frmDomains fff;

        public frmAddVal(frmDomains fff)
        {
            InitializeComponent();
            this.fff = fff;
            textBox1.Focus();
        }

        public frmAddVal(frmDomains fff, string oldVal)
        {
            InitializeComponent();
            this.fff = fff;
            textBox1.Text = oldVal;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            fff.newVal = textBox1.Text;
        }

        private void frmAddVal_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

    }
}
