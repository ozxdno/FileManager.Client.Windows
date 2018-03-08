using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.Config
{
    /// <summary>
    /// Config 模型的集合
    /// </summary>
    class Configs
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private List<Config> content;
        private bool ok;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Config> Content
        {
            set { content = value; }
            get { return content; }
        }
        public bool OK
        {
            set { ok = value; }
            get { return ok; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Configs()
        {
            initThis();
        }

        private void initThis()
        {
            if (content == null) { content = new List<Config>(); }
            content.Clear();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int IndexOf(string field)
        {
            for (int i = 0; i < content.Count; i++) { if (content[i].Field == field) { return i; } }
            return -1;
        }
        public Config Search(string field)
        {
            ok = true;
            for (int i = 0; i < content.Count; i++) { if (content[i].Field == field) { return content[i]; } }
            ok = false;
            return new Config(field, "");
        }
        public Config Fetch(string field)
        {
            Config res = new Config(field, "");
            ok = true;
            for (int i = 0; i < content.Count; i++) { if (content[i].Field == field) { res = content[i]; content.RemoveAt(i); return res; } }
            ok = false;
            return res;
        }
        public void Add(Config c)
        {
            if (c == null) { ok = false; return; }
            ok = true;
            content.Add(c);
        }
        public void Delete(string field)
        {
            Fetch(field);
        }
        public void Clear()
        {
            if (content == null) { content = new List<Config>(); }
            content.Clear();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
