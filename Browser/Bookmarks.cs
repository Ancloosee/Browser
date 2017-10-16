using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser
{
    [Serializable]
    public class Bookmark
    {
        public string URL { set; get; }
        public string Header { set; get; }

        public Bookmark()
        {

        }

        public Bookmark(string URL,string Header=null)
        {
            this.URL = URL;
            if (Header == null)
                this.Header = URL;
            else
                this.Header = Header;
        }
    }
    [Serializable]
    public class History
    {
        public string URL { set; get; }
        public string Header { set; get; }

        public History()
        {

        }

        public History(string URL, string Header = null)
        {
            this.URL = URL;
            if (Header == null)
                this.Header = URL;
            else
                this.Header = Header;
        }
    }
}
