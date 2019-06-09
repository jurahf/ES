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
    public partial class frmExplain : Form
    {
        ExpertSystem tempES;


        public frmExplain(ExpertSystem es)
        {
            InitializeComponent();

            // Добавление каринок
            Image imgW = global::ЭС.Properties.Resources.Worked;
            Image imgUW = global::ЭС.Properties.Resources.Unworked;
            //treeView1.ImageList = new ImageList();
            //treeView1.ImageList.Images.Add("Sign", imgW);
            //treeView1.ImageList.Images.Add("Unsign", imgUW);
            //treeView2.ImageList = new ImageList();
            //treeView2.ImageList.Images.Add("Sign", imgW);
            //treeView2.ImageList.Images.Add("Unsign", imgUW);

            tempES = es;
            foreach (Rule r in es.Rules.Vals)
            {
                if (r.Worked != RuleWork.No)
                {
                    treeView2.Nodes.Add(r.Name, r.Name);
                    treeView2.Nodes[r.Name].Nodes.Add(r.Name + "ЕСЛИ", "ЕСЛИ");
                    treeView2.Nodes[r.Name].Nodes.Add(r.Name + "ТО", "ТО");
                    treeView2.Nodes[r.Name].Nodes.Add(r.Name + "ТК", "ТАК КАК");
                    foreach (Fact f in r.Reasons)
                    {
                        treeView2.Nodes[r.Name].Nodes[r.Name + "ЕСЛИ"].Nodes.Add(f.ToString());
                    }
                    treeView2.Nodes[r.Name].Nodes[r.Name + "ТО"].Nodes.Add(r.Result.ToString());
                    treeView2.Nodes[r.Name].Nodes[r.Name + "ТК"].Nodes.Add(r.Reasoning);
                    treeView2.Nodes[r.Name].ExpandAll();
                }
                //if (r.Worked == RuleWork.Signifi)
                //{
                //    treeView2.Nodes[r.Name].ImageIndex = 0;
                //    treeView2.Nodes[r.Name].SelectedImageIndex = 0;
                //}
                //else if (r.Worked == RuleWork.Unsignify)
                //{
                //    treeView2.Nodes[r.Name].ImageIndex = 1;
                //    treeView2.Nodes[r.Name].SelectedImageIndex = 1;
                //}
            }

            foreach (Rule r in es.WorkedRules)
            {
                if (r.Worked == RuleWork.Signifi)
                {
                    treeView1.Nodes.Add(r.Name, r.Name);
                    treeView1.Nodes[r.Name].Nodes.Add(r.Name + "ЕСЛИ", "ЕСЛИ");
                    treeView1.Nodes[r.Name].Nodes.Add(r.Name + "ТО", "ТО");
                    treeView1.Nodes[r.Name].Nodes.Add(r.Name + "ТК", "ТАК КАК");
                    foreach (Fact f in r.Reasons)
                    {
                        treeView1.Nodes[r.Name].Nodes[r.Name + "ЕСЛИ"].Nodes.Add(f.ToString());
                    }
                    treeView1.Nodes[r.Name].Nodes[r.Name + "ТО"].Nodes.Add(r.Result.ToString());
                    treeView1.Nodes[r.Name].Nodes[r.Name + "ТК"].Nodes.Add(r.Reasoning);
                    treeView1.Nodes[r.Name].ExpandAll();
                    //treeView1.Nodes[r.Name].ImageIndex = 0;
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.Add("------ Установленные факты ------");
            foreach (Fact fact in es.Proved)
                if (fact.Truly == Rightly.Yes && !listBox1.Items.Contains(fact.ToString()))
                    listBox1.Items.Add(fact.ToString());
        }


    }
}
