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
        private BaseFile father;
        private BaseFile son;
        private BaseFile left;
        private BaseFile right;
        private string url;

        private long length;
        private long modify;
        private long score;

        private bool ok;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool OK
        {
            set { ok = value; }
            get { return ok; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
