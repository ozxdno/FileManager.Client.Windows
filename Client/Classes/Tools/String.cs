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
        /// 从文本中获取第一行。
        /// </summary>
        /// <param name="text">指定文本</param>
        /// <param name="delete">是否删除第一行</param>
        /// <returns></returns>
        public static string GetLineFromText(ref string text, bool delete = false)
        {
            if(text == null || text.Length == 0)
            {
                return "";
            }
            int idx = 0;
            while(text[idx]!='\r' && text[idx]!='\n' && text[idx] != 0)
            {
                idx++;
            }
            string line = text.Substring(0, idx);
            if (delete)
            {
                text = text.Substring(idx);
                while (text.Length > 0 && (text[0] == '\r' || text[0] == '\n' || text[0] == 0))
                { text = text.Remove(0, 1); }
            }
            return text.Substring(0, idx);
        }
    }
}
