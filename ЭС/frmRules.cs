using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;

namespace ЭС
{
    public partial class frmRules : Form
    {
        public ExpertSystem es { get; set; }
        private OrderedDictionary<string, Rule> rules = new OrderedDictionary<string, Rule>();
        public string newRule = "";
        public string newVar = "";
        public string newWeight = "";
        public string newReasoning = "";


        public frmRules(ExpertSystem es)
        {
            InitializeComponent();
            this.es = es;
            // копия коллекции и вывод
            foreach (string s in es.Rules.Keys)
            {
                rules.Add(s, es.Rules[s]);
                lstRules.Items.Add(s + ": " + es.Rules[s].ToString());                
            }
            lstRules.SelectedIndex = -1;
        }


        /// <summary>
        /// Выбор правила
        /// </summary>
        private void lstRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool off;
            off = lstRules.SelectedIndex >= 0;
            textBox1.Clear();

            lstResult.Items.Clear();
            lstReasons.Items.Clear();
            lstReasons.Enabled = off;
            lstResult.Enabled = off;
            btnAddReason.Enabled = off;
            btnEditReason.Enabled = off;
            btnDeleteReason.Enabled = off;
            btnDeleteResult.Enabled = off;
            btnModifyResult.Enabled = off;
            btnDeleteRule.Enabled = off;
            btnEditRule.Enabled = off;
            if (off) // выводим посылки и вывод правила
            {
                for (int i = 0; i < rules[getSelectedRuleName()].ReasonCount(); i++)
                    lstReasons.Items.Add(rules[getSelectedRuleName()].GetReason(i));
                if (rules[getSelectedRuleName()].Result != null)
                    lstResult.Items.Add(rules[getSelectedRuleName()].Result);
                textBox1.Text = rules[getSelectedRuleName()].Reasoning;
            }

        }


