using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plcToWeinview
{
    public partial class 希来报警信息快速填充 : Form
    {
        public 希来报警信息快速填充()
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
    }
}
