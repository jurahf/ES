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
    public partial class frmAddRule : Form
    {
        private frmRules f;

        public frmAddRule(frmRules f)
        {
            InitializeComponent();
            this.f = f;
        }


        public frmAddRule(frmRules f, string rName, string reasoning)
            : this(f)
        {
            textBox1.Text = rName;
            textBox2.Text = reasoning;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            f.newRule = textBox1.Text;
            f.newReasoning = textBox2.Text;
        }

        private void frmAddRule_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }
    }
}
