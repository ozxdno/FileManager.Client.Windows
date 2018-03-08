using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// 各种需要用到的类的实例化；数据存储区；
    /// </summary>
    static class Data
    {
        /// <summary>
        /// pv.ini
        /// </summary>
        public static Classes.FilesModel.Text Pvini = new Classes.FilesModel.Text(Classes.Tools.Url.GetExePath() + "\\pv.ini");



        /// <summary>
        /// 主窗体实例
        /// </summary>
        public static Forms.Main.Form_Main Form_Main;
    }
}
