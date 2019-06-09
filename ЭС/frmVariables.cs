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
    public partial class frmVariables : Form
    {
        private OrderedDictionary<string, Variable> vars = new OrderedDictionary<string, Variable>();
        public ExpertSystem es { get; set; }
        public string newVar = ""; // имя добавляемой переменной
        public string newDom = "";
        public string newReasoning = "";
        public string newQuestion = "";
        public VarType type = VarType.Queried;


        public frmVariables(ExpertSystem es)
        {
            InitializeComponent();
            this.es = es;

            // копируем коллекции
            foreach (string s in es.Vars.Keys)
                vars.Add(s, es.Vars[s]);

            listBox1.Tag = -1;
            // на форму
            foreach (string s in vars.Keys)
                listBox1.Items.Add(s);
            foreach (string s in es.Domains.Keys)
                comboBox1.Items.Add(s);
        }


        /// <summary>
        /// Выбор домена - вывод возможных значений
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (comboBox1.SelectedIndex >= 0 && es.Domains.ContainsKey(comboBox1.SelectedItem.ToString()))
            {
                string newDom = comboBox1.SelectedItem.ToString();

                for (int i = 0; i < es.Domains[newDom].Count; i++)
                    listBox2.Items.Add(es.Domains[newDom].GetVal(i));

                //if (es.Domains.ContainsKey(newDom))
                //    vars[listBox1.SelectedItem.ToString()].Domain = es.Domains[newDom];
            }
        }


        /// <summary>
        /// Выбор переменной в списке - отображаем ее параметры
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                groupBox2.Enabled = false;
                return;
            }

            if ((int)listBox1.Tag != -1)
            {
                button1_Click(sender, e); // сохраняем предыдущую переменную
            }

            groupBox2.Enabled = true;
            string vname = listBox1.SelectedItem.ToString();
            textBox1.Clear();
            textBox2.Clear();
            
            #region домен

            if (vars[vname].Domain == null)
                comboBox1.SelectedIndex = -1;
            else
                for (int i = 0; i < comboBox1.Items.Count; i++)
                    if (vars[vname].Domain.Name == comboBox1.Items[i].ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }

            #endregion

            #region тип переменной

            switch (vars[vname].MyType)
            {
                case VarType.Deducted:
                    radioButton1.Checked = true;
                    textBox1.Enabled = false;
                    break;
                case VarType.Queried:
                    radioButton2.Checked = true;
                    textBox1.Enabled = true;
                    textBox1.Text = vars[vname].Question;
                    break;
                case VarType.DeductionQueried:
                    radioButton3.Checked = true;
                    textBox1.Enabled = true;
                    textBox1.Text = vars[vname].Question;
                    break;
            }

            #endregion

            listBox1.Tag = listBox1.SelectedIndex; // запоминаем индекс

            textBox2.Text = vars[vname].Reasoning;
        }


        /// <summary>
        /// Кнопка "Добавить переменную"
        /// </summary>
        private void btnAddVar_Click(object sender, EventArgs e)
        {
            AddVar(true);
        }

        /// <summary>
        /// Добавление переменной
        /// </summary>
        public DialogResult AddVar(bool AllowQueried)
        {
            frmAddVar f = new frmAddVar(this, AllowQueried);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Variable nv = null;
                if (newVar == "")
                {
                    MessageBox.Show("Переменная не может не иметь имени!");
                    return DialogResult.Cancel;
                }
                if (vars.ContainsKey(newVar))
                {
                    MessageBox.Show("Переменная с таким именем уже существует!");
                    return DialogResult.Cancel;
                }

                // присваиваем тип
                nv = new Variable(newVar);
                nv.MyType = type;
                nv.Question = newQuestion;
                if (es.Domains.ContainsKey(newDom))
                    nv.Domain = es.Domains[newDom];
                if (!comboBox1.Items.Contains(newDom))
                {
                    comboBox1.Items.Add(newDom);
                    comboBox1.SelectedItem = newDom;
                }

                nv.Reasoning = newReasoning;
                // добавляем в коллекцию
                vars.Add(newVar, nv);
                listBox1.Items.Add(newVar);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            return dr;
        }



        /// <summary>
        /// Кнопка "Сохранить переменную"
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            string vname = listBox1.Items[(int)listBox1.Tag] as string; // прошлое сохраняем
            Variable nv = vars[vname];

            // домен
            if (comboBox1.SelectedIndex >= 0)
                nv.Domain = es.Domains[comboBox1.SelectedItem.ToString()];

            // тип
            if (radioButton2.Checked)
                type = VarType.Queried;
            else if (radioButton3.Checked)
                type = VarType.DeductionQueried;
            else
                type = VarType.Deducted;
            switch (type)
            {
                case VarType.Deducted:  // у выводимой нет вопроса
                    nv.Question = "";
                    break;
                case VarType.Queried:   // стала запрашиваемая
                    // если была выводимая - надо убрать ее из правил
                    nv.Question = textBox1.Text;
                    foreach (Rule r in es.Rules.Vals)
                    {
                        if (r.Result != null && r.Result.V.CompareTo(nv) == 0)
                        { // убираем из выводов
                            r.Result = null;
                        }
                    }
                    break;
                case VarType.DeductionQueried:
                    break;
            }
            nv.MyType = type;
        }


        /// <summary>
        /// Кнопка "Добавить домен"
        /// </summary>
        private void btnAddDomain_Click(object sender, EventArgs e)
        {
            frmDomains f = new frmDomains(es);
            if (f.AddDomain() == DialogResult.OK)
            {
                f.SaveCollections();
                comboBox1.Items.Add(f.newDom);
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            }
        }



        /// <summary>
        /// Кнопка "Добавить значение в домен"
        /// </summary>
        private void btnAddVal_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                MessageBox.Show("Сначала нужно выбрать домен");
            else
            {
                frmDomains f = new frmDomains(es);
                if (f.AddValue(comboBox1.SelectedIndex) == DialogResult.OK)
                    listBox2.Items.Add(f.newVal);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !radioButton1.Checked;

            if (radioButton1.Checked)
                type = VarType.Deducted;
            else if (radioButton2.Checked)
                type = VarType.Queried;
            else type = VarType.DeductionQueried;

            //if (listBox1.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Сначала необходимо выделить переменную");
            //    return;
            //}

            //Variable nv = vars[listBox1.SelectedItem.ToString()];
            //nv.MyType = type;
            //// присваиваем тип
            //switch (type)
            //{
            //    case VarType.Deducted: // у выводимой нет вопроса
            //        nv.Question = "";
            //        break;
            //    case VarType.Queried:
            //    case VarType.DeductionQueried: // стала запрашиваемая
            //        // если была выводимая - надо убрать ее из правил
            //        foreach (Rule r in es.Rules.Vals)
            //        {
            //            if (r.Result.V.CompareTo(nv) == 0)
            //            { // убираем из выводов
            //                r.Result = null;
            //            }
            //        }
            //        break;
            //} 
        }



        private void ChangeVar(string old)
        {
            Variable nv = vars[old];

            // домен
            if (es.Domains.ContainsKey(newDom))
                nv.Domain = es.Domains[newDom];
            if (!comboBox1.Items.Contains(newDom))
            {
                comboBox1.Items.Add(newDom);
                comboBox1.SelectedItem = newDom;
            }
            nv.Reasoning = newReasoning; // объяснение
            nv.Question = newQuestion;
            nv.MyType = type; // тип

            // присваиваем тип
            switch (type)
            {
                case VarType.Deducted:  // у выводимой нет вопроса
                    nv.Question = "";
                    break;
                case VarType.Queried:   // стала запрашиваемая
                    // если была выводимая - надо убрать ее из правил
                    foreach (Rule r in es.Rules.Vals)
                    {
                        if (r.Result.V.CompareTo(nv) == 0)
                        { // убираем из выводов
                            r.Result = null;
                        }
                    }
                    break;
                case VarType.DeductionQueried: 
                    break;
            }

            int ind = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(ind);
            listBox1.Items.Insert(ind, newVar);
            listBox1.SelectedIndex = ind;
        }


        /// <summary>
        /// Кнопка "Готово" - принимаем изменения
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            SaveCollections();
        }

        public void SaveCollections()
        {
            es.Vars.Clear();
            foreach (string s in vars.Keys)
                es.Vars.Add(s, vars[s]);
        }


        /// <summary>
        /// Кнопка "Изменить переменную"
        /// </summary>
        private void btnEditVar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Сначала необходимо выделить переменную");
                return;
            }

            string old = vars[listBox1.SelectedItem.ToString()].Name;
            frmAddVar f = new frmAddVar(this, true, vars[listBox1.SelectedItem.ToString()]);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ChangeVar(old);
            }
        }



        private void btnDelVar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Сначала необходимо выделить переменную");
                return;
            }
            if (MessageBox.Show("Действительно удалиь переменную? Будут отменены выводы во всех правилах, ее выводящих.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // удаление правила
            Variable dv = vars[listBox1.SelectedItem.ToString()];
            for (int i = 0; i < es.Rules.Vals.Count; i++)
            {
                Rule r = es.Rules.Vals[i];
                if (r.Result.V.CompareTo(dv) == 0)
                {
                    r.Result = null;
                }
                for (int j = 0; j < r.Reasons.Count; j++)
                    if (r.Reasons[j].V.CompareTo(dv) == 0)
                    {
                        r.Reasons.RemoveAt(j);
                        if (r.Reasons.Count == 0)
                            es.Rules.Remove(r.Name);
                    }
            }

            // удаление самой переменной
            vars.Remove(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem);
        }


        /// <summary>
        /// Перетаскивание переменных
        /// </summary>
        private void listBox1_AfterDrop(object sender, AfterDropEventArgs e)
        {
            Variable pr = vars[e.Data as string];
            vars.RemoveAt(e.SIndex);
            vars.Insert(e.FIndex, e.Data as string, pr);
        }


        /// <summary>
        /// Перетаскивание значений в домене
        /// </summary>
        private void listBox2_AfterDrop(object sender, AfterDropEventArgs e)
        {
            es.Domains[comboBox1.SelectedItem.ToString()].ListVal.RemoveAt(e.SIndex);
            es.Domains[comboBox1.SelectedItem.ToString()].ListVal.Insert(e.FIndex, e.Data as string);
        }

        // отмена всего
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //vars[listBox1.SelectedItem.ToString()].Question = textBox1.Text;
        }


    }
}
