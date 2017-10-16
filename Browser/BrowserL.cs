using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Browser
{
    [Serializable]
    public class BrowserL
    {
        private static BrowserL Browser { set; get; }

        public ObservableCollection<Bookmark> Bookmarks { set; get; }
        public ObservableCollection<History> History { set; get; }
        public bool IsSaveHistory { set; get; }
        private BrowserL()
        {

            Bookmarks = new ObservableCollection<Bookmark>();

          
            History = new ObservableCollection<History>();
            IsSaveHistory = true;
        }


        public static  BrowserL GEtInstatce()
        {
            if (Browser == null)
            {
                
                if(File.Exists(@"D:\Study\ШАГ\С#\New\WPF\Browser\Browser\bin\Debug\sett.xml"))
                {
                Des();
                }
                else
                Browser = new BrowserL();
            }
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

        ~BrowserL()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BrowserL));

            xmlSerializer.Serialize(new FileStream("sett.xml", FileMode.Create), Browser);
        }
        private static void Des()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BrowserL));

            Browser = xmlSerializer.Deserialize(new FileStream("sett.xml", FileMode.Open)) as BrowserL;
        }



    }
}
