using Classes;
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
    public partial class frmQuestion : Form
    {
        Variable g;
        object res;
        List<RadioButton> rbList = new List<RadioButton>();

        public frmQuestion(Variable g, ExpertSystem res)
        {
            InitializeComponent();
            this.g = g;
            this.res = res;
            if (g.Question == null || g.Question.Trim() == "")
                textBox1.Text = g.Name + " = ?";
            else
            {
                textBox1.Text = g.Question;
            }
            int i = 0;
            foreach (string s in g.Domain.ListVal)
            {
                RadioButton rb = new RadioButton();
                rb.AutoSize = true;
                rb.Text = s;
                rbList.Add(rb);
                rb.Parent = groupBox1;
                rb.Left = 50;
                rb.Top = ++i * 25;
            }
            rbList[0].Checked = true;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rb in rbList)
            {
                if (rb.Checked)
                {
                    (res as ExpertSystem).res = rb.Text;
                    break;
                }
            }
        }


    }
}
