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
    public partial class frmGoal : Form
    {
        ExpertSystem es;
        frmMain mother;

        public frmGoal(ExpertSystem es, frmMain mother)
        {
            InitializeComponent();
            foreach (string s in es.Vars.Keys)
                if (es.Vars[s].MyType != VarType.Queried)
                    comboBox1.Items.Add(s);
            this.es = es;
            this.mother = mother;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                es.Goal = null;
            else
                es.Goal = es.Vars[comboBox1.SelectedItem.ToString()];
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                es.Goal = null;
                MessageBox.Show("Надо выбрать цель");
            }
            else
            {
                es.Goal = es.Vars[comboBox1.SelectedItem.ToString()];
                //MessageBox.Show(es.GoConsult().ToString());
                mother.StartConsult();
                this.Close();
            }
        }

        private void frmGoal_Load(object sender, EventArgs e)
        {
            comboBox1.Select();
        }




    }
}
