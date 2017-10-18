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
        
         [XmlIgnore]
        public ObservableCollection<string> styleList { set; get; }
        public bool IsSaveHistory { set; get; }

        private string currentTheme;
        public string CurrentTheme
        {
            set
            {
                if(!value.Contains(".xaml"))
                    currentTheme = string.Format("{0}{1}{2}", "Themes/", value, ".xaml");
                else
                {
                    currentTheme = value;
                }
            }
            get
            {
                return currentTheme;
            }

        }
        private BrowserL()
        {

            Bookmarks = new ObservableCollection<Bookmark>();
            History = new ObservableCollection<History>();
            IsSaveHistory = true;
            styleList = new ObservableCollection<string>();

            foreach(string item in Directory.GetFiles(@"D:\Study\ШАГ\С#\New\WPF\Browser\Browser\Themes"))
            {
               string  tmp= item.Replace(@"D:\Study\ШАГ\С#\New\WPF\Browser\Browser\Themes\", "");
                styleList.Add(tmp.Replace(".xaml", ""));
            }

            this.currentTheme = styleList[0];
        }
      
        
        public static  BrowserL GEtInstatce()
        {
            if (Browser == null)
            {
                
                if(File.Exists(@"D:\Study\ШАГ\С#\New\WPF\Browser\Browser\bin\Debug\sett.xml"))
                 Des();
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

      
        private static void Des()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BrowserL));

            Browser = xmlSerializer.Deserialize(new FileStream("sett.xml", FileMode.Open)) as BrowserL;
        }
        ~BrowserL()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BrowserL));

            xmlSerializer.Serialize(new FileStream("sett.xml", FileMode.Create), Browser);
        }


    }
}
