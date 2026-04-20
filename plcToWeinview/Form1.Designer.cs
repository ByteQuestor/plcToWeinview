namespace plcToWeinview
{
    partial class 希来报警信息快速填充
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
            this.readTxt = new System.Windows.Forms.Button();
            this.readExcel = new System.Windows.Forms.Button();
            this.plcPath = new System.Windows.Forms.TextBox();
            this.wltPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // readTxt
            // 
            this.readTxt.Location = new System.Drawing.Point(13, 13);
            this.readTxt.Name = "readTxt";
            this.readTxt.Size = new System.Drawing.Size(105, 38);
            this.readTxt.TabIndex = 0;
            this.readTxt.Text = "选择PLC";
            this.readTxt.UseVisualStyleBackColor = true;
            this.readTxt.Click += new System.EventHandler(this.readTxt_Click);
            // 
            // readExcel
            // 
            this.readExcel.Location = new System.Drawing.Point(13, 57);
            this.readExcel.Name = "readExcel";
            this.readExcel.Size = new System.Drawing.Size(105, 38);
            this.readExcel.TabIndex = 1;
            this.readExcel.Text = "选择WLT";
            this.readExcel.UseVisualStyleBackColor = true;
            this.readExcel.Click += new System.EventHandler(this.readExcel_Click);
            // 
            // plcPath
            // 
            this.plcPath.Location = new System.Drawing.Point(128, 18);
            this.plcPath.Name = "plcPath";
            this.plcPath.Size = new System.Drawing.Size(358, 28);
            this.plcPath.TabIndex = 2;
            // 
            // wltPath
            // 
            this.wltPath.Location = new System.Drawing.Point(128, 64);
            this.wltPath.Name = "wltPath";
            this.wltPath.Size = new System.Drawing.Size(358, 28);
            this.wltPath.TabIndex = 3;
            // 
            // 希来报警信息快速填充
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 803);
            this.Controls.Add(this.wltPath);
            this.Controls.Add(this.plcPath);
            this.Controls.Add(this.readExcel);
            this.Controls.Add(this.readTxt);
            this.Name = "希来报警信息快速填充";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readTxt;
        private System.Windows.Forms.Button readExcel;
        private System.Windows.Forms.TextBox plcPath;
        private System.Windows.Forms.TextBox wltPath;
    }
}

