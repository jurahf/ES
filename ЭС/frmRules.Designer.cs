namespace ЭС
{
    partial class frmRules
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
            this.btnAddRule = new System.Windows.Forms.Button();
            this.btnEditRule = new System.Windows.Forms.Button();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.btnAddReason = new System.Windows.Forms.Button();
            this.btnEditReason = new System.Windows.Forms.Button();
            this.btnDeleteReason = new System.Windows.Forms.Button();
            this.btnModifyResult = new System.Windows.Forms.Button();
            this.btnDeleteResult = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstReasons = new ЭС.DragListBox();
            this.lstResult = new ЭС.DragListBox();
            this.lstRules = new ЭС.DragListBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRule
            // 
            this.btnAddRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRule.Location = new System.Drawing.Point(487, 12);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(75, 23);
            this.btnAddRule.TabIndex = 3;
            this.btnAddRule.Text = "Добавить";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // btnEditRule
            // 
            this.btnEditRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRule.Enabled = false;
            this.btnEditRule.Location = new System.Drawing.Point(487, 41);
            this.btnEditRule.Name = "btnEditRule";
            this.btnEditRule.Size = new System.Drawing.Size(75, 23);
            this.btnEditRule.TabIndex = 4;
            this.btnEditRule.Text = "Изменить";
            this.btnEditRule.UseVisualStyleBackColor = true;
            this.btnEditRule.Click += new System.EventHandler(this.btnEditRule_Click);
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRule.Enabled = false;
            this.btnDeleteRule.Location = new System.Drawing.Point(487, 70);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRule.TabIndex = 5;
            this.btnDeleteRule.Text = "Удалить";
            this.btnDeleteRule.UseVisualStyleBackColor = true;
            this.btnDeleteRule.Click += new System.EventHandler(this.btnDeleteRule_Click);
            // 
            // btnAddReason
            // 
            this.btnAddReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddReason.Enabled = false;
            this.btnAddReason.Location = new System.Drawing.Point(185, 26);
            this.btnAddReason.Name = "btnAddReason";
            this.btnAddReason.Size = new System.Drawing.Size(75, 23);
            this.btnAddReason.TabIndex = 6;
            this.btnAddReason.Text = "Добавить";
            this.btnAddReason.UseVisualStyleBackColor = true;
            this.btnAddReason.Click += new System.EventHandler(this.btnAddReason_Click);
            // 
            // btnEditReason
            // 
            this.btnEditReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditReason.Enabled = false;
            this.btnEditReason.Location = new System.Drawing.Point(185, 55);
            this.btnEditReason.Name = "btnEditReason";
            this.btnEditReason.Size = new System.Drawing.Size(75, 23);
            this.btnEditReason.TabIndex = 7;
            this.btnEditReason.Text = "Изменить";
            this.btnEditReason.UseVisualStyleBackColor = true;
            this.btnEditReason.Click += new System.EventHandler(this.btnEditReason_Click);
            // 
            // btnDeleteReason
            // 
            this.btnDeleteReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteReason.Enabled = false;
            this.btnDeleteReason.Location = new System.Drawing.Point(185, 84);
            this.btnDeleteReason.Name = "btnDeleteReason";
            this.btnDeleteReason.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteReason.TabIndex = 8;
            this.btnDeleteReason.Text = "Удалить";
            this.btnDeleteReason.UseVisualStyleBackColor = true;
            this.btnDeleteReason.Click += new System.EventHandler(this.btnDeleteReason_Click);
            // 
            // btnModifyResult
            // 
            this.btnModifyResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyResult.Enabled = false;
            this.btnModifyResult.Location = new System.Drawing.Point(185, 26);
            this.btnModifyResult.Name = "btnModifyResult";
            this.btnModifyResult.Size = new System.Drawing.Size(75, 23);
            this.btnModifyResult.TabIndex = 9;
            this.btnModifyResult.Text = "Установить";
            this.btnModifyResult.UseVisualStyleBackColor = true;
            this.btnModifyResult.Click += new System.EventHandler(this.btnModifyResult_Click);
            // 
            // btnDeleteResult
            // 
            this.btnDeleteResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteResult.Enabled = false;
            this.btnDeleteResult.Location = new System.Drawing.Point(185, 55);
            this.btnDeleteResult.Name = "btnDeleteResult";
            this.btnDeleteResult.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteResult.TabIndex = 10;
            this.btnDeleteResult.Text = "Удалить";
            this.btnDeleteResult.UseVisualStyleBackColor = true;
            this.btnDeleteResult.Click += new System.EventHandler(this.btnDeleteResult_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(551, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отменить все";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(470, 355);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Готово";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ЕСЛИ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "ТО";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(480, 128);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(170, 83);
            this.textBox1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Объяснение правила:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 217);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnEditReason);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddReason);
            this.splitContainer1.Panel1.Controls.Add(this.lstReasons);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteReason);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteResult);
            this.splitContainer1.Panel2.Controls.Add(this.lstResult);
            this.splitContainer1.Panel2.Controls.Add(this.btnModifyResult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(540, 132);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 20;
            // 
            // lstReasons
            // 
            this.lstReasons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstReasons.FormattingEnabled = true;
            this.lstReasons.HorizontalScrollbar = true;
            this.lstReasons.Location = new System.Drawing.Point(9, 26);
            this.lstReasons.Name = "lstReasons";
            this.lstReasons.Size = new System.Drawing.Size(170, 95);
            this.lstReasons.TabIndex = 18;
            this.lstReasons.AfterDrop += new ЭС.AfterDropEventHandler(this.lstReasons_AfterDrop);
            // 
            // lstResult
            // 
            this.lstResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResult.FormattingEnabled = true;
            this.lstResult.HorizontalScrollbar = true;
            this.lstResult.Location = new System.Drawing.Point(9, 26);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(170, 95);
            this.lstResult.TabIndex = 19;
            // 
            // lstRules
            // 
            this.lstRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRules.FormattingEnabled = true;
            this.lstRules.HorizontalScrollbar = true;
            this.lstRules.Location = new System.Drawing.Point(12, 12);
            this.lstRules.Name = "lstRules";
            this.lstRules.Size = new System.Drawing.Size(459, 199);
            this.lstRules.TabIndex = 17;
            this.lstRules.AfterDrop += new ЭС.AfterDropEventHandler(this.lstRules_AfterDrop);
            this.lstRules.SelectedIndexChanged += new System.EventHandler(this.lstRules_SelectedIndexChanged);
            // 
            // frmRules
            // 
            this.AcceptButton = this.btnOk;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(662, 390);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lstRules);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeleteRule);
            this.Controls.Add(this.btnEditRule);
            this.Controls.Add(this.btnAddRule);
            this.MinimumSize = new System.Drawing.Size(644, 428);
            this.Name = "frmRules";
            this.Text = "Правила";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Button btnEditRule;
        private System.Windows.Forms.Button btnDeleteRule;
        private System.Windows.Forms.Button btnAddReason;
        private System.Windows.Forms.Button btnEditReason;
        private System.Windows.Forms.Button btnDeleteReason;
        private System.Windows.Forms.Button btnModifyResult;
        private System.Windows.Forms.Button btnDeleteResult;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private DragListBox lstRules;
        private DragListBox lstReasons;
        private DragListBox lstResult;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}