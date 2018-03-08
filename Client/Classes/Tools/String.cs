using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.Tools
{
    /// <summary>
    /// 常用工具
    /// </summary>
    class String
    {
        /// <summary>
        /// 用 mark 连接 strings 的指定开始到结束位置的字符串。
        /// </summary>
        /// <param name="strings">待连接的字符串</param>
        /// <param name="mark">连接符</param>
        /// <param name="bg">开始位置</param>
        /// <param name="ed">结束位置</param>
        /// <returns></returns>
        public static string Link(string[] strings, string mark, int bg = 0, int ed = 0)
        {
            if (strings == null || strings.Length == 0) { return ""; }
            if (ed <= 0) { ed = strings.Length - 1; }
            if (ed >= strings.Length) { ed = strings.Length - 1; }
            string res = strings[bg];
            for (int i = 1; i <= ed; i++)
            {
                res = res + "|" + strings[i];
            }
            return res;
        }

        /// <summary>
        /// 清除给定一行字符串左右两端的空格。
        /// </summary>
        /// <param name="line">一行字符串</param>
        /// <returns></returns>
        public static string ClearLRSpace(string line)
        {
            if (line == null || line.Length == 0) { return ""; }
            while (line.Length > 0 && line[0] == ' ')
            {
                line = line.Substring(1);
            }
            while (line.Length > 0 && line[line.Length - 1] == ' ')
            {
                line = line.Remove(line.Length - 1);
            }
            return line;
        }
    }
}
