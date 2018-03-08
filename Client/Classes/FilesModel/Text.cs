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
        private string url;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Config.Configs Content
        {
            set { content = value; }
            get { return content; }
        }
        public string Url
        {
            set { url = value; }
            get { return url; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Text()
        {
            initThis();
        }
        public Text(string url)
        {
            initThis();
            this.url = url;
        }

        private void initThis()
        {
            if (content == null) { content = new Config.Configs(); }
            content.Clear();
            url = "";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Load()
        {
            try
            {
                OK = true;
            }
            catch
            {
                OK = false;
            }
        }
        public void Save()
        {

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
