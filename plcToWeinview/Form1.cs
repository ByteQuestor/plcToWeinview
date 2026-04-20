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
namespace plcToWeinview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
