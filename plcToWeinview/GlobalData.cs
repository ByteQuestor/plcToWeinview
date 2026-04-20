using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plcToWeinview
{
    internal class GlobalData
    {
        // 方案A：固定长度数组（1000条）
        public static string[] AlarmArray = new string[3000];

        // 方案B：动态列表（推荐，可自动扩容，初始容量1000）
        //public static List<string> AlarmList = new List<string>(1000);

        public static string[] wltExcel = new string[3000];
    }
}
