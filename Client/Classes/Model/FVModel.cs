using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.Model
{
    /// <summary>
    /// 键-值 对模型。
    /// </summary>
    class FVModel
    {
        private string field;
        private string value;
        private List<string> items;
        private bool ok;

        /// <summary>
        /// 数据名
        /// </summary>
        public string Field
        {
            get { return field; }
            set { if (value == null) { field = ""; } else { field = value; } }
        }
        /// <summary>
        /// 数据值
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { if (value == null) { this.value = ""; } else { this.value = value; } }
        }
        /// <summary>
        /// 数据项
        /// </summary>
        public List<string> Items
        {
            get
            {
                if (items == null) { items = new List<string>(); }
                items.Clear();
                if (value == null) { return items; }
                items = value.Split('|').ToList();
                return items;
            }
        }
        /// <summary>
        /// 是否操作成功。
        /// </summary>
        public bool OK
        {
            get { return ok; }
        }

        /// <summary>
        /// 创建 FVModel。
        /// </summary>
        public FVModel()
        {
            Clear();
        }
        /// <summary>
        /// 创建 FVModel 并初始化。
        /// </summary>
        /// <param name="line">文本行</param>
        public FVModel(string line)
        {
            Clear();
            line = Tools.String.GetLineFromText(ref line);
            int idx = line.IndexOf('=');
            if (idx == -1)
            {
                Field = "";
                Value = line;
            }
            int cut1 = idx - 1;
            int cut2 = idx + 1;
            while (line[cut1] == ' ')
            {
                cut1--;
            }
            while (line[cut2] == ' ')
            {
                cut2++;
            }
            Field = line.Substring(0, cut1 + 1);
            Value = line.Substring(cut2);
        }
        /// <summary>
        /// 创建 FVModel 并初始化。
        /// </summary>
        /// <param name="field">数据名</param>
        /// <param name="value">数据值</param>
        public FVModel(string field, string value)
        {
            Clear();
            Field = field;
            Value = value;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            field = "";
            value = "";
            if (items == null) { items = new List<string>(); }
            items.Clear();
        }

        /// <summary>
        /// 获取 bool 类型的值。若错误，则本类的 OK 成员变量为 FALSE。
        /// </summary>
        /// <returns></returns>
        public bool getBool()
        {
            try
            {
                ok = true;
                return double.Parse(value) != 0;
            }
            catch
            {
                ok = false;
                return false;
            }
        }
        /// <summary>
        /// 获取 int 类型的值。若错误，则本类的 OK 成员变量为 FALSE。
        /// </summary>
        /// <returns></returns>
        public int getInt()
        {
            try
            {
                ok = true;
                return int.Parse(value);
            }
            catch
            {
                ok = false;
                return 0;
            }
        }
        /// <summary>
        /// 获取 long 类型的值。若错误，则本类的 OK 成员变量为 FALSE。
        /// </summary>
        /// <returns></returns>
        public long getLong()
        {
            try
            {
                ok = true;
                return long.Parse(value);
            }
            catch
            {
                ok = false;
                return 0;
            }

        }
        /// <summary>
        /// 获取 double 类型的值。若错误，则本类的 OK 成员变量为 FALSE。
        /// </summary>
        /// <returns></returns>
        public double getDouble()
        {
            try
            {
                ok = true;
                return double.Parse(value);
            }
            catch
            {
                ok = false;
                return 0;
            }

        }
        /// <summary>
        /// 获取 string 类型的值。若错误，则本类的 OK 成员变量为 FALSE。
        /// </summary>
        /// <returns></returns>
        public string getString()
        {
            ok = true;
            return Value;
        }
    }
}
