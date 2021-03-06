﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// 启动该应用
    /// </summary>
    static class Start
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Test();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Client.Data.Form_Main);
        }

        /// <summary>
        /// 测试代码
        /// </summary>
        static void Test()
        {
            Classes.FilesModel.Text p = Data.Pvini;
            p.Load();
        }
    }
}
