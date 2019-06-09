﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Tools;
using System.Xml;
using Classes;

namespace ЭС
{
    public partial class frmMain : Form
    {
        ExpertSystem tempES = null;
        string tempFile = "";
        /// <summary>
        /// Сохранена ли текущая система
        /// </summary>
        bool saved = true;

        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }


        /// <summary>
        /// Создание новой ЭС
        /// </summary>
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    tempES = new ExpertSystem();
                    tempFile = saveFileDialog1.FileName;
                    if (File.Exists(tempFile))
                        File.Delete(tempFile);
                    File.Create(tempFile);
                    StartES();
                    saved = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FinishES();
            }
        }


        /// <summary>
        /// Скрывает на форме возможность доступа к закрытой ЭС
        /// </summary>
        private void FinishES()
        {
            this.Text = "Экспертная система";
            редактированиеToolStripMenuItem.Enabled = false;
            консультацияToolStripMenuItem.Enabled = false;
            сохранитьToolStripMenuItem.Enabled = false;
            сохранитьКакToolStripMenuItem.Enabled = false;
            закрытьToolStripMenuItem.Enabled = false;
            доменыToolStripMenuItem.Enabled = false;
            переменныеToolStripMenuItem.Enabled = false;
            правилаToolStripMenuItem.Enabled = false;
            пускToolStripMenuItem1.Enabled = false;
            цельToolStripMenuItem1.Enabled = false;
            объяснениеToolStripMenuItem.Enabled = false;
        }


        /// <summary>
        /// Готовит форму к работе с загруженной ЭС
        /// </summary>
        private void StartES()
        {
            this.Text = "Экспертная система - " + tempFile.Substring(tempFile.LastIndexOf('\\') + 1);
            редактированиеToolStripMenuItem.Enabled = true;
            консультацияToolStripMenuItem.Enabled = true;
            сохранитьToolStripMenuItem.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
            закрытьToolStripMenuItem.Enabled = true;
            доменыToolStripMenuItem.Enabled = true;
            переменныеToolStripMenuItem.Enabled = true;
            правилаToolStripMenuItem.Enabled = true;
            пускToolStripMenuItem1.Enabled = true;
            цельToolStripMenuItem1.Enabled = true;
            объяснениеToolStripMenuItem.Enabled = true;
        }


        /// <summary>
        /// Сохраняет экспертную систему в указанный файл
        /// </summary>
        /// <param name="file">Имя файла для сохранения</param>
        private void SaveES(string file)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenWrite(file);
                bf.Serialize(fs, tempES);
                fs.Close();
                MessageBox.Show("Экспертная система успешно сохранена!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Кнопка "Выход"
        /// </summary>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Кнопка "Сохранить"
        /// </summary>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveES(tempFile);
        }


        /// <summary>
        /// Кнопка "Открыть"
        /// </summary>
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = File.OpenRead(openFileDialog1.FileName);
                    var tempES = (Classes.ExpertSystem)bf.Deserialize(fs);
                    fs.Close();
                    tempFile = openFileDialog1.FileName;
                    StartES();


                    ///////////////////////////////////////////////////////
                    //// Преобразуем в новый формат
                    //Classes.ExpertSystem newES = ConvertES(tempES);

                    //// сохраним
                    //BinaryFormatter bf2 = new BinaryFormatter();
                    //FileStream fs2 = File.OpenWrite(Path.Combine(
                    //    Path.GetDirectoryName(openFileDialog1.FileName),
                    //    Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + " new" +
                    //        Path.GetExtension(openFileDialog1.FileName)
                    //    ));
                    //bf2.Serialize(fs2, newES);
                    //fs2.Close();
                    ///////////////////////////////////////////////////////

                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    FinishES();
            //}
        }


        /////////////////////////////////////////////////////////////////////////
        private Classes.ExpertSystem ConvertES(ExpertSystem tempES)
        {
            return new Classes.ExpertSystem()
            {
                res = tempES.res,
                Goal = ConvertVar(tempES.Goal),
                Domains = ConvertOrderedDict<ValueDomain, Classes.ValueDomain>(tempES.Domains, ConvertDomain),
                Vars = ConvertOrderedDict<Variable, Classes.Variable>(tempES.Vars, ConvertVar),
                Rules = ConvertOrderedDict<Rule, Classes.Rule>(tempES.Rules, ConvertRule),
            };
        }

        private Classes.Rule ConvertRule(Rule rule)
        {
            return new Classes.Rule()
            {
                Name = rule.Name,
                Reasoning = rule.Reasoning,
                Reasons = rule.Reasons.Select(x => ConvertFact(x)).ToList(),
                Result = ConvertFact(rule.Result),
                Worked = (Classes.RuleWork)(int)rule.Worked,
            };
        }

        private Classes.Variable ConvertVar(Variable variable)
        {
            return new Classes.Variable()
            {
                Domain = ConvertDomain(variable.Domain),
                Name = variable.Name, 
                MyType = (Classes.VarType)(int)variable.MyType,
                Question = variable.Question, 
                Reasoning = variable.Reasoning
            };
        }

        private Classes.ValueDomain ConvertDomain(ValueDomain domain)
        {
            return new Classes.ValueDomain()
            {
                Name = domain.Name,
                ListVal = domain.ListVal.Select(x => x).ToList(),
            };
        }

        private Classes.Fact ConvertFact(Fact x)
        {
            if (x == null)
                return null;

            return new Classes.Fact()
            {
                Truly = (Classes.Rightly)(int)x.Truly,
                V = ConvertVar(x.V),
                Weight = x.Weight,
            };
        }

        private Tools.OrderedDictionary<string, TRes> ConvertOrderedDict<TSrc, TRes>(OrderedDictionary<string, TSrc> dict, Func<TSrc, TRes> convert)
        {
            var res = new Tools.OrderedDictionary<string, TRes>();

            foreach (var v in dict)
            {
                res.Add(v, convert(dict[v]));
            }

            return res;
        }

        /////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Кнопка "Редактировать домены"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void доменыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDomains f = new frmDomains(tempES);
            if (f.ShowDialog() == DialogResult.OK)
            {
                saved = false;
            }
        }


        /// <summary>
        /// Кнопка "Редактировать переменные"
        /// </summary>
        private void цельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVariables f = new frmVariables(tempES);
            if (f.ShowDialog() == DialogResult.OK)
            {
                saved = false;
            }
        }


        /// <summary>
        /// Кнопка "Редактировать правила"
        /// </summary>
        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRules f = new frmRules(tempES);
            if (f.ShowDialog() == DialogResult.OK)
            {
                saved = false;
            }
        }

        private void цельToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGoal fg = new frmGoal(tempES, this);
            fg.ShowDialog();
        }


        private void пускToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartConsult();
        }


        /// <summary>
        /// Запуск консультации
        /// </summary>
        public void StartConsult()
        {
            try
            {
                if (tempES.Goal != null)
                {
                    Fact f = tempES.GoConsult(new ЗапросПеременнойЧерезФорму());
                    if (f.Truly == Rightly.Unknown)
                        MessageBox.Show("Не удалось установить истину!");
                    else
                        MessageBox.Show(f.ToString());
                }
            }
            catch (DomainException de)
            {
                MessageBox.Show("Не удалось сделать вывод! Причина: " + de.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неизвестная ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void объяснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tempES.WorkedRules == null || tempES.WorkedRules.Count <= 0)
            {
                MessageBox.Show("Нет данных");
                return;
            }
            else
            {
                frmExplain fe = new frmExplain(tempES);
                fe.ShowDialog();
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tempES = null;
            FinishES();
            saved = true;   
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult dr = MessageBox.Show("Сохранить перед выходом?", "Выход", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        SaveES(tempFile);
                        goto case DialogResult.No;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break; ;
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveES(saveFileDialog1.FileName);
                tempFile = saveFileDialog1.FileName;
                StartES();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }


    }
}
