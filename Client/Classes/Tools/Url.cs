using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.Tools
{
    class Url
    {
        /// <summary>
        /// 获取当前可执行文件的所在路径
        /// </summary>
        /// <returns></returns>
        public static string GetExePath()
        {
            return System.Windows.Forms.Application.StartupPath;
        }

        /// <summary>
        /// 获取 URL 指定文件的上一级路径，若 URL 指定为一文件夹，则为该文件夹的上一级文件夹。
        /// </summary>
        /// <param name="url">文件资源定位符</param>
        /// <returns></returns>
        public static string GetPath(string url)
        {
            if (url == null || url.Length == 0) { return ""; }
            int idx = url.LastIndexOf('\\');
            if (idx == -1) { return ""; }
            return url.Substring(0, idx);
        }
        /// <summary>
        /// 获取 URL 指定文件的文件名称，含后缀，不含路径。
        /// </summary>
        /// <param name="url">文件资源定位符</param>
        /// <returns></returns>
        public static string GetName(string url)
        {
            if (url == null || url.Length == 0) { return ""; }
            int idx = url.LastIndexOf('\\');
            if (idx == -1) { return url; }
            return url.Substring(idx + 1);
        }
        /// <summary>
        /// 获取 URL 指定文件的后缀
        /// </summary>
        /// <param name="url">文件资源定位符</param>
        /// <returns></returns>
        public static string GetExtension(string url)
        {
            if (url == null || url.Length == 0) { return ""; }
            int idx1 = url.LastIndexOf('\\');
            int idx2 = url.LastIndexOf('.');
            if (idx1 == -1 && idx2 == -1) { return ""; }
            if (idx1 == -1) { return url.Substring(idx2); }
            if (idx2 == -1) { return ""; }
            if (idx1 > idx2) { return ""; }
            return url.Substring(idx2);
        }
        /// <summary>
        /// 获取 URL 指定文件的文件名称，不含后缀，不含路径。
        /// </summary>
        /// <param name="url">文件资源定位符</param>
        /// <returns></returns>
        public static string GetNameWithoutExtension(string url)
        {
            if (url == null || url.Length == 0) { return ""; }
            int idx1 = url.LastIndexOf('\\');
            int idx2 = url.LastIndexOf('.');
            if (idx1 == -1 && idx2 == -1) { return url; }
            if (idx1 == -1) { return url.Substring(idx1 + 1); }
            if (idx2 == -1) { return url.Substring(0, idx2); }
            if (idx1 > idx2) { return url.Substring(idx1 + 1); }
            return url.Substring(idx1 + 1, idx2 - idx1 - 1);
        }
    }
}
