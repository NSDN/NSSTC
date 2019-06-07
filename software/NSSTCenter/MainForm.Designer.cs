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
            this.components = new System.ComponentModel.Container();
            this.groupPort = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.checkConnect = new System.Windows.Forms.CheckBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.listPort = new System.Windows.Forms.ComboBox();
            this.groupFile = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.boxChksum = new System.Windows.Forms.TextBox();
            this.labelChkSum = new System.Windows.Forms.Label();
            this.boxSize = new System.Windows.Forms.TextBox();
            this.boxPath = new System.Windows.Forms.TextBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupFlash = new System.Windows.Forms.GroupBox();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.btnDisableSDP = new System.Windows.Forms.Button();
            this.btnEnableSDP = new System.Windows.Forms.Button();
            this.checkHigh = new System.Windows.Forms.CheckBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.labelChipUnit = new System.Windows.Forms.Label();
            this.listChipSize = new System.Windows.Forms.ComboBox();
            this.labelChipSize = new System.Windows.Forms.Label();
            this.btnFill = new System.Windows.Forms.Button();
            this.listFill = new System.Windows.Forms.ComboBox();
            this.labelFill = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupPort.SuspendLayout();
            this.groupFile.SuspendLayout();
            this.groupFlash.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPort
            // 
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
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(239, 47);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(239, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
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
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(6, 23);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(53, 12);
            this.labelPort.TabIndex = 1;
            this.labelPort.Text = "端口选择";
            // 
            // listPort
            // 
            this.listPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listPort.FormattingEnabled = true;
            this.listPort.Location = new System.Drawing.Point(65, 20);
            this.listPort.Name = "listPort";
            this.listPort.Size = new System.Drawing.Size(168, 20);
            this.listPort.Sorted = true;
            this.listPort.TabIndex = 0;
            // 
            // groupFile
            // 
            this.groupFile.Controls.Add(this.btnSave);
            this.groupFile.Controls.Add(this.boxChksum);
            this.groupFile.Controls.Add(this.labelChkSum);
            this.groupFile.Controls.Add(this.boxSize);
            this.groupFile.Controls.Add(this.boxPath);
            this.groupFile.Controls.Add(this.labelSize);
            this.groupFile.Controls.Add(this.labelPath);
            this.groupFile.Controls.Add(this.btnOpen);
            this.groupFile.Location = new System.Drawing.Point(12, 94);
            this.groupFile.Name = "groupFile";
            this.groupFile.Size = new System.Drawing.Size(320, 103);
            this.groupFile.TabIndex = 1;
            this.groupFile.TabStop = false;
            this.groupFile.Text = "文件选择";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "新建文件";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // boxChksum
            // 
            this.boxChksum.Location = new System.Drawing.Point(231, 47);
            this.boxChksum.Name = "boxChksum";
            this.boxChksum.ReadOnly = true;
            this.boxChksum.Size = new System.Drawing.Size(83, 21);
            this.boxChksum.TabIndex = 6;
            // 
            // labelChkSum
            // 
            this.labelChkSum.AutoSize = true;
            this.labelChkSum.Location = new System.Drawing.Point(160, 50);
            this.labelChkSum.Name = "labelChkSum";
            this.labelChkSum.Size = new System.Drawing.Size(65, 12);
            this.labelChkSum.TabIndex = 5;
            this.labelChkSum.Text = "文件校验和";
            // 
            // boxSize
            // 
            this.boxSize.Location = new System.Drawing.Point(65, 47);
            this.boxSize.Name = "boxSize";
            this.boxSize.ReadOnly = true;
            this.boxSize.Size = new System.Drawing.Size(89, 21);
            this.boxSize.TabIndex = 4;
            // 
            // boxPath
            // 
            this.boxPath.Location = new System.Drawing.Point(65, 20);
            this.boxPath.Name = "boxPath";
            this.boxPath.ReadOnly = true;
            this.boxPath.Size = new System.Drawing.Size(249, 21);
            this.boxPath.TabIndex = 3;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(6, 50);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(53, 12);
            this.labelSize.TabIndex = 2;
            this.labelSize.Text = "文件大小";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(6, 23);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(41, 12);
            this.labelPath.TabIndex = 1;
            this.labelPath.Text = "文件名";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(239, 74);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // groupFlash
            // 
            this.groupFlash.Controls.Add(this.proBar);
            this.groupFlash.Controls.Add(this.btnDisableSDP);
            this.groupFlash.Controls.Add(this.btnEnableSDP);
            this.groupFlash.Controls.Add(this.checkHigh);
            this.groupFlash.Controls.Add(this.btnCheck);
            this.groupFlash.Controls.Add(this.btnRead);
            this.groupFlash.Controls.Add(this.btnWrite);
            this.groupFlash.Controls.Add(this.labelChipUnit);
            this.groupFlash.Controls.Add(this.listChipSize);
            this.groupFlash.Controls.Add(this.labelChipSize);
            this.groupFlash.Controls.Add(this.btnFill);
            this.groupFlash.Controls.Add(this.listFill);
            this.groupFlash.Controls.Add(this.labelFill);
            this.groupFlash.Location = new System.Drawing.Point(12, 203);
            this.groupFlash.Name = "groupFlash";
            this.groupFlash.Size = new System.Drawing.Size(320, 135);
            this.groupFlash.TabIndex = 2;
            this.groupFlash.TabStop = false;
            this.groupFlash.Text = "读写控制";
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(6, 106);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(148, 23);
            this.proBar.TabIndex = 9;
            // 
            // btnDisableSDP
            // 
            this.btnDisableSDP.Location = new System.Drawing.Point(239, 106);
            this.btnDisableSDP.Name = "btnDisableSDP";
            this.btnDisableSDP.Size = new System.Drawing.Size(75, 23);
            this.btnDisableSDP.TabIndex = 11;
            this.btnDisableSDP.Text = "禁用保护";
            this.btnDisableSDP.UseVisualStyleBackColor = true;
            this.btnDisableSDP.Click += new System.EventHandler(this.BtnDisableSDP_Click);
            // 
            // btnEnableSDP
            // 
            this.btnEnableSDP.Location = new System.Drawing.Point(158, 106);
            this.btnEnableSDP.Name = "btnEnableSDP";
            this.btnEnableSDP.Size = new System.Drawing.Size(75, 23);
            this.btnEnableSDP.TabIndex = 10;
            this.btnEnableSDP.Text = "启用保护";
            this.btnEnableSDP.UseVisualStyleBackColor = true;
            this.btnEnableSDP.Click += new System.EventHandler(this.BtnEnableSDP_Click);
            // 
            // checkHigh
            // 
            this.checkHigh.AutoSize = true;
            this.checkHigh.Location = new System.Drawing.Point(230, 22);
            this.checkHigh.Name = "checkHigh";
            this.checkHigh.Size = new System.Drawing.Size(84, 16);
            this.checkHigh.TabIndex = 9;
            this.checkHigh.Text = "无校验写入";
            this.checkHigh.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(158, 77);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "校验芯片";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(6, 77);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "读入文件";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(239, 77);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "写入芯片";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
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
            // listChipSize
            // 
            this.listChipSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listChipSize.FormattingEnabled = true;
            this.listChipSize.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.listChipSize.Location = new System.Drawing.Point(89, 20);
            this.listChipSize.Name = "listChipSize";
            this.listChipSize.Size = new System.Drawing.Size(65, 20);
            this.listChipSize.TabIndex = 4;
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
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(239, 48);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 23);
            this.btnFill.TabIndex = 2;
            this.btnFill.Text = "芯片填充";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.BtnFill_Click);
            // 
            // listFill
            // 
            this.listFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listFill.FormattingEnabled = true;
            this.listFill.Items.AddRange(new object[] {
            "0x00",
            "0xFF"});
            this.listFill.Location = new System.Drawing.Point(89, 46);
            this.listFill.Name = "listFill";
            this.listFill.Size = new System.Drawing.Size(65, 20);
            this.listFill.TabIndex = 1;
            // 
            // labelFill
            // 
            this.labelFill.AutoSize = true;
            this.labelFill.Location = new System.Drawing.Point(6, 49);
            this.labelFill.Name = "labelFill";
            this.labelFill.Size = new System.Drawing.Size(77, 12);
            this.labelFill.TabIndex = 0;
            this.labelFill.Text = "填充字节选择";
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "bin";
            this.openDialog.Filter = "二进制文件|*.bin|所有文件|*.*";
            this.openDialog.Title = "打开文件";
            this.openDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenDialog_FileOk);
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "bin";
            this.saveDialog.Filter = "二进制文件|*.bin|所有文件|*.*";
            this.saveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveDialog_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 350);
            this.Controls.Add(this.groupFlash);
            this.Controls.Add(this.groupFile);
            this.Controls.Add(this.groupPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 389);
            this.MinimumSize = new System.Drawing.Size(360, 389);
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
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox boxChksum;
        private System.Windows.Forms.Label labelChkSum;
        private System.Windows.Forms.GroupBox groupFlash;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label labelChipUnit;
        private System.Windows.Forms.ComboBox listChipSize;
        private System.Windows.Forms.Label labelChipSize;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.ComboBox listFill;
        private System.Windows.Forms.Label labelFill;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.CheckBox checkHigh;
        private System.Windows.Forms.Button btnDisableSDP;
        private System.Windows.Forms.Button btnEnableSDP;
    }
}

