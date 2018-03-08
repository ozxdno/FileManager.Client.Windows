using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.Config
{
    /// <summary>
    /// 配置信息，采用域-值模型：Field - Values。如：Pixes = 1|2|3|4
    /// </summary>
    class Config
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private string field;
        private string value;
        private string[] items;
        private bool ok;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 域
        /// </summary>
        public string Field
        {
            set { field = value; }
            get { return field; }
        }
        /// <summary>
        /// 值
        /// </summary>
        public string Value
        {
            set
            {
                this.value = value;
                if (this.value == null || this.value.Length == 0) { items = new string[0]; return; }
                items = this.value.Split('|');
            }
            get
            {
                return value;
            }
        }
        /// <summary>
        /// 值的每一项
        /// </summary>
        public string[] Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                if (items == null || items.Length == 0) { this.value = ""; return; }
                this.value = Tools.String.Link(items, "|");
            }
        }
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool OK
        {
            set { ok = value; }
            get { return ok; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 生成一个空的域-值模型。
        /// </summary>
        public Config()
        {
            initThis();
        }
        /// <summary>
        /// 读取一行字符串为域-值模型。如：Pixes = 1|2|3|4。
        /// </summary>
        /// <param name="line">字符串</param>
        public Config(string line)
        {
            initThis();
            if (line == null || line.Length == 0) { return; }
            int idx = line.IndexOf('=');
            if (idx == -1)
            {
                field = "";
                Value = Tools.String.ClearLRSpace(line);
                return;
            }
            string f = line.Substring(0, idx);
            string v = line.Substring(idx + 1);
            field = Tools.String.ClearLRSpace(f);
            value = Tools.String.ClearLRSpace(v);
        }
        /// <summary>
        /// 利用域和值信息构造域-值模型。
        /// </summary>
        /// <param name="field">域</param>
        /// <param name="value">值</param>
        public Config(string field, string value)
        {
            initThis();
            if (field == null) { this.field = ""; } else { this.field = Tools.String.ClearLRSpace(field); }
            if (value == null) { Value = ""; } else { Value = Tools.String.ClearLRSpace(value); }
        }

        private void initThis()
        {
            field = "";
            value = "";
            items = new string[0];
            ok = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static Config ToThis(string s)
        {
            return new Config(s);
        }
        public override string ToString()
        {
            return field + " = " + value;
        }
        public void CopyReference(Config c)
        {
            this.field = c.field;
            this.value = c.value;
            this.items = c.items;
            this.ok = c.ok;
        }
        public void CopyValue(Config c)
        {
            CopyReference(c);
            items = new string[c.items.Length]; for (int i = 0; i < c.items.Length; i++) { items[i] = c.items[i]; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool AddToTop(string item)
        {
            if (item == null) { ok = false; return ok; }
            string v = item + "|" + value;
            Value = v;
            ok = true;
            return ok;
        }
        public bool AddToBottom(string item)
        {
            if (item == null) { ok = false; return ok; }
            string v = value + "|" + item;
            Value = v;
            ok = true;
            return ok;
        }
        public bool DeleteFirstItem()
        {
            Value = Tools.String.Link(items, "|", 1);
            return true;
        }
        public bool DeleteLastItem()
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
