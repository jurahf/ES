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
    public partial class frmDomains : Form
    {
        private ExpertSystem es;
        private OrderedDictionary<string, ValueDomain> domains = new OrderedDictionary<string, ValueDomain>();
        private OrderedDictionary<string, Variable> vars = new OrderedDictionary<string, Variable>();
        public string newDom;
        public string newVal;

        public frmDomains(ExpertSystem es)
        {
            InitializeComponent();

            this.es = es;

            foreach (string s in es.Domains.Keys)
                domains.Add(s, es.Domains[s]);
            foreach (string s in es.Vars.Keys)
                vars.Add(s, es.Vars[s]);

            foreach (string d in domains.Keys)
                listBox1.Items.Add(d);            
        }


        /// <summary>
        /// Выбор домена - выводим список его значений
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < domains[listBox1.SelectedItem.ToString()].Count; i++)
                    listBox2.Items.Add(domains[listBox1.SelectedItem.ToString()].GetVal(i));
            }
        }


        /// <summary>
        /// Кнопка "Добавить домен"
        /// </summary>
        private void btnAddDomain_Click(object sender, EventArgs e)
        {
            AddDomain();
        }


        /// <summary>
        /// Добавляет новый домен
        /// </summary>
        public DialogResult AddDomain()
        {
            frmAddDom f = new frmAddDom(this);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (newDom == "")
                {
                    MessageBox.Show("Домен не может быть без имени!");
                    return DialogResult.Cancel;
                }
                if (!domains.ContainsKey(newDom))
                {
                    domains.Add(newDom, new ValueDomain(newDom));
                    listBox1.Items.Add(newDom);
                    listBox1.SelectedItem = newDom;
                }
                else
                    MessageBox.Show("Домен с таким именем уже существует!");
            }
            return dr;
        }



        /// <summary>
        /// Кнопка "Добавить значение"
        /// </summary>
        private void btnAddValue_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите нужный домен");
            }
            else
                AddValue(listBox1.SelectedIndex);
        }


        /// <summary>
        /// Добавляет значение в домен
        /// </summary>
        public DialogResult AddValue(int index)
        {
            return AddValue(domains[listBox1.Items[index].ToString()]);
        }


        public DialogResult AddValue(ValueDomain d)
        {
            try
            {
                frmAddVal f = new frmAddVal(this);
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (newVal == "")
                    {
                        MessageBox.Show("Значение не может быть пустым");
                        return DialogResult.Cancel;
                    }
                    d.AddVal(newVal, d.Count);
                    listBox2.Items.Add(newVal);
                }
                return dr;
            }
            catch (DomainException)
            {
                MessageBox.Show("Такое значение уже содержится в домене");
                return DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DialogResult.Cancel;
            }
        }


        /// <summary>
        /// Кнопка "Изменить домен"
        /// </summary>
        private void btnEditDomain_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Сначала необходимо выбрать нужный домен");
                    return;
                }

                string oldDom = listBox1.SelectedItem.ToString();
                frmAddDom f = new frmAddDom(this, oldDom);
                if (f.ShowDialog() == DialogResult.OK && oldDom != newDom)
                {
                    if (newVal == "")
                    {
                        MessageBox.Show("Значение не может быть пустым");
                        return;
                    }

                    ValueDomain nd = new ValueDomain(newDom);
                    for (int i = domains[oldDom].Count - 1; i >= 0; i--)
                        nd.AddVal(domains[oldDom].GetVal(i), 0);

                    domains.Remove(oldDom);
                    listBox1.Items.Remove(oldDom);
                    domains.Add(newDom, nd);
                    listBox1.Items.Add(newDom);
                    // изменяем все переменные с этим доменом
                    foreach (string s in vars.Keys)
                        if (vars[s].Domain.Name == oldDom)
                        {
                            vars[s].Domain = domains[newDom];
                        }
                }
            }
            catch (DomainException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Кнопка "Удалить домен"
        /// </summary>
        private void btnDelDomain_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Сначале необходимо выбрать нужный домен");
                return;
            }

            string oldDom = listBox1.SelectedItem.ToString();
            if (MessageBox.Show("Удалить домен " + oldDom + "?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listBox1.Items.Remove(oldDom);
                listBox1_SelectedIndexChanged(sender, e);
                domains.Remove(oldDom);
                // связанные с ним переменные
                foreach (string s in vars.Keys)
                    if (vars[s].Domain.Name == oldDom)
                        vars[s].Domain = null;
            }
        }


        /// <summary>
        /// Кнопка "Изменить значение"
        /// </summary>
        private void btnEditValue_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex < 0 || listBox2.SelectedIndex < 0)
                {
                    MessageBox.Show("Сначала необходимо выделить нужное значение");
                    return;
                }
                string oldVal = listBox2.SelectedItem.ToString();
                frmAddVal f = new frmAddVal(this, oldVal);
                if (f.ShowDialog() == DialogResult.OK && newVal != oldVal)
                {
                    if (newVal == "")
                    {
                        MessageBox.Show("Значение не может быть пустым");
                        return;
                    }
                    string i = listBox1.SelectedItem.ToString();
                    int index = domains[i].IndexOf(oldVal);
                    domains[i].Remove(oldVal);
                    domains[i].AddVal(newVal, index);
                    listBox1_SelectedIndexChanged(sender, e);
                }
            }
            catch (DomainException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// Кнопка "Удалить значение"
        /// </summary>
        private void btnDelValue_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Сначале необходимо выбрать нужный домен и значение");
                return;
            }

            string oldVal = listBox2.SelectedItem.ToString();
            if (MessageBox.Show("Удалить значение " + oldVal + "?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listBox2.Items.Remove(oldVal);
                domains[listBox1.SelectedItem.ToString()].Remove(oldVal);
            }
        }


        /// <summary>
        /// Кнопка "Готово" - принимаем изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveCollections();
        }

        public void SaveCollections()
        {
            es.Domains.Clear();
            foreach (string s in domains.Keys)
                es.Domains.Add(s, domains[s]);
            es.Vars.Clear();
            foreach (string s in vars.Keys)
                es.Vars.Add(s, vars[s]);
        }


        /// <summary>
        /// Загрузка формы - притягиваем события
        /// </summary>
        private void frmDomains_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// После перетаскивания в окне доменов
        /// </summary>
        void listBox1_AfterDrop(object sender, AfterDropEventArgs e)
        {
            ValueDomain d = domains.Vals[e.SIndex];
            domains.RemoveAt(e.SIndex);
            domains.Insert(e.FIndex, d.Name, d);
        }

        /// <summary>
        /// Перетаскивание значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2_AfterDrop(object sender, AfterDropEventArgs e)
        {
            string s = e.Data as string;
            domains[listBox1.SelectedItem.ToString()].ListVal.RemoveAt(e.SIndex);
            domains[listBox1.SelectedItem.ToString()].ListVal.Insert(e.FIndex, s);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }





    }
}
