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
            return (field == null || field.Length == 0) ? value : (field + " = " + value);
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
        public bool AddToTop(bool item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = (item ? "1" : "0") + "|" + value;
            Value = v;
            ok = true;
            return ok;
        }
        public bool AddToTop(int item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = item.ToString() + "|" + value;
            Value = v;
            ok = true;
            return ok;
        }
        public bool AddToTop(long item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = item.ToString() + "|" + value;
            Value = v;
            ok = true;
            return ok;
        }
        public bool AddToTop(double item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = item.ToString() + "|" + value;
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
        public bool AddToBottom(bool item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = value + "|" + (item ? "1" : "0");
            Value = v;
            ok = true;
            return ok;
        }
        public bool AddToBottom(int item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = value + "|" + item.ToString();
            Value = v;
            ok = true;
            return ok;
        }
        public bool AddToBottom(long item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = value + "|" + item.ToString();
            Value = v;
            ok = true;
            return ok;
        }
        public bool AddToBottom(double item)
        {
            //if (item == null) { ok = false; return ok; }
            string v = value + "|" + item.ToString();
            Value = v;
            ok = true;
            return ok;
        }

        public bool DeleteFirstItem()
        {
            if (items == null || items.Length == 0) { ok = false; return false; }
            Value = Tools.String.Link(items, "|", 1);
            return ok = true;
        }
        public bool DeleteLastItem()
        {
            if (items == null || items.Length == 0) { ok = false; return false; }
            Value = Tools.String.Link(items, "|", 0, items.Length - 1);
            ok = true;
            return true;
        }

        public string GetString_Field()
        {
            return field;
        }
        public string GetString()
        {
            ok = true;
            return value;
        }
        public string GetString(int index)
        {
            if (items == null) { ok = false; return ""; }
            if (index < 0 || index >= items.Length) { ok = false; return ""; }
            ok = true;
            return items[index];
        }
        public List<string> GetStringList()
        {
            if (items == null) { ok = false; return new List<string>(); }
            ok = true;
            return items.ToList();
        }
        public bool GetBool_Field()
        {
            try
            {
                ok = true;
                return int.Parse(field) != 0;
            }
            catch
            {
                ok = false;
                return false;
            }
        }
        public bool GetBool()
        {
            try
            {
                ok = true;
                return int.Parse(value) != 0;
            }
            catch
            {
                ok = false;
                return false;
            }
        }
        public bool GetBool(int index)
        {
            if (items == null) { ok = false; return false; }
            if (index < 0 || index >= items.Length) { ok = false; return false; }

            try
            {
                ok = true;
                return int.Parse(items[index]) != 0;
            }
            catch
            {
                ok = false;
                return false;
            }
        }
        public List<bool> GetBoolList()
        {
            if (items == null) { ok = false; return new List<bool>(); }
            List<bool> res = new List<bool>();
            foreach (string s in items)
            {
                try
                {
                    res.Add(int.Parse(s) != 0);
                }
                catch
                {
                    ok = false;
                    return res;
                }
            }
            return res;
        }
        public int GetInt_Field()
        {
            try
            {
                ok = true;
                return int.Parse(field);
            }
            catch
            {
                ok = false;
                return 0;
            }
        }
        public int GetInt()
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
        public int GetInt(int index)
        {
            if (items == null) { ok = false; return 0; }
            if (index < 0 || index >= items.Length) { ok = false; return 0; }

            try
            {
                ok = true;
                return int.Parse(items[index]);
            }
            catch
            {
                ok = false;
                return 0;
            }
        }
        public List<int> GetIntList()
        {
            if (items == null) { ok = false; return new List<int>(); }
            List<int> res = new List<int>();
            foreach (string s in items)
            {
                try
                {
                    res.Add(int.Parse(s));
                }
                catch
                {
                    ok = false;
                    return res;
                }
            }
            return res;
        }
        public long GetLong_Field()
        {
            try
            {
                ok = true;
                return long.Parse(field);
            }
            catch
            {
                ok = false;
                return 0;
            }
        }
        public long GetLong()
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
        public long GetLong(int index)
        {
            if (items == null) { ok = false; return 0; }
            if (index < 0 || index >= items.Length) { ok = false; return 0; }

            try
            {
                ok = true;
                return long.Parse(items[index]);
            }
            catch
            {
                ok = false;
                return 0;
            }
        }
        public List<long> GetLongList()
        {
            if (items == null) { ok = false; return new List<long>(); }
            List<long> res = new List<long>();
            foreach (string s in items)
            {
                try
                {
                    res.Add(long.Parse(s));
                }
                catch
                {
                    ok = false;
                    return res;
                }
            }
            return res;
        }
        public double GetDouble_Field()
        {
            try
            {
                ok = true;
                return double.Parse(field);
            }
            catch
            {
                ok = false;
                return 0;
            }
        }
        public double GetDouble()
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
        public double GetDouble(int index)
        {
            if (items == null) { ok = false; return 0; }
            if (index < 0 || index >= items.Length) { ok = false; return 0; }

            try
            {
                ok = true;
                return double.Parse(items[index]);
            }
            catch
            {
                ok = false;
                return 0;
            }
        }
        public List<double> GetDoubleList()
        {
            if (items == null) { ok = false; return new List<double>(); }
            List<double> res = new List<double>();
            foreach (string s in items)
            {
                try
                {
                    res.Add(double.Parse(s));
                }
                catch
                {
                    ok = false;
                    return res;
                }
            }
            return res;
        }

        public string FetchFirst_String()
        {
            if (items == null || items.Length == 0) { ok = false; return ""; }
            string s = GetString(0);
            if (ok) { DeleteFirstItem(); }
            return s;
        }
        public bool FetchFirst_Bool()
        {
            if (items == null || items.Length == 0) { ok = false; return false; }
            bool b = GetBool(0);
            if (ok) { DeleteFirstItem(); }
            return b;
        }
        public int FetchFirst_Int()
        {
            if (items == null || items.Length == 0) { ok = false; return 0; }
            int s = GetInt(0);
            if (ok) { DeleteFirstItem(); }
            return s;
        }
        public long FetchFirst_Long()
        {
            if (items == null || items.Length == 0) { ok = false; return 0; }
            long s = GetLong(0);
            if (ok) { DeleteFirstItem(); }
            return s;
        }
        public double FetchFirst_Double()
        {
            if (items == null || items.Length == 0) { ok = false; return 0; }
            double s = GetDouble(0);
            if (ok) { DeleteFirstItem(); }
            return s;
        }
        public string FetchLast_String()
        {
            if (items == null || items.Length == 0) { ok = false; return ""; }
            string s = GetString(items.Length - 1);
            if (ok) { DeleteLastItem(); }
            return s;
        }
        public bool FetchLast_Bool()
        {
            if (items == null || items.Length == 0) { ok = false; return false; }
            bool b = GetBool(items.Length - 1);
            if (ok) { DeleteLastItem(); }
            return b;
        }
        public int FetchLast_Int()
        {
            if (items == null || items.Length == 0) { ok = false; return 0; }
            int s = GetInt(items.Length - 1);
            if (ok) { DeleteLastItem(); }
            return s;
        }
        public long FetchLast_Long()
        {
            if (items == null || items.Length == 0) { ok = false; return 0; }
            long s = GetLong(items.Length - 1);
            if (ok) { DeleteLastItem(); }
            return s;
        }
        public double FetchLast_Double()
        {
            if (items == null || items.Length == 0) { ok = false; return 0; }
            double s = GetDouble(items.Length - 1);
            if (ok) { DeleteLastItem(); }
            return s;
        }

        public void SetField(string field)
        {
            this.field = field;
            ok = true;
        }
        public void SetField(bool field)
        {
            this.field = field ? "1" : "0";
            ok = true;
        }
        public void SetField(int field)
        {
            this.field = field.ToString();
            ok = true;
        }
        public void SetField(long field)
        {
            this.field = field.ToString();
            ok = true;
        }
        public void SetField(double field)
        {
            this.field = field.ToString();
            ok = true;
        }

        public void SetValue(string value)
        {
            this.value = value;
            ok = true;
        }
        public void SetValue(bool value)
        {
            this.value = value ? "1" : "0";
            ok = true;
        }
        public void SetValue(int value)
        {
            this.value = value.ToString();
            ok = true;
        }
        public void SetValue(long value)
        {
            this.value = value.ToString();
            ok = true;
        }
        public void SetValue(double value)
        {
            this.value = value.ToString();
            ok = true;
        }
        public void SetValue(List<string> value)
        {
            if (value == null) { ok = false; return; }
            this.Items = value.ToArray();
            ok = true;
        }
        public void SetValue(List<bool> value)
        {
            if (value == null) { ok = false; return; }
            List<string> items = new List<string>();
            foreach (bool i in value)
            {
                items.Add(i ? "1" : "0");
            }
            ok = true;
            SetValue(items);
        }
        public void SetValue(List<int> value)
        {
            if (value == null) { ok = false; return; }
            List<string> items = new List<string>();
            foreach (int i in value)
            {
                items.Add(i.ToString());
            }
            ok = true;
            SetValue(items);
        }
        public void SetValue(List<long> value)
        {
            if (value == null) { ok = false; return; }
            List<string> items = new List<string>();
            foreach (int i in value)
            {
                items.Add(i.ToString());
            }
            ok = true;
            SetValue(items);
        }
        public void SetValue(List<double> value)
        {
            if (value == null) { ok = false; return; }
            List<string> items = new List<string>();
            foreach (int i in value)
            {
                items.Add(i.ToString());
            }
            ok = true;
            SetValue(items);
        }

        public void SetItem(int index, string item)
        {
            if (item == null) { ok = false; return; }
            if (items == null) { ok = false; return; }
            if (index < 0 || index >= items.Length) { ok = false; return; }

            string[] temp = items;
            temp[index] = item;
            Items = temp;
            ok = true;
        }
        public void SetItem(int index, bool item)
        {
            //if (item == null) { ok = false; return; }
            if (items == null) { ok = false; return; }
            if (index < 0 || index >= items.Length) { ok = false; return; }

            string[] temp = items;
            temp[index] = item ? "1" : "0";
            Items = temp;
            ok = true;
        }
        public void SetItem(int index, int item)
        {
            //if (item == null) { ok = false; return; }
            if (items == null) { ok = false; return; }
            if (index < 0 || index >= items.Length) { ok = false; return; }

            string[] temp = items;
            temp[index] = item.ToString();
            Items = temp;
            ok = true;
        }
        public void SetItem(int index, long item)
        {
            //if (item == null) { ok = false; return; }
            if (items == null) { ok = false; return; }
            if (index < 0 || index >= items.Length) { ok = false; return; }

            string[] temp = items;
            temp[index] = item.ToString();
            Items = temp;
            ok = true;
        }
        public void SetItem(int index, double item)
        {
            //if (item == null) { ok = false; return; }
            if (items == null) { ok = false; return; }
            if (index < 0 || index >= items.Length) { ok = false; return; }

            string[] temp = items;
            temp[index] = item.ToString();
            Items = temp;
            ok = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
