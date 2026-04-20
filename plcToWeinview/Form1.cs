using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
namespace plcToWeinview
{
    public partial class btnCompare : Form
    {
        public btnCompare()
        {
            InitializeComponent();
            // 默认值
            excelCow.Text = "U";
            excelLine.Text = "5";
        }

        private void readTxt_Click(object sender, EventArgs e)
        {
            // 1. 创建文件选择对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 2. 限制只能选 TXT 文件
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openFileDialog.FilterIndex = 1; // 默认选中第一项：只看txt

            // 3. 如果用户选择了文件并点击确定
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 4. 把选中的路径填到 plcPath 文本框
                plcPath.Text = openFileDialog.FileName;
            }
        }

        private void readExcel_Click(object sender, EventArgs e)
        {
            // 1. 创建文件选择对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 2. 限制只能选 TXT 文件
            openFileDialog.Filter = "文本文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            openFileDialog.FilterIndex = 1; // 默认选中第一项：只看txt

            // 3. 如果用户选择了文件并点击确定
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 4. 把选中的路径填到 plcPath 文本框
                wltPath.Text = openFileDialog.FileName;
            }
        }

        private void getTxt_Click(object sender, EventArgs e)
        {
            // 1. 获取文本框里的路径
            string filePath = plcPath.Text.Trim();

            // 2. 判断路径是否为空
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("请先选择TXT文件！");
                return;
            }

            // 3. 判断文件是否存在
            if (!File.Exists(filePath))
            {
                MessageBox.Show("文件不存在！");
                return;
            }

            try
            {
                // 4. 按行读取所有内容
                string[] allLines = File.ReadAllLines(filePath);

                // 5. 获取总行数
                int lineCount = allLines.Length;
                MessageBox.Show("TXT文件共 " + lineCount + " 行");

                // 6. 循环遍历 → 存入全局变量 GlobalData.Alarm
                // 最多存 1000 行，防止越界
                for (int i = 0; i < lineCount && i < 1000; i++)
                {
                    GlobalData.AlarmArray[i] = allLines[i];
                }

                MessageBox.Show("读取成功！数据已存入全局 Alarm");
                RefreshAlarmGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败：" + ex.Message);
            }
        }

        private void getExcel_Click(object sender, EventArgs e)
        {
            // Excel路径 取自 wltPath
            string excelPath = wltPath.Text.Trim();
            string colInput = excelCow.Text.Trim().ToUpper();

            if (!int.TryParse(excelLine.Text.Trim(), out int startRow))
            {
                MessageBox.Show("请输入正确数字起始行！");
                return;
            }

            if (!File.Exists(excelPath))
            {
                MessageBox.Show("Excel文件不存在！");
                return;
            }

            // 字母列转数字列 A=1 B=2 E=5
            int colIndex = colInput[0] - 'A' + 1;

            try
            {
                DataTable dt = new DataTable();
                string connStr = "";

                // 判断新版xlsx 还是 旧版xls
                if (excelPath.EndsWith(".xlsx"))
                {
                    connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath +
                             ";Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1';";
                }
                else
                {
                    connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath +
                             ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";
                }

                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("select * from [Event$]", conn);
                    da.Fill(dt);
                }

                int index = 0;
                // 从起始行开始读，行号-1 因为表格索引从0开始
                for (int i = startRow - 1; i < dt.Rows.Count; i++)
                {
                    if (index >= 1000) break;

                    string cellVal = dt.Rows[i][colIndex - 1].ToString().Trim();
                    if (string.IsNullOrEmpty(cellVal))
                        break; // 遇到空行停止

                    // 存入全局
                    GlobalData.wltExcel[index] = cellVal;
                    index++;
                }

                MessageBox.Show($"Excel读取完成，共获取{index}条数据");
                RefreshWltGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败：" + ex.Message);
            }
            //RefreshAlarmGrid();
        }

        //========= 下面两个方法 直接整块复制粘贴在这里 ========
        private void RefreshAlarmGrid()
        {
            dgvAlarm.Rows.Clear();
            dgvAlarm.Columns.Clear();
            dgvAlarm.Columns.Add("colMsg", "TXT报警内容");
            dgvAlarm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlarm.RowHeadersVisible = false;

            for (int i = 0; i < 1000; i++)
            {
                if (!string.IsNullOrWhiteSpace(GlobalData.AlarmArray[i]))
                {
                    dgvAlarm.Rows.Add(GlobalData.AlarmArray[i]);
                }
            }
        }

        private void RefreshWltGrid()
        {
            dgvWlt.Rows.Clear();
            dgvWlt.Columns.Clear();
            dgvWlt.Columns.Add("colMsg", "Excel内容");
            dgvWlt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWlt.RowHeadersVisible = false;

            for (int i = 0; i < 1000; i++)
            {
                if (!string.IsNullOrWhiteSpace(GlobalData.wltExcel[i]))
                {
                    dgvWlt.Rows.Add(GlobalData.wltExcel[i]);
                }
            }
        }

        private void parse_Alarm_Click(object sender, EventArgs e)
        {
            int totalCount = 0;

            // 先算总行数
            for (int i = 0; i < 1000; i++)
            {
                if (!string.IsNullOrEmpty(GlobalData.AlarmArray[i]))
                    totalCount++;
                else
                    break;
            }

            // 开始解析
            for (int i = 0; i < totalCount; i++)
            {
                string line = GlobalData.AlarmArray[i];
                var data = new GlobalData.AlarmData();

                try
                {
                    // 示例："Alarm".Groups4[7] := ... //B102缓存拉带...
                    int groupStart = line.IndexOf("Groups") + 6;
                    int group = int.Parse(line[groupStart].ToString());

                    int indexStart = line.IndexOf('[', groupStart) + 1;
                    int indexEnd = line.IndexOf(']', indexStart);
                    int index = int.Parse(line.Substring(indexStart, indexEnd - indexStart));

                    int msgStart = line.IndexOf("//") + 2;
                    string msg = line.Substring(msgStart).Trim();

                    data.Group = group;
                    data.Index = index;
                    data.Message = msg;
                    data.TotalCount = totalCount;
                }
                catch
                {
                    // 解析失败
                    data.Group = -1;
                    data.Index = -1;
                    data.Message = "Error";
                    data.TotalCount = totalCount;
                }

                GlobalData.PLC_Alarm[i] = data;
            }
            ShowParsedPLCData();
            MessageBox.Show("TXT 解析完成！\n共 " + totalCount + " 条");
        }

        private void parse_WLT_Click(object sender, EventArgs e)
        {
            int totalCount = 0;

            // 先算总行数
            for (int i = 0; i < 1000; i++)
            {
                if (!string.IsNullOrEmpty(GlobalData.wltExcel[i]))
                    totalCount++;
                else
                    break;
            }

            // 开始解析
            for (int i = 0; i < totalCount; i++)
            {
                string line = GlobalData.wltExcel[i];
                var data = new GlobalData.AlarmData();

                try
                {
                    // 示例：Groups1[24]机器人未初始化完成
                    int groupStart = line.IndexOf("Groups") + 6;
                    int group = int.Parse(line[groupStart].ToString());

                    int indexStart = line.IndexOf('[') + 1;
                    int indexEnd = line.IndexOf(']');
                    int index = int.Parse(line.Substring(indexStart, indexEnd - indexStart));

                    string msg = line.Substring(indexEnd + 1).Trim();

                    data.Group = group;
                    data.Index = index;
                    data.Message = msg;
                    data.TotalCount = totalCount;
                }
                catch
                {
                    // 解析失败
                    data.Group = -1;
                    data.Index = -1;
                    data.Message = "Error";
                    data.TotalCount = totalCount;
                }

                GlobalData.WLT_Alarm[i] = data;
            }
            ShowParsedWLTData();
            MessageBox.Show("Excel 解析完成！\n共 " + totalCount + " 条");
        }
        //====================================================

        // ==================== 渲染 PLC 解析表格 ====================
        private void ShowParsedPLCData()
        {
            parseAlarm.Rows.Clear();
            parseAlarm.Columns.Clear();

            parseAlarm.Columns.Add("Group", "组号");
            parseAlarm.Columns.Add("Index", "索引");
            parseAlarm.Columns.Add("Msg", "报警信息");
            parseAlarm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            parseAlarm.RowHeadersVisible = false;

            int total = GlobalData.PLC_Alarm[0].TotalCount;
            parseAlarmTextBox.Text = total.ToString();

            for (int i = 0; i < total; i++)
            {
                var item = GlobalData.PLC_Alarm[i];
                parseAlarm.Rows.Add(item.Group, item.Index, item.Message);
            }
        }

        // ==================== 渲染 WLT 解析表格 ====================
        private void ShowParsedWLTData()
        {
            parseWlt.Rows.Clear();
            parseWlt.Columns.Clear();

            parseWlt.Columns.Add("Group", "组号");
            parseWlt.Columns.Add("Index", "索引");
            parseWlt.Columns.Add("Msg", "报警信息");
            parseWlt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            parseWlt.RowHeadersVisible = false;

            int total = GlobalData.WLT_Alarm[0].TotalCount;
            parseWltTextBox.Text = total.ToString();

            for (int i = 0; i < total; i++)
            {
                var item = GlobalData.WLT_Alarm[i];
                parseWlt.Rows.Add(item.Group, item.Index, item.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string logFile = "调试log.txt";
            File.AppendAllText(logFile, Environment.NewLine);
            File.AppendAllText(logFile, "============================ 数据对比开始 ============================" + Environment.NewLine);
            File.AppendAllText(logFile, $"执行时间：{DateTime.Now:yyyy-MM-dd HH:mm:ss}" + Environment.NewLine);

            int plcValidCount = 0;
            int diffCount = 0;
            int missCount = 0;

            // 1. 遍历所有PLC标准数据 0~999
            for (int i = 0; i < 1000; i++)
            {
                var plc = GlobalData.PLC_Alarm[i];

                // 跳过：解析失败
                if (plc.Group == -1 || plc.Index == -1)
                {
                    File.AppendAllText(logFile, $"[跳过] PLC索引{i} 解析失败(G=-1)" + Environment.NewLine);
                    continue;
                }
                // 跳过：无有效文本
                if (string.IsNullOrWhiteSpace(plc.Message))
                    continue;

                plcValidCount++;
                bool isFindMatch = false;

                // 2. 遍历所有WLT数据 0~999 全程不break
                for (int j = 0; j < 1000; j++)
                {
                    var wlt = GlobalData.WLT_Alarm[j];
                    // 跳过WLT解析失败
                    if (wlt.Group == -1 || wlt.Index == -1)
                        continue;
                    // 跳过WLT空数据
                    if (string.IsNullOrWhiteSpace(wlt.Message))
                        continue;

                    // ✅ 严格唯一匹配：Group 完全一致 + Index 完全一致
                    if (wlt.Group == plc.Group && wlt.Index == plc.Index)
                    {
                        isFindMatch = true;

                        // 内容完全一致
                        if (wlt.Message.Equals(plc.Message))
                        {
                            File.AppendAllText(logFile, $"[一致] G:{plc.Group} I:{plc.Index} | {plc.Message}" + Environment.NewLine);
                        }
                        // 内容不一致 → PLC强制覆盖WLT
                        else
                        {
                            diffCount++;
                            File.AppendAllText(logFile, $"[覆盖] G:{plc.Group} I:{plc.Index}" + Environment.NewLine);
                            File.AppendAllText(logFile, $"   WLT原文：{wlt.Message}" + Environment.NewLine);
                            File.AppendAllText(logFile, $"   PLC标准：{plc.Message}" + Environment.NewLine);

                            // 覆盖写入
                            wlt.Message = plc.Message;
                            GlobalData.WLT_Alarm[j] = wlt;
                        }
                        // 找到当前唯一匹配项，终止WLT内层循环，防止重复乱匹配
                        break;
                    }
                }

                // 3. 循环完WLT全程，没找到 = WLT缺失该条
                if (!isFindMatch)
                {
                    missCount++;
                    File.AppendAllText(logFile, $"[缺失] G:{plc.Group} I:{plc.Index} | {plc.Message}" + Environment.NewLine);
                }
            }

            // 最终统计日志
            File.AppendAllText(logFile, Environment.NewLine);
            File.AppendAllText(logFile, $"对比完成：有效PLC标准数据={plcValidCount} 条 | 内容差异已修正={diffCount} 条 | WLT缺失条目={missCount} 条" + Environment.NewLine);
            File.AppendAllText(logFile, "============================ 数据对比结束 ============================" + Environment.NewLine);

            MessageBox.Show(
                $"对比执行完毕\r\n" +
                $"有效标准数据：{plcValidCount} 条\r\n" +
                $"差异覆盖修正：{diffCount} 条\r\n" +
                $"WLT缺失条目：{missCount} 条");
        }
    }
}
