using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// 数据域
    /// </summary>
    class Data
    {
        /// <summary>
        /// 选择语言：
        /// 00 - 中文；
        /// 01 - 英文；
        /// </summary>
        public static int Language = 0;

        /// <summary>
        /// 主窗体
        /// </summary>
        public static Client.Forms.Main.Form_Main Main = new Forms.Main.Form_Main();
    }
}
