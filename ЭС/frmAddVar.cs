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
    public partial class frmAddVar : Form
    {
        frmVariables f;

        public frmAddVar(frmVariables f, bool AllowQuaried)
        {
            InitializeComponent();
            this.f = f;
            comboBox1.SelectedIndex = 1;
            foreach (string s in f.es.Domains.Keys)
                comboBox2.Items.Add(s);
            if (!AllowQuaried) // нет запрашиваемых
            {
                comboBox1.Items.RemoveAt(1);
                comboBox1.SelectedIndex = 0;
                textBox3.Enabled = false;
            }
        }


        public frmAddVar(frmVariables f, bool AllowQuaried, Variable v)
            : this(f, AllowQuaried)
        {
            textBox1.Text = v.Name;
            switch (v.MyType)
            {
                case VarType.Deducted:
                    comboBox1.SelectedIndex = 0;
                    break;
                case VarType.Queried:
                    comboBox1.SelectedIndex = 1;
                    break;
                case VarType.DeductionQueried:
                    comboBox1.SelectedIndex = 2;
                    break;
            }
            textBox2.Text = v.Reasoning;
            comboBox2.SelectedItem = v.Domain.Name;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            f.newVar = textBox1.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0: f.type = VarType.Deducted;
                    break;
                case 1: f.type = VarType.Queried;
                    break;
                case 2: f.type = VarType.DeductionQueried;
                    break;
            }
            f.newDom = comboBox2.Text;
            f.newReasoning = textBox2.Text;
            f.newQuestion = textBox3.Text;
        }


        /// <summary>
        /// Кнопка добавить домен
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            frmDomains fdom = new frmDomains(f.es);
            if (fdom.AddDomain() == DialogResult.OK)
            {
                fdom.SaveCollections();
                if (fdom.newDom != null && fdom.newDom != "")
                {
                    comboBox2.Items.Add(fdom.newDom);
                    comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
                }
            }
        }

        private void frmAddVar_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }


    }
}
