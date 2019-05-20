namespace ЭС
{
    partial class frmDomains
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddDomain = new System.Windows.Forms.Button();
            this.btnEditDomain = new System.Windows.Forms.Button();
            this.btnDelDomain = new System.Windows.Forms.Button();
            this.btnAddValue = new System.Windows.Forms.Button();
            this.btnEditValue = new System.Windows.Forms.Button();
            this.btnDelValue = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listBox1 = new ЭС.DragListBox();
            this.listBox2 = new ЭС.DragListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Домены";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Значения";
            // 
            // btnAddDomain
            // 
            this.btnAddDomain.Location = new System.Drawing.Point(15, 258);
            this.btnAddDomain.Name = "btnAddDomain";
            this.btnAddDomain.Size = new System.Drawing.Size(75, 23);
            this.btnAddDomain.TabIndex = 4;
            this.btnAddDomain.Text = "Добавить";
            this.btnAddDomain.UseVisualStyleBackColor = true;
            this.btnAddDomain.Click += new System.EventHandler(this.btnAddDomain_Click);
            // 
            // btnEditDomain
            // 
            this.btnEditDomain.Location = new System.Drawing.Point(96, 258);
            this.btnEditDomain.Name = "btnEditDomain";
            this.btnEditDomain.Size = new System.Drawing.Size(75, 23);
            this.btnEditDomain.TabIndex = 5;
            this.btnEditDomain.Text = "Изменить";
            this.btnEditDomain.UseVisualStyleBackColor = true;
            this.btnEditDomain.Click += new System.EventHandler(this.btnEditDomain_Click);
            // 
            // btnDelDomain
            // 
            this.btnDelDomain.Location = new System.Drawing.Point(177, 258);
            this.btnDelDomain.Name = "btnDelDomain";
            this.btnDelDomain.Size = new System.Drawing.Size(75, 23);
            this.btnDelDomain.TabIndex = 6;
            this.btnDelDomain.Text = "Удалить";
            this.btnDelDomain.UseVisualStyleBackColor = true;
            this.btnDelDomain.Click += new System.EventHandler(this.btnDelDomain_Click);
            // 
            // btnAddValue
            // 
            this.btnAddValue.Location = new System.Drawing.Point(281, 258);
            this.btnAddValue.Name = "btnAddValue";
            this.btnAddValue.Size = new System.Drawing.Size(75, 23);
            this.btnAddValue.TabIndex = 7;
            this.btnAddValue.Text = "Добавить";
            this.btnAddValue.UseVisualStyleBackColor = true;
            this.btnAddValue.Click += new System.EventHandler(this.btnAddValue_Click);
            // 
            // btnEditValue
            // 
            this.btnEditValue.Location = new System.Drawing.Point(362, 258);
            this.btnEditValue.Name = "btnEditValue";
            this.btnEditValue.Size = new System.Drawing.Size(75, 23);
            this.btnEditValue.TabIndex = 8;
            this.btnEditValue.Text = "Изменить";
            this.btnEditValue.UseVisualStyleBackColor = true;
            this.btnEditValue.Click += new System.EventHandler(this.btnEditValue_Click);
            // 
            // btnDelValue
            // 
            this.btnDelValue.Location = new System.Drawing.Point(443, 258);
            this.btnDelValue.Name = "btnDelValue";
            this.btnDelValue.Size = new System.Drawing.Size(75, 23);
            this.btnDelValue.TabIndex = 9;
            this.btnDelValue.Text = "Удалить";
            this.btnDelValue.UseVisualStyleBackColor = true;
            this.btnDelValue.Click += new System.EventHandler(this.btnDelValue_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(352, 300);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Готово";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(433, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отменить все";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(15, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(237, 225);
            this.listBox1.TabIndex = 12;
            this.listBox1.AfterDrop += new ЭС.AfterDropEventHandler(this.listBox1_AfterDrop);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(281, 27);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(237, 225);
            this.listBox2.TabIndex = 13;
            this.listBox2.AfterDrop += new ЭС.AfterDropEventHandler(this.listBox2_AfterDrop);
            // 
            // frmDomains
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 335);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnDelValue);
            this.Controls.Add(this.btnEditValue);
            this.Controls.Add(this.btnAddValue);
            this.Controls.Add(this.btnDelDomain);
            this.Controls.Add(this.btnEditDomain);
            this.Controls.Add(this.btnAddDomain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(556, 373);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(556, 373);
            this.Name = "frmDomains";
            this.Text = "Домены значений";
            this.Load += new System.EventHandler(this.frmDomains_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddDomain;
        private System.Windows.Forms.Button btnEditDomain;
        private System.Windows.Forms.Button btnDelDomain;
        private System.Windows.Forms.Button btnAddValue;
        private System.Windows.Forms.Button btnEditValue;
        private System.Windows.Forms.Button btnDelValue;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private DragListBox listBox1;
        private DragListBox listBox2;
    }
}