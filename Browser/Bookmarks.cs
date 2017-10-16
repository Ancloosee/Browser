using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser
{
   public class Bookmark
    {
        public string URL { set; get; }
        public string Header { set; get; }


        public Bookmark(string URL,string Header=null)
        {
            this.URL = URL;
            if (Header == null)
                this.Header = URL;
            else
                this.Header = Header;






        }
    }

    public class History
    {
        public string URL { set; get; }
        public string Header { set; get; }


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