        /// <summary>
        /// Кнопка "Добавить правило"
        /// </summary>
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            frmAddRule f = new frmAddRule(this);
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (rules.ContainsKey(newRule))
                {
                    MessageBox.Show("Правило с таким именем уже существует!");
                    return;
                }
                if (newRule == "")
                {
                    MessageBox.Show("Правило не может быть без имени!");
                    return;
                }
                // добавляем правило
                Rule r = new Rule(newRule);
                r.Reasoning = newReasoning;
                rules.Add(newRule, r);
                lstRules.Items.Add(newRule + ": " + r.ToString());
                lstRules.SelectedItem = newRule + ": " + r.ToString();
            }
        }


        /// <summary>
        /// Кнопка "Готово"
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // сохраняем коллекцию
            es.Rules.Clear();
            foreach (string s in rules.Keys)
                es.Rules.Add(s, rules[s]);
        }


        /// <summary>
        /// Кнопка "Добавить посылку"
        /// </summary>
        private void btnAddReason_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddReason f = new frmAddReason(this, true);
                if (f.ShowDialog() == DialogResult.OK && newVar != "" && newWeight != "")
                {
                    Fact newFact = new Fact(es.Vars[newVar], newWeight);
                    rules[getSelectedRuleName()].AddReason(newFact, rules[getSelectedRuleName()].Reasons.Count);
                    lstReasons.Items.Add(newFact);
                    // обновление имени правила
                    RefreshRule();
                }
            }
            catch (RuleException re)
            {
                MessageBox.Show(re.Message);
                lstRules.SelectedIndex = -1;
            }
        }


        private void RefreshRule()
        {
            int si = lstRules.SelectedIndex;
            Rule r = rules[getSelectedRuleName()];
            lstRules.Items.RemoveAt(si);
            lstRules.Items.Insert(si, r.Name + ": " + r.ToString());
            lstRules.SelectedIndex = si;
        }


        private string getSelectedRuleName()
        {
            return lstRules.SelectedItem.ToString().Substring(0, lstRules.SelectedItem.ToString().IndexOf(':'));
        }


        /// <summary>
        /// Кнопка "Установить вывод"
        /// </summary>
        private void btnModifyResult_Click(object sender, EventArgs e)
        {
            frmAddReason f = new frmAddReason(this, false);
            if (f.ShowDialog() == DialogResult.OK && newVar != "" && newWeight != "")
            {
                Fact newFact = new Fact(es.Vars[newVar], newWeight);
                rules[getSelectedRuleName()].Result = newFact;
                lstResult.Items.Clear();
                lstResult.Items.Add(newFact);
                RefreshRule();
            }
        }


        /// <summary>
        /// Кнопка "Удалить вывод"
        /// </summary>
        private void btnDeleteResult_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтверждение", "Действительно удалить вывод текущего правила?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rules[getSelectedRuleName()].Result = null;
                RefreshRule();
            }
        }

        /// <summary>
        /// Кнопка "Удалить посылку"
        /// </summary>
        private void btnDeleteReason_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstReasons.SelectedIndex < 0)
                {
                    MessageBox.Show("Сначала необходимо выбрать посылку");
                    return;
                }
                rules[getSelectedRuleName()].Remove(lstReasons.SelectedItem as Fact);
                lstReasons.Items.Remove(lstReasons.SelectedItem);
            }
            catch (RuleException re)
            {
                MessageBox.Show(re.Message);
            }
        }


        /// <summary>
        /// Кнопка "Изменить посылку"
        /// </summary>
        private void btnEditReason_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstReasons.SelectedIndex < 0)
                {
                    MessageBox.Show("Сначала необходимо выбрать посылку");
                    return;
                }
                Fact newFact = lstReasons.SelectedItem as Fact;
                frmAddReason fr = new frmAddReason(this, newFact);
                if (fr.ShowDialog() == DialogResult.OK)
                {
                    newFact.V = es.Vars[newVar];
                    newFact.Weight = newWeight;                    
                    lstRules_SelectedIndexChanged(sender, e);
                    RefreshRule();
                }
            }
            catch (RuleException re)
            {
                MessageBox.Show(re.Message);
            }
        }


        /// <summary>
        /// Кнопка "Удалить правило"
        /// </summary>
        private void btnDeleteRule_Click(object sender, EventArgs e)
        {
            if (lstRules.SelectedIndex < 0)
            {
                MessageBox.Show("Сначала необходимо выбрать правило");
                return;
            }

            if (MessageBox.Show("Действительно удалить текущее правило?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rules.Remove(getSelectedRuleName());
                lstRules.Items.Remove(lstRules.SelectedItem);
            }
        }



        /// <summary>
        /// Кнопка "Изменить правило"
        /// </summary>
        private void btnEditRule_Click(object sender, EventArgs e)
        {
            if (lstRules.SelectedIndex < 0)
            {
                MessageBox.Show("Сначала необходимо выбрать правило");
                return;
            }
            string old = getSelectedRuleName();
            int pos = lstRules.SelectedIndex;
            frmAddRule fr = new frmAddRule(this, old, rules[old].Reasoning);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Rule r = rules[old];
                r.Name = old;
                r.Reasoning = newReasoning;
                rules.Remove(old);
                rules.Add(newRule, r);
                lstRules.Items[pos] = newRule + ": " + r.ToString();//newRule;
            }
        }



        /// <summary>
        /// Перетаскивание правил
        /// </summary>
        private void lstRules_AfterDrop(object sender, AfterDropEventArgs e)
        {
            string s = (e.Data as string);
            Rule pr = rules[s.Substring(0, s.IndexOf(':'))];
            rules.RemoveAt(e.SIndex);
            rules.Insert(e.FIndex, pr.Name, pr);
        }


        /// <summary>
        /// Перетаскивание посылок
        /// </summary>
        private void lstReasons_AfterDrop(object sender, AfterDropEventArgs e)
        { // e.Data - Fact !
            rules[getSelectedRuleName()].Reasons.RemoveAt(e.SIndex);
            rules[getSelectedRuleName()].Reasons.Insert(e.FIndex, e.Data as Fact);
        }



    }
}
