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
    public partial class DragListBox : ListBox 
    {
        DragText dt; // вид того, что переносим
        DragDropEffects de = DragDropEffects.None; // переносим или нет
        object s;   // переносимые данные
        private int sIndex, fIndex; // откуда и куда перетащили элемент

        public event AfterDropEventHandler AfterDrop;


        public DragListBox()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(DragListBox_MouseDown);
            this.MouseMove += new MouseEventHandler(DragListBox_MouseMove);
            this.MouseUp += new MouseEventHandler(DragListBox_MouseUp);
        }


        /// <summary>
        /// Отпустили кнопку - кладем элемент на место
        /// </summary>
        void DragListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (de == DragDropEffects.Move)
            {
                de = DragDropEffects.None;
                fIndex  = this.IndexFromPoint(e.X, e.Y);
                if (fIndex > this.Items.Count) fIndex = this.Items.Count;
                this.Items.Insert(++fIndex, s);
                dt.Dispose();
                // событие
                AfterDropEventArgs MyE = new AfterDropEventArgs(sIndex, fIndex, s);
                AfterDragDrop(MyE);
            }
        }


        /// <summary>
        /// Перетаскивание
        /// </summary>
        void DragListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (de == DragDropEffects.Move)
            {
                dt.Left = e.X;
                dt.Top = e.Y;
                dt.Refresh();
            }
        }



        /// <summary>
        /// Нажали мышь - захват для перетаскивания
        /// </summary>
        void DragListBox_MouseDown(object sender, MouseEventArgs e)
        {
            sIndex = this.IndexFromPoint(e.X, e.Y);
            if (e.Button == MouseButtons.Right && sIndex >= 0)
            {
                dt = new DragText();
                dt.Parent = this;
                dt.Show();
                s = this.Items[sIndex];
                dt.Text = s as string;
                dt.Left = e.X;
                dt.Top = e.Y;
                

                this.Items.RemoveAt(sIndex);
                de = DragDropEffects.Move;
            }
        }


        protected virtual void AfterDragDrop(AfterDropEventArgs e)
        {
            if (AfterDrop != null)
            {
                AfterDrop(this, e);
            }
        }

    }




    public class AfterDropEventArgs :EventArgs
    {
        public int SIndex { get; set; }
        public int FIndex { get; set; }
        public object Data { get; set; }

        public AfterDropEventArgs (int sIndex, int fIndex, object Data)
        {
            this.SIndex = sIndex;
            this.FIndex = fIndex;
            this.Data = Data;
        }
    }


    public delegate void AfterDropEventHandler(object sender, AfterDropEventArgs e);
}
