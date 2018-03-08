using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.FilesModel
{
    class Text : BaseFile
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private Config.Configs content;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Config.Configs Content
        {
            set { content = value; }
            get { return content; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Text()
        {
            initThis();
        }
        public Text(string url) : base(url)
        {
            initThis();
        }

        private void initThis()
        {
            if (content == null) { content = new Config.Configs(); }
            content.Clear();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Load()
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Url);
                while (!sr.EndOfStream)
                {
                    string line = Tools.String.ClearLRSpace(sr.ReadLine());
                    if (line.Length == 0) { continue; }
                    content.Add(new Config.Config(line));
                }
                sr.Close();
                OK = true;
            }
            catch
            {
                OK = false;
            }
        }
        public void Save()
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(Url, false);
                foreach (Config.Config c in content.Content)
                {
                    sw.WriteLine(c.ToString());
                }
                sw.Close();
                OK = true;
            }
            catch
            {
                OK = false;
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
