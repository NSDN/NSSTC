namespace NSSTCenter
{
    partial class MainForm
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
            this.groupPort = new System.Windows.Forms.GroupBox();
            this.listPort = new System.Windows.Forms.ComboBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.checkConnect = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupFile = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxPath = new System.Windows.Forms.TextBox();
            this.boxSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxChksum = new System.Windows.Forms.TextBox();
            this.groupFlash = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listFill = new System.Windows.Forms.ComboBox();
            this.btnFill = new System.Windows.Forms.Button();
            this.labelChipSize = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelChipUnit = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.checkReset = new System.Windows.Forms.CheckBox();
            this.groupPort.SuspendLayout();
            this.groupFile.SuspendLayout();
            this.groupFlash.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPort
            // 
            this.groupPort.Controls.Add(this.checkReset);
            this.groupPort.Controls.Add(this.btnConnect);
            this.groupPort.Controls.Add(this.btnRefresh);
            this.groupPort.Controls.Add(this.checkConnect);
            this.groupPort.Controls.Add(this.labelPort);
            this.groupPort.Controls.Add(this.listPort);
            this.groupPort.Location = new System.Drawing.Point(12, 12);
            this.groupPort.Name = "groupPort";
            this.groupPort.Size = new System.Drawing.Size(320, 76);
            this.groupPort.TabIndex = 0;
            this.groupPort.TabStop = false;
            this.groupPort.Text = "端口设置";
            // 
            // listPort
            // 
            this.listPort.FormattingEnabled = true;
            this.listPort.Location = new System.Drawing.Point(65, 20);
            this.listPort.Name = "listPort";
            this.listPort.Size = new System.Drawing.Size(168, 20);
            this.listPort.TabIndex = 0;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(6, 23);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(53, 12);
            this.labelPort.TabIndex = 1;
            this.labelPort.Text = "端口选择";
            // 
            // checkConnect
            // 
            this.checkConnect.AutoCheck = false;
            this.checkConnect.AutoSize = true;
            this.checkConnect.Cursor = System.Windows.Forms.Cursors.No;
            this.checkConnect.Location = new System.Drawing.Point(8, 51);
            this.checkConnect.Name = "checkConnect";
            this.checkConnect.Size = new System.Drawing.Size(72, 16);
            this.checkConnect.TabIndex = 2;
            this.checkConnect.Text = "连接状态";
            this.checkConnect.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(239, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(239, 47);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // groupFile
            // 
            this.groupFile.Controls.Add(this.btnSave);
            this.groupFile.Controls.Add(this.boxChksum);
            this.groupFile.Controls.Add(this.label3);
            this.groupFile.Controls.Add(this.boxSize);
            this.groupFile.Controls.Add(this.boxPath);
            this.groupFile.Controls.Add(this.label2);
            this.groupFile.Controls.Add(this.label1);
            this.groupFile.Controls.Add(this.btnOpen);
            this.groupFile.Location = new System.Drawing.Point(12, 94);
            this.groupFile.Name = "groupFile";
            this.groupFile.Size = new System.Drawing.Size(320, 103);
            this.groupFile.TabIndex = 1;
            this.groupFile.TabStop = false;
            this.groupFile.Text = "文件选择";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(239, 74);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "文件大小";
            // 
            // boxPath
            // 
            this.boxPath.Location = new System.Drawing.Point(65, 20);
            this.boxPath.Name = "boxPath";
            this.boxPath.ReadOnly = true;
            this.boxPath.Size = new System.Drawing.Size(249, 21);
            this.boxPath.TabIndex = 3;
            // 
            // boxSize
            // 
            this.boxSize.Location = new System.Drawing.Point(65, 47);
            this.boxSize.Name = "boxSize";
            this.boxSize.ReadOnly = true;
            this.boxSize.Size = new System.Drawing.Size(89, 21);
            this.boxSize.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "文件校验和";
            // 
            // boxChksum
            // 
            this.boxChksum.Location = new System.Drawing.Point(231, 47);
            this.boxChksum.Name = "boxChksum";
            this.boxChksum.ReadOnly = true;
            this.boxChksum.Size = new System.Drawing.Size(83, 21);
            this.boxChksum.TabIndex = 6;
            // 
            // groupFlash
            // 
            this.groupFlash.Controls.Add(this.btnCheck);
            this.groupFlash.Controls.Add(this.btnRead);
            this.groupFlash.Controls.Add(this.btnWrite);
            this.groupFlash.Controls.Add(this.labelChipUnit);
            this.groupFlash.Controls.Add(this.comboBox1);
            this.groupFlash.Controls.Add(this.labelChipSize);
            this.groupFlash.Controls.Add(this.btnFill);
            this.groupFlash.Controls.Add(this.listFill);
            this.groupFlash.Controls.Add(this.label4);
            this.groupFlash.Location = new System.Drawing.Point(12, 203);
            this.groupFlash.Name = "groupFlash";
            this.groupFlash.Size = new System.Drawing.Size(320, 106);
            this.groupFlash.TabIndex = 2;
            this.groupFlash.TabStop = false;
            this.groupFlash.Text = "读写控制";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "新建文件";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "填充字节选择";
            // 
            // listFill
            // 
            this.listFill.FormattingEnabled = true;
            this.listFill.Items.AddRange(new object[] {
            "0x00",
            "0xFF"});
            this.listFill.Location = new System.Drawing.Point(89, 46);
            this.listFill.Name = "listFill";
            this.listFill.Size = new System.Drawing.Size(65, 20);
            this.listFill.TabIndex = 1;
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(239, 44);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 23);
            this.btnFill.TabIndex = 2;
            this.btnFill.Text = "芯片填充";
            this.btnFill.UseVisualStyleBackColor = true;
            // 
            // labelChipSize
            // 
            this.labelChipSize.AutoSize = true;
            this.labelChipSize.Location = new System.Drawing.Point(6, 23);
            this.labelChipSize.Name = "labelChipSize";
            this.labelChipSize.Size = new System.Drawing.Size(77, 12);
            this.labelChipSize.TabIndex = 3;
            this.labelChipSize.Text = "芯片容量选择";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.comboBox1.Location = new System.Drawing.Point(89, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 20);
            this.comboBox1.TabIndex = 4;
            // 
            // labelChipUnit
            // 
            this.labelChipUnit.AutoSize = true;
            this.labelChipUnit.Location = new System.Drawing.Point(160, 23);
            this.labelChipUnit.Name = "labelChipUnit";
            this.labelChipUnit.Size = new System.Drawing.Size(41, 12);
            this.labelChipUnit.TabIndex = 5;
            this.labelChipUnit.Text = "千字节";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(239, 77);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "写入芯片";
            this.btnWrite.UseVisualStyleBackColor = true;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(8, 77);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "读入文件";
            this.btnRead.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(158, 77);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "校验芯片";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // checkReset
            // 
            this.checkReset.AutoCheck = false;
            this.checkReset.AutoSize = true;
            this.checkReset.Cursor = System.Windows.Forms.Cursors.No;
            this.checkReset.Location = new System.Drawing.Point(86, 51);
            this.checkReset.Name = "checkReset";
            this.checkReset.Size = new System.Drawing.Size(72, 16);
            this.checkReset.TabIndex = 5;
            this.checkReset.Text = "复位状态";
            this.checkReset.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 321);
            this.Controls.Add(this.groupFlash);
            this.Controls.Add(this.groupFile);
            this.Controls.Add(this.groupPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 360);
            this.MinimumSize = new System.Drawing.Size(360, 360);
            this.Name = "MainForm";
            this.Text = "NyaSama Simple Transfer Center";
            this.groupPort.ResumeLayout(false);
            this.groupPort.PerformLayout();
            this.groupFile.ResumeLayout(false);
            this.groupFile.PerformLayout();
            this.groupFlash.ResumeLayout(false);
            this.groupFlash.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox checkConnect;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.ComboBox listPort;
        private System.Windows.Forms.GroupBox groupFile;
        private System.Windows.Forms.TextBox boxSize;
        private System.Windows.Forms.TextBox boxPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox boxChksum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupFlash;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label labelChipUnit;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelChipSize;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.ComboBox listFill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkReset;
    }
}

