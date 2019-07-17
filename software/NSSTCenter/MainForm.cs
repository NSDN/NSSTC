using System;
using System.IO;
using System.Linq;
using System.IO.Ports;
using System.Management;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace NSSTCenter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            BtnRefresh_Click(null, null);
            listChipSize.SelectedIndex = 0;
            listFill.SelectedIndex = 0;
        }

        #region "HardwareInfo API"

        /// <summary>
        /// Get the system devices information with windows api.
        /// </summary>
        /// <param name="hardType">Device type.</param>
        /// <param name="propKey">the property of the device.</param>
        /// <returns></returns>
        private static string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
        {

            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties[propKey].Value != null)
                        {
                            string str = hardInfo.Properties[propKey].Value.ToString();
                            strs.Add(str);
                        }

                    }
                }
                return strs.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                strs = null;
            }
        }

        /// <summary>
        /// Hardware enum for windows api.
        /// </summary>
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity, // 即插即用设备
        }

        #endregion

        #region "HEX Helper"
        class HexFile
        {
            public struct HexCmd
            {
                public byte len;
                public ushort addr;
                public byte type;
                public byte[] bytes;
                public byte chksum;

                public bool Check()
                {
                    if (bytes == null) return false;

                    byte sum = 0x00;
                    sum += len; sum += (byte)(addr & 0xFF);
                    sum += (byte)(addr >> 8); sum += type;
                    foreach (byte b in bytes)
                        sum += b;
                    return (byte)((byte)(~sum) + 1) == chksum;
                }
            }

            public List<HexCmd> cmds;

            public HexFile(string[] lines)
            {
                cmds = new List<HexCmd>();

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    
                    HexCmd cmd = new HexCmd(); int pos = 1;
                    byte.TryParse(line.Substring(pos, 2), NumberStyles.HexNumber, null, out cmd.len); pos += 2;
                    ushort.TryParse(line.Substring(pos, 4), NumberStyles.HexNumber, null, out cmd.addr); pos += 4;
                    byte.TryParse(line.Substring(pos, 2), NumberStyles.HexNumber, null, out cmd.type); pos += 2;
                    cmd.bytes = new byte[cmd.len];
                    for (int j = 0; j < cmd.len; j++)
                    {
                        byte.TryParse(line.Substring(pos, 2), NumberStyles.HexNumber, null, out cmd.bytes[j]); pos += 2;
                    }
                    byte.TryParse(line.Substring(pos, 2), NumberStyles.HexNumber, null, out cmd.chksum);

                    cmds.Add(cmd);
                }
            }

            public bool Check()
            {
                foreach (HexCmd cmd in cmds)
                    if (!cmd.Check())
                        return false;
                return true;
            }
        }
        #endregion

        private int GetChipSize()
        {
            int index = listChipSize.SelectedIndex;
            if (index < 0) index = 0;
            return (int)Math.Pow(2, index) * 1024;
        }

        private void SendBytes(params byte[] bytes)
        {
            serialPort.Write(bytes, 0, bytes.Length);
        }

        private void SendBytes(params int[] ints)
        {
            byte[] bytes = new byte[ints.Length];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = (byte)(ints[i] & 0xFF);
            SendBytes(bytes);
        }

        private byte SendAndReadByte(params byte[] bytes)
        {
            serialPort.ReadExisting();
            SendBytes(bytes);
            return (byte)serialPort.ReadByte();
        }

        private void EnableAllControls()
        {
            listPort.Enabled = true;
            //btnRefresh.Enabled = true;
            btnConnect.Enabled = true;
            btnSave.Enabled = true;
            btnOpen.Enabled = true;
            listChipSize.Enabled = true;
            listFill.Enabled = true;
            btnFill.Enabled = true;
            btnRead.Enabled = true;
            btnCheck.Enabled = true;
            btnWrite.Enabled = true;
            checkHigh.Enabled = true;
            btnEnableSDP.Enabled = true;
            btnDisableSDP.Enabled = true;
        }

        private void DisableAllControls()
        {
            listPort.Enabled = false;
            //btnRefresh.Enabled = false;
            btnConnect.Enabled = false;
            btnSave.Enabled = false;
            btnOpen.Enabled = false;
            listChipSize.Enabled = false;
            listFill.Enabled = false;
            btnFill.Enabled = false;
            btnRead.Enabled = false;
            btnCheck.Enabled = false;
            btnWrite.Enabled = false;
            checkHigh.Enabled = false;
            btnEnableSDP.Enabled = false;
            btnDisableSDP.Enabled = false;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            listPort.Items.Clear();
            
            var names = GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
            var query = 
                from val in names
                where val.Contains("(COM")
                select val;

            listPort.Items.AddRange(query.ToArray());
            try
            {
                listPort.SelectedIndex = 0;
            }
            catch
            {
                listPort.SelectedIndex = -1;
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                string port = (string)listPort.SelectedItem;
                port = port.Substring(port.IndexOf("(COM"));
                port = port.Substring(1, port.IndexOf(")") - 1);

                try
                {
                    serialPort.PortName = port;
                    serialPort.Open();
                    btnConnect.Text = "断开";
                    checkConnect.Checked = true;
                    btnRefresh.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "端口打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnConnect.Text = "连接";
                    checkConnect.Checked = false;
                    btnRefresh.Enabled = true;
                }
            }
            else
            {
                try
                {
                    serialPort.Close();
                    btnConnect.Text = "连接";
                    checkConnect.Checked = false;
                    btnRefresh.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "端口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            proBar.Value = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveDialog.ShowDialog();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openDialog.ShowDialog();
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                btnConnect.Focus();
                return;
            }

            DisableAllControls();
            byte fill = listFill.SelectedIndex == 1 ? (byte)0xFF : (byte)0x00;
            int size = GetChipSize();
            try
            {
                SendBytes(0xC0, 0xD0, 0xE0, 0xF0);
                SendBytes(0x80 | (fill & 0x0F), 0x90 | ((fill & 0xF0) >> 4));
                proBar.Maximum = size;
                for (int i = 0; i < size; i++)
                {
                    if (checkHigh.Checked)
                    {
                        SendBytes(0xA0);
                    }
                    else
                    {
                        byte b = SendAndReadByte(0xA0);
                        if (b != fill)
                            break;
                    }
                    proBar.Value = i;
                    Application.DoEvents();
                }
                proBar.Value += 1;

                if (proBar.Value == proBar.Maximum)
                    MessageBox.Show("共写入: " + size.ToString("X4"), "芯片填充结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("已写入: " + proBar.Value.ToString("X4"), "芯片填充中断", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "读写操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableAllControls();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                btnConnect.Focus();
                return;
            }

            DisableAllControls();
            int size = GetChipSize();
            byte[] bytes = new byte[size];
            ushort chksum = 0;
            try
            {
                string path = boxPath.Text;
                if (File.Exists(path))
                {
                    if (path.EndsWith("hex"))
                    {
                        MessageBox.Show("你正在尝试覆盖HEX文件", "读入文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnableAllControls();
                        return;
                    }

                    var result = MessageBox.Show("是否覆盖 \"" + path + "\" ?", "读入文件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        EnableAllControls();
                        return;
                    }
                }

                proBar.Maximum = size;
                SendBytes(0x40, 0x50, 0x60, 0x70);
                for (int i = 0; i < size; i++)
                {
                    bytes[i] = SendAndReadByte(0x00);
                    chksum += bytes[i];
                    proBar.Value = i;
                    Application.DoEvents();
                }
                proBar.Value += 1;

                File.WriteAllBytes(path, bytes);
                boxSize.Text = (new FileInfo(path).Length).ToString("X4");
                boxChksum.Text = chksum.ToString("X4");
                MessageBox.Show(
                    "文件大小: " + boxSize.Text + "\n" + "校验和: " + boxChksum.Text,
                    "读入文件成功", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "读写操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boxSize.Text = "-";
                boxChksum.Text = "-";
            }
            EnableAllControls();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                btnConnect.Focus();
                return;
            }

            DisableAllControls();
            int size = GetChipSize();
            ushort chksum = 0;
            try
            {
                proBar.Maximum = size;
                SendBytes(0x40, 0x50, 0x60, 0x70);
                for (int i = 0; i < size; i++)
                {
                    chksum += SendAndReadByte(0x00);
                    proBar.Value = i;
                    Application.DoEvents();
                }
                proBar.Value += 1;

                MessageBox.Show("校验和: " + chksum.ToString("X4"), "校验和结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "读写操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableAllControls();
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                btnConnect.Focus();
                return;
            }

            DisableAllControls();
            int size = GetChipSize();
            try
            {
                string path = boxPath.Text;
                if (path.EndsWith("hex"))
                {
                    HexFile hexFile = new HexFile(File.ReadAllLines(path));

                    if (!hexFile.Check())
                    {
                        MessageBox.Show(
                            "HEX文件校验失败",
                            "文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                        EnableAllControls();
                        return;
                    }

                    int sumBytes = 0;
                    foreach (HexFile.HexCmd cmd in hexFile.cmds)
                    {
                        sumBytes += cmd.len;
                        if (cmd.addr + cmd.len > size)
                        {
                            MessageBox.Show(
                                "地址: " + cmd.addr.ToString("X4") + "\n" + "长度: " + cmd.len.ToString("X4"),
                                "文件过大", MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                            EnableAllControls();
                            return;
                        }
                    }

                    proBar.Maximum = sumBytes;
                    proBar.Value = 0;

                    byte fill = listFill.SelectedIndex == 1 ? (byte)0xFF : (byte)0x00;
                    byte cod, req;
                    if (fill == 0xFF)
                    {
                        cod = 0xBF; req = 0xFB;
                    }
                    else
                    {
                        cod = 0xB0; req = 0x0B;
                    }

                    serialPort.ReadExisting();
                    SendBytes(cod);

                    bool flag = false; byte tmp = 0x00;
                    void recEvent(object obj, SerialDataReceivedEventArgs args)
                    {
                        flag = true;
                        tmp = (byte)serialPort.ReadByte();
                    }
                    serialPort.DataReceived += recEvent;

                    proBar.Style = ProgressBarStyle.Marquee;
                    int start = Environment.TickCount;
                    while (!flag)
                    {
                        Application.DoEvents();
                        if (Environment.TickCount - start > 30 * 1000)
                            break;
                    }
                    proBar.Style = ProgressBarStyle.Continuous;
                    serialPort.DataReceived -= recEvent;
                    if (tmp != req)
                    {
                        MessageBox.Show("芯片擦除超时或擦除指令执行失败", "芯片擦除出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        EnableAllControls();
                        return;
                    }

                    foreach (HexFile.HexCmd cmd in hexFile.cmds)
                    {
                        SendBytes(0xC0 | ((cmd.addr & 0x000F) >> 0));
                        SendBytes(0xD0 | ((cmd.addr & 0x00F0) >> 4));
                        SendBytes(0xE0 | ((cmd.addr & 0x0F00) >> 8));
                        SendBytes(0xF0 | ((cmd.addr & 0xF000) >> 12));
                        for (int i = 0; i < cmd.bytes.Length; i++)
                        {
                            SendBytes(0x80 | (cmd.bytes[i] & 0x0F), 0x90 | ((cmd.bytes[i] & 0xF0) >> 4));
                            if (checkHigh.Checked)
                            {
                                SendBytes(0xA0);
                            }
                            else
                            {
                                byte b = SendAndReadByte(0xA0);
                                if (b != cmd.bytes[i])
                                    break;
                            }
                            proBar.Value += 1;
                            Application.DoEvents();
                        }
                    }
                }
                else
                {
                    byte[] bytes = File.ReadAllBytes(boxPath.Text);
                    int fileSize = int.Parse(boxSize.Text, NumberStyles.HexNumber);
                    if (size < fileSize)
                    {
                        MessageBox.Show(
                            "芯片容量: " + size.ToString("X4") + "\n" + "文件大小: " + fileSize.ToString("X4"),
                            "文件过大", MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                        EnableAllControls();
                        return;
                    }
                    proBar.Maximum = fileSize;
                    proBar.Value = 0;
                    SendBytes(0xC0, 0xD0, 0xE0, 0xF0);
                    for (int i = 0; i < fileSize; i++)
                    {
                        SendBytes(0x80 | (bytes[i] & 0x0F), 0x90 | ((bytes[i] & 0xF0) >> 4));
                        if (checkHigh.Checked)
                        {
                            SendBytes(0xA0);
                        }
                        else
                        {
                            byte b = SendAndReadByte(0xA0);
                            if (b != bytes[i])
                                break;
                        }
                        proBar.Value += 1;
                        Application.DoEvents();
                    }
                }
                if (proBar.Value == proBar.Maximum)
                    MessageBox.Show("共写入: " + proBar.Value.ToString("X4"), "芯片写入结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("已写入: " + proBar.Value.ToString("X4"), "芯片写入中断", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "读写操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableAllControls();
        }

        private void OpenDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string path = openDialog.FileName;
            boxPath.Text = path;
            try
            {
                boxSize.Text = (new FileInfo(path).Length).ToString("X4");
                var data = File.ReadAllBytes(path);
                ushort chksum = 0;
                foreach (byte b in data) chksum += b;
                boxChksum.Text = chksum.ToString("X4");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "文件打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string path = saveDialog.FileName;
            boxPath.Text = path;
            boxSize.Text = "-";
            boxChksum.Text = "-";
        }

        private void BtnEnableSDP_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                btnConnect.Focus();
                return;
            }
            SendBytes(0xA5);
            MessageBox.Show("软件数据保护（SDP）已开启", "保护已启用", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDisableSDP_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                btnConnect.Focus();
                return;
            }
            SendBytes(0xAA);
            MessageBox.Show("软件数据保护（SDP）已关闭", "保护已禁用", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
