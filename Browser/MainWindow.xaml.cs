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
            menuBookmarks.ItemsSource = BrowserL.GEtInstatce().Bookmarks;
            menuBookmarks.DisplayMemberPath = "Header";
           


            menuHistory.ItemsSource = BrowserL.GEtInstatce().History;
            menuHistory.DisplayMemberPath = "Header";
            


            
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WebBrowser)((TabItem) TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(AdressTextBox.Text);
            }
            catch(Exception ex)
            {
                string response = "https://www.google.com.ua/search?q=";
                 string[] TMP = AdressTextBox.Text.Split(",. ".ToCharArray());
                foreach (string v in TMP)
                    response += "+" + v;
                ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(response);   
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Browser.Refresh();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if(Browser.CanGoBack)
            {
                Browser.GoBack();
            }
        }

        private void GoForward_Click(object sender, RoutedEventArgs e)
        {
            if(Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }

        private void AddButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            TabControls.Items.Insert(TabControls.Items.Count - 1, new TabItem() { Header = "Вкладка " + Convert.ToString(TabControls.Items.Count), Content = new WebBrowser() { } }  );
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.Items.Count - 2]).Content).Navigated += writeHistory;
            
            ((TabItem)TabControls.Items[TabControls.Items.Count - 2]).MouseRightButtonDown += removeTab;


            TabControls.SelectedIndex = TabControls.Items.Count-2;
        }

        private void removeTab(object sender, MouseButtonEventArgs e)
        {
            
            TabControls.Items.RemoveAt(TabControls.SelectedIndex);
            if(!cheklastFocus())
                TabControls.SelectedIndex = TabControls.Items.Count - 2;
        }

        private void writeHistory(object sender, NavigationEventArgs e)
        {
            string URL = ((WebBrowser)sender).Source.ToString();
            string Header= ((WebBrowser)sender).Source.AbsoluteUri;
            BrowserL.GEtInstatce().AddHistory(new History(URL, Header));
        }

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

        private void Bookmarks_Click(object sender, RoutedEventArgs e)
        {

           AddBookmarksWindow win= new AddBookmarksWindow(((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Source.ToString());
            win.Show();           
        }
        private bool cheklastFocus()
        {
            if (TabControls.SelectedIndex == TabControls.Items.Count-1)
            {
                return false;
            }
            else
                return true;
        }

        private void menuBookmarks_Click(object sender, RoutedEventArgs e)
        {
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(((Bookmark)((MenuItem)e.OriginalSource).DataContext).URL);
        }

        private void menuHistory_Click(object sender, RoutedEventArgs e)
        {
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Navigate(((History)((MenuItem)e.OriginalSource).DataContext).URL);
        }
    }
}
