using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Apis.Services;
using Google.Apis;
using Google.API.Search;
using Awesomium.Windows.Controls;
using HtmlAgilityPack;

namespace Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

      
        //add new Tab
        private void AddButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            TabControls.Items.Insert(TabControls.Items.Count - 1, new TabItem() { Header = "Вкладка " + Convert.ToString(TabControls.Items.Count), Content = new WebBrowser() { } }  );
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.Items.Count - 2]).Content).Navigated += writeHistory;
            
            ((TabItem)TabControls.Items[TabControls.Items.Count - 2]).MouseRightButtonDown += removeTab;


            TabControls.SelectedIndex = TabControls.Items.Count-2;
        }
        //remove Tab when RightMouseClick
        private void removeTab(object sender, MouseButtonEventArgs e)
        {
            
            TabControls.Items.RemoveAt(TabControls.SelectedIndex);
            if(!cheklastFocus())
                TabControls.SelectedIndex = TabControls.Items.Count - 2;
        }
        //for chek focus in last element
        private bool cheklastFocus()
        {
            if (TabControls.SelectedIndex == TabControls.Items.Count - 1)
            {
                return false;
            }
            else
                return true;
        }


        //for write history
        private void writeHistory(object sender, NavigationEventArgs e)
        {

            if (BrowserL.GEtInstatce().IsSaveHistory)
            {
                string URL = ((WebBrowser)sender).Source.ToString();
                HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(URL);
                HtmlNode node = doc.DocumentNode.SelectNodes(@"//title")[0];

                string Header = node.InnerText;
                BrowserL.GEtInstatce().AddHistory(new History(URL, Header));
            }
        }
        //for GO when EnterPress
        private void AdressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                try
                {
                    ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(AdressTextBox.Text);

                }
                catch (Exception ex)
                {

                    string response = "https://www.google.com.ua/search?q=";
                    string[] TMP = AdressTextBox.Text.Split(",. ".ToCharArray());
                    foreach (string v in TMP)
                        response += "+" + v;
                    ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(response);

                }
            }
        }

        private void menuBookmarks_Click(object sender, RoutedEventArgs e)
        {
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(((Bookmark)((MenuItem)e.OriginalSource).DataContext).URL);
        }

        private void menuHistory_Click(object sender, RoutedEventArgs e)
        {
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(((History)((MenuItem)e.OriginalSource).DataContext).URL);
        }

        //effects for button
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).Opacity = 0.5;
        }
        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).Opacity = 1;
        }
        
        //Bokmarks
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string path = ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Source.ToString();
                HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(path);
                HtmlNode node = doc.DocumentNode.SelectNodes(@"//title")[0];
                AddBookmarksWindow win = new AddBookmarksWindow(path,node.InnerText);
                win.Show();
            }
            catch(NullReferenceException ex)
            {

            }
        }
        //GoForward
        private void GOForwardButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Browser.CanGoForward)
           {
               Browser.GoForward();
           }
        }
        //GoBack
        private void GoBackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
        }
        //Refresh
        private void RefreshButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Browser.Refresh();
        }
        //GO
        private void GoButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

            try
            {
                ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(AdressTextBox.Text);
            }
            catch (Exception ex)
            {
                string response = "https://www.google.com.ua/search?q=";
                string[] TMP = AdressTextBox.Text.Split(",. ".ToCharArray());
                foreach (string v in TMP)
                    response += "+" + v;
                ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(response);
            }
        }

        private void menuSetting_Click(object sender, RoutedEventArgs e)
        {
            new SettingWindow().Show();
        }
    }
}

