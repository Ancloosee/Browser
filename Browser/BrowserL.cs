using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser
{
    public class BrowserL
    {
        private static BrowserL Browser { set; get; }

        public ObservableCollection<Bookmark> Bookmarks { set; get; }
        public ObservableCollection<History> History { set; get; }

        private BrowserL()
        {
            Bookmarks = new ObservableCollection<Bookmark>();

            Bookmarks.Add(new Bookmark("http://mixpromo.co/search/%D0%96%D0%B5%D0%BA%D0%B0+%D0%9A%D0%A2%D0%BE+%D0%A2%D0%90%D0%9C+%5B%D0%93%D0%A0%D0%A3%D0%97%5D"));
            History = new ObservableCollection<History>();
        }


        public static  BrowserL GEtInstatce()
        {
            if (Browser == null)
                Browser = new BrowserL();
            return Browser;
        }

        public void AddBookmarks(Bookmark newBookmarks)
        {
            Bookmarks.Add(newBookmarks);
        }
        public void AddHistory(History newHistory)
        {
            History.Add(newHistory);
        }






    }
}
