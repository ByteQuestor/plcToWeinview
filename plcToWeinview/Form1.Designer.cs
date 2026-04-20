namespace plcToWeinview
{
    partial class btnCompare
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
            this.getTxt = new System.Windows.Forms.Button();
            this.getExcel = new System.Windows.Forms.Button();
            this.excelCow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.excelLine = new System.Windows.Forms.TextBox();
            this.dgvAlarm = new System.Windows.Forms.DataGridView();
            this.dgvWlt = new System.Windows.Forms.DataGridView();
            this.parse_Alarm = new System.Windows.Forms.Button();
            this.parse_WLT = new System.Windows.Forms.Button();
            this.parseWlt = new System.Windows.Forms.DataGridView();
            this.parseAlarm = new System.Windows.Forms.DataGridView();
            this.parseAlarmTextBox = new System.Windows.Forms.TextBox();
            this.parseWltTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseWlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseAlarm)).BeginInit();
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
            // getTxt
            // 
            this.getTxt.Location = new System.Drawing.Point(507, 13);
            this.getTxt.Name = "getTxt";
            this.getTxt.Size = new System.Drawing.Size(105, 38);
            this.getTxt.TabIndex = 4;
            this.getTxt.Text = "读取TXT";
            this.getTxt.UseVisualStyleBackColor = true;
            this.getTxt.Click += new System.EventHandler(this.getTxt_Click);
            // 
            // getExcel
            // 
            this.getExcel.Location = new System.Drawing.Point(507, 57);
            this.getExcel.Name = "getExcel";
            this.getExcel.Size = new System.Drawing.Size(105, 38);
            this.getExcel.TabIndex = 5;
            this.getExcel.Text = "读取Excel";
            this.getExcel.UseVisualStyleBackColor = true;
            this.getExcel.Click += new System.EventHandler(this.getExcel_Click);
            // 
            // excelCow
            // 
            this.excelCow.Location = new System.Drawing.Point(705, 40);
            this.excelCow.Name = "excelCow";
            this.excelCow.Size = new System.Drawing.Size(100, 28);
            this.excelCow.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(811, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "列";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(811, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "行(含本行)";
            // 
            // excelLine
            // 
            this.excelLine.Location = new System.Drawing.Point(705, 74);
            this.excelLine.Name = "excelLine";
            this.excelLine.Size = new System.Drawing.Size(100, 28);
            this.excelLine.TabIndex = 8;
            // 
            // dgvAlarm
            // 
            this.dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarm.Location = new System.Drawing.Point(13, 139);
            this.dgvAlarm.Name = "dgvAlarm";
            this.dgvAlarm.RowHeadersWidth = 62;
            this.dgvAlarm.RowTemplate.Height = 30;
            this.dgvAlarm.Size = new System.Drawing.Size(654, 183);
            this.dgvAlarm.TabIndex = 10;
            // 
            // dgvWlt
            // 
            this.dgvWlt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWlt.Location = new System.Drawing.Point(705, 139);
            this.dgvWlt.Name = "dgvWlt";
            this.dgvWlt.RowHeadersWidth = 62;
            this.dgvWlt.RowTemplate.Height = 30;
            this.dgvWlt.Size = new System.Drawing.Size(654, 183);
            this.dgvWlt.TabIndex = 11;
            // 
            // parse_Alarm
            // 
            this.parse_Alarm.Location = new System.Drawing.Point(243, 346);
            this.parse_Alarm.Name = "parse_Alarm";
            this.parse_Alarm.Size = new System.Drawing.Size(107, 60);
            this.parse_Alarm.TabIndex = 12;
            this.parse_Alarm.Text = "解析Alarm";
            this.parse_Alarm.UseVisualStyleBackColor = true;
            this.parse_Alarm.Click += new System.EventHandler(this.parse_Alarm_Click);
            // 
            // parse_WLT
            // 
            this.parse_WLT.Location = new System.Drawing.Point(970, 346);
            this.parse_WLT.Name = "parse_WLT";
            this.parse_WLT.Size = new System.Drawing.Size(107, 60);
            this.parse_WLT.TabIndex = 13;
            this.parse_WLT.Text = "解析Wlt";
            this.parse_WLT.UseVisualStyleBackColor = true;
            this.parse_WLT.Click += new System.EventHandler(this.parse_WLT_Click);
            // 
            // parseWlt
            // 
            this.parseWlt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parseWlt.Location = new System.Drawing.Point(705, 428);
            this.parseWlt.Name = "parseWlt";
            this.parseWlt.RowHeadersWidth = 62;
            this.parseWlt.RowTemplate.Height = 30;
            this.parseWlt.Size = new System.Drawing.Size(654, 183);
            this.parseWlt.TabIndex = 15;
            // 
            // parseAlarm
            // 
            this.parseAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parseAlarm.Location = new System.Drawing.Point(13, 428);
            this.parseAlarm.Name = "parseAlarm";
            this.parseAlarm.RowHeadersWidth = 62;
            this.parseAlarm.RowTemplate.Height = 30;
            this.parseAlarm.Size = new System.Drawing.Size(654, 183);
            this.parseAlarm.TabIndex = 14;
            // 
            // parseAlarmTextBox
            // 
            this.parseAlarmTextBox.Location = new System.Drawing.Point(394, 377);
            this.parseAlarmTextBox.Name = "parseAlarmTextBox";
            this.parseAlarmTextBox.Size = new System.Drawing.Size(100, 28);
            this.parseAlarmTextBox.TabIndex = 16;
            // 
            // parseWltTextBox
            // 
            this.parseWltTextBox.Location = new System.Drawing.Point(1121, 378);
            this.parseWltTextBox.Name = "parseWltTextBox";
            this.parseWltTextBox.Size = new System.Drawing.Size(100, 28);
            this.parseWltTextBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "数据条数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1118, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "数据条数";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(651, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 59);
            this.button1.TabIndex = 20;
            this.button1.Text = "数据对比";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 803);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.parseWltTextBox);
            this.Controls.Add(this.parseAlarmTextBox);
            this.Controls.Add(this.parseWlt);
            this.Controls.Add(this.parseAlarm);
            this.Controls.Add(this.parse_WLT);
            this.Controls.Add(this.parse_Alarm);
            this.Controls.Add(this.dgvWlt);
            this.Controls.Add(this.dgvAlarm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.excelLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excelCow);
            this.Controls.Add(this.getExcel);
            this.Controls.Add(this.getTxt);
            this.Controls.Add(this.wltPath);
            this.Controls.Add(this.plcPath);
            this.Controls.Add(this.readExcel);
            this.Controls.Add(this.readTxt);
            this.Name = "btnCompare";
            this.Text = "希来报警信息快速填充";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseWlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readTxt;
        private System.Windows.Forms.Button readExcel;
        private System.Windows.Forms.TextBox plcPath;
        private System.Windows.Forms.TextBox wltPath;
        private System.Windows.Forms.Button getTxt;
        private System.Windows.Forms.Button getExcel;
        private System.Windows.Forms.TextBox excelCow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox excelLine;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.DataGridView dgvWlt;
        private System.Windows.Forms.Button parse_Alarm;
        private System.Windows.Forms.Button parse_WLT;
        private System.Windows.Forms.DataGridView parseWlt;
        private System.Windows.Forms.DataGridView parseAlarm;
        private System.Windows.Forms.TextBox parseAlarmTextBox;
        private System.Windows.Forms.TextBox parseWltTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

