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
    public partial class Form1 : Form
    {
        public Form1()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败：" + ex.Message);
            }

        }
    }
}
