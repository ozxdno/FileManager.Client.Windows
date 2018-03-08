using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.Support
{
    /// <summary>
    /// 所支持的文件后缀
    /// </summary>
    class Support
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private Resource.Enums.FileType type;
        private string extension;
        private string show;
        private string hide;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Resource.Enums.FileType Type
        {
            set { type = value; }
            get { return type; }
        }
        public string Extension
        {
            set { extension = value; }
            get { return extension; }
        }
        public string Show
        {
            set { show = value; }
            get { return show; }
        }
        public string Hide
        {
            set { hide = value; }
            get { return hide; }
        }

        public bool IsShow
        {
            get { return extension == show; }
        }
        public bool IsHide
        {
            get { return extension == hide; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Support()
        {
            initThis();
        }

        private void initThis()
        {
            type = Resource.Enums.FileType.Unsupport;
            extension = ".unsupport";
            show = "";
            hide = "";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
