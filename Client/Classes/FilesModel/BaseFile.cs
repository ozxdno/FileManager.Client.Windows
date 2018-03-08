using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes.FilesModel
{
    class BaseFile
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private long index;
        private object father;
        private object son;
        private object left;
        private object right;
        private string url;
        public Resource.Enums.FileType type;
        public Resource.Enums.FileState state;
        private long length;
        private long modify;
        private long score;

        private bool ok;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public long Index
        {
            set { index = value; }
            get { return index; }
        }

        public object Father
        {
            set { father = value; }
            get { return father; }
        }
        public object Son
        {
            set { son = value; }
            get { return son; }
        }
        public object Left
        {
            set { left = value; }
            get { return left; }
        }
        public object Right
        {
            set { right = value; }
            get { return right; }
        }

        public string Url
        {
            set { url = value; }
            get { return url; }
        }
        public string Path
        {
            get { return Tools.Url.GetPath(url); }
        }
        public string Name
        {
            get { return Tools.Url.GetName(url); }
        }
        public string NameWithoutExtension
        {
            get { return Tools.Url.GetNameWithoutExtension(url); }
        }
        public string Extension
        {
            get { return Tools.Url.GetExtension(url); }
        }

        public Resource.Enums.FileType Type
        {
            set { type = value; }
            get { return type; }
        }
        public Resource.Enums.FileState State
        {
            set { state = value; }
            get { return state; }
        }
        public long Length
        {
            set { length = value; }
            get { return length; }
        }
        public long Modify
        {
            set { modify = value; }
            get { return modify; }
        }
        public long Score
        {
            set { score = value; }
            get { return score; }
        }

        public bool OK
        {
            set { ok = value; }
            get { return ok; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public BaseFile()
        {
            initThis();
        }
        public BaseFile(string url)
        {
            if (System.IO.File.Exists(url))
            {
                initThis(new System.IO.FileInfo(url));
                return;
            }
            if (System.IO.Directory.Exists(url))
            {
                initThis(new System.IO.DirectoryInfo(url));
                return;
            }
            initThis();
            this.url = url;
        }
        public BaseFile(System.IO.FileInfo file)
        {
            initThis(file);
        }
        public BaseFile(System.IO.DirectoryInfo folder)
        {
            initThis(folder);
        }

        private void initThis()
        {
            index = -1;
            father = null;
            son = null;
            left = null;
            right = null;
            url = "";
            type = Resource.Enums.FileType.Unsupport;
            state = Resource.Enums.FileState.NotExisted;
            length = 0;
            modify = 0;
            score = 0;
            ok = true;
        }
        private void initThis(System.IO.FileInfo file)
        {
            if (!file.Exists) { initThis(); return; }

            url = file.FullName;
            //type
            state = Resource.Enums.FileState.Prepared;
            length = file.Length;
            modify = file.LastWriteTime.ToFileTime();
        }
        private void initThis(System.IO.DirectoryInfo folder)
        {
            if (!folder.Exists) { initThis(); return; }
            url = folder.FullName;
            //type
            state = Resource.Enums.FileState.Prepared;
            //length
            modify = folder.LastWriteTime.ToFileTime();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static BaseFile ToThis(string s)
        {
            Config.Config c = new Config.Config(s);
            BaseFile b = new BaseFile();
            b.index = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }
            b.father = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }
            b.son = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }
            b.left = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }
            b.right = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }
            b.url = c.FetchFirst_String();
            if (!c.OK) { b.OK = false; return b; }
            b.type = (Resource.Enums.FileType)c.FetchFirst_Int();
            if (!c.OK) { b.OK = false; return b; }
            b.state = (Resource.Enums.FileState)c.FetchFirst_Int();
            if (!c.OK) { b.OK = false; return b; }
            b.length = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }
            b.modify = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }
            b.score = c.FetchFirst_Long();
            if (!c.OK) { b.OK = false; return b; }

            return b;
        }
        public Config.Config ToConfig()
        {
            Config.Config c = new Config.Config();
            c.AddToBottom(index);
            c.AddToBottom(father == null ? "0" : (father is long ? father.ToString() : (((BaseFile)father).index.ToString())));
            c.AddToBottom(son == null ? "0" : (son is long ? son.ToString() : (((BaseFile)son).index.ToString())));
            c.AddToBottom(left == null ? "0" : (left is long ? left.ToString() : (((BaseFile)left).index.ToString())));
            c.AddToBottom(right == null ? "0" : (right is long ? right.ToString() : (((BaseFile)right).index.ToString())));
            c.AddToBottom(url);
            c.AddToBottom((int)type);
            c.AddToBottom((int)state);
            c.AddToBottom(length);
            c.AddToBottom(modify);
            c.AddToBottom(score);
            return c;
        }
        public override string ToString()
        {
            return ToConfig().ToString();
        }
        public object ToSpecific()
        {
            if (type == Resource.Enums.FileType.Unsupport)
            {
                return this;
            }
            if (type == Resource.Enums.FileType.Picture)
            {
                Picture p = new Picture();

            }

            return this; // default
        }

        public void SetNextIndex()
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
