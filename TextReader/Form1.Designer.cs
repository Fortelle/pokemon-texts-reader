namespace TextReader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSourceFolder = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExportFolder = new System.Windows.Forms.TextBox();
            this.btnExportFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFormattedFolder = new System.Windows.Forms.TextBox();
            this.btnFormattedFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFormat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(14, 407);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 530);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSourceFolder
            // 
            this.btnSourceFolder.Location = new System.Drawing.Point(710, 10);
            this.btnSourceFolder.Name = "btnSourceFolder";
            this.btnSourceFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSourceFolder.TabIndex = 2;
            this.btnSourceFolder.Text = "...";
            this.btnSourceFolder.UseVisualStyleBackColor = true;
            this.btnSourceFolder.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(232, 93);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(553, 308);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 530);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(125, 12);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(579, 21);
            this.txtSourceFolder.TabIndex = 5;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(14, 93);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(212, 308);
            this.checkedListBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Source folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Export folder:";
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Location = new System.Drawing.Point(125, 39);
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.ReadOnly = true;
            this.txtExportFolder.Size = new System.Drawing.Size(579, 21);
            this.txtExportFolder.TabIndex = 10;
            // 
            // btnExportFolder
            // 
            this.btnExportFolder.Location = new System.Drawing.Point(710, 37);
            this.btnExportFolder.Name = "btnExportFolder";
            this.btnExportFolder.Size = new System.Drawing.Size(75, 23);
            this.btnExportFolder.TabIndex = 9;
            this.btnExportFolder.Text = "...";
            this.btnExportFolder.UseVisualStyleBackColor = true;
            this.btnExportFolder.Click += new System.EventHandler(this.btnExportFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "Formatted folder:";
            // 
            // txtFormattedFolder
            // 
            this.txtFormattedFolder.Location = new System.Drawing.Point(125, 66);
            this.txtFormattedFolder.Name = "txtFormattedFolder";
            this.txtFormattedFolder.ReadOnly = true;
            this.txtFormattedFolder.Size = new System.Drawing.Size(579, 21);
            this.txtFormattedFolder.TabIndex = 13;
            // 
            // btnFormattedFolder
            // 
            this.btnFormattedFolder.Location = new System.Drawing.Point(710, 64);
            this.btnFormattedFolder.Name = "btnFormattedFolder";
            this.btnFormattedFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFormattedFolder.TabIndex = 12;
            this.btnFormattedFolder.Text = "...";
            this.btnFormattedFolder.UseVisualStyleBackColor = true;
            this.btnFormattedFolder.Click += new System.EventHandler(this.btnFormatted_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(95, 407);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 23);
            this.btnFormat.TabIndex = 15;
            this.btnFormat.Text = "Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 444);
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFormattedFolder);
            this.Controls.Add(this.btnFormattedFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExportFolder);
            this.Controls.Add(this.btnExportFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSourceFolder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnExport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSourceFolder;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExportFolder;
        private System.Windows.Forms.Button btnExportFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFormattedFolder;
        private System.Windows.Forms.Button btnFormattedFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFormat;
    }
}

