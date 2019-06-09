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
    public partial class frmAddReason : Form
    {
        private frmRules f;
        Fact fact;

        public frmAddReason(frmRules f, bool allrules)
        {
            InitializeComponent();
            this.f = f;
            foreach (string s in f.es.Vars.Keys)
                    if (allrules || f.es.Vars[s].MyType != VarType.Queried) 
                        comboBox2.Items.Add(s);
        }


        public frmAddReason(frmRules f, Fact fact)
        {
            InitializeComponent();
            this.f = f;
            foreach (string s in f.es.Vars.Keys)
                //if (f.es.Vars[s].MyType != VarType.Queried)
                    comboBox2.Items.Add(s);
            this.fact = fact;
            comboBox2.Text = fact.V.Name;
            comboBox3.Text = fact.Weight;
        }


        /// <summary>
        /// Кнопка "Добавить переменную"
        /// </summary>
        private void btnAddVar_Click(object sender, EventArgs e)
        {
            frmVariables fvar = new frmVariables(f.es);
            if (fvar.AddVar(false) == DialogResult.OK)
            {
                fvar.SaveCollections();
                comboBox2.Items.Add(fvar.newVar);
                comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
            }
        }


        /// <summary>
        /// Кнопка "Добавить значение"
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
                MessageBox.Show("Сначала нужно выбрать домен");
            else
            {
                frmDomains fdom = new frmDomains(f.es);
                if (fdom.AddValue(f.es.Vars[comboBox2.Text].Domain) == DialogResult.OK)
                {
                    fdom.SaveCollections();
                    comboBox3.Items.Add(fdom.newVal);
                    comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// Кнопка "Готово"
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                f.newVar = comboBox2.SelectedItem.ToString();
                f.newWeight = comboBox3.SelectedItem.ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (comboBox2.SelectedIndex >= 0 && comboBox2.Text != "")
                for (int i = 0; i < f.es.Vars[comboBox2.Text].Domain.Count; i++)
                    comboBox3.Items.Add(f.es.Vars[comboBox2.Text].Domain.GetVal(i));
        }

        private void frmAddReason_Load(object sender, EventArgs e)
        {
            comboBox2.Select();
        }



    }
}
