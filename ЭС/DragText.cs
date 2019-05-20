using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ЭС
{
    public partial class DragText : UserControl
    {
        private string text;

        public DragText()
        {
            InitializeComponent();
            label1.AutoSize = true;
            this.Width = label1.Width + 3;
        }



        public override string Text
        {
            get { return text; }
            set
            {
                text = value;
                label1.Text = text;
                label1.Refresh();
                this.Width = label1.Width + 3;
            }
        }






    }
}
