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

        // 解析后的结构体（你要的：int int string int）
        public struct AlarmData
        {
            public int Group;      // 组号
            public int Index;      // 索引
            public string Message; // 描述
            public int TotalCount; // 总行数
        }

        // 最终解析结果
        public static AlarmData[] PLC_Alarm = new AlarmData[1000];
        public static AlarmData[] WLT_Alarm = new AlarmData[1000];

        //最终写入到表格
        public static string[] wltSaveExcel = new string[3000];
    }
}
