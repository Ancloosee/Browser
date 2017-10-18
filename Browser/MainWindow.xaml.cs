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
            Browser.Source = new Uri("https://www.google.com.ua/");
            ResourceDictionary resourceDict = Application.LoadComponent(new Uri(BrowserL.GEtInstatce().CurrentTheme, UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

       

      
        //add new Tab
        private void AddButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TabControls.Items.Insert(TabControls.Items.Count - 1, new TabItem(){ Header = "Вкладка " + Convert.ToString(TabControls.Items.Count), Content = new WebBrowser() { Source=new Uri("https://www.google.com.ua/")}, Style = ((TabItem)TabControls.Items[0]).Style }  );
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.Items.Count - 2]).Content).Navigated += Browsernavigated;
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
                return false;
            else
                return true;
        }


        private string GetTitle()
        {
            return ((dynamic)((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Document).Title;
        }

        //for write history
        private void Browsernavigated(object sender, NavigationEventArgs e)
        {
            if (BrowserL.GEtInstatce().IsSaveHistory)
            {
                string URL = ((WebBrowser)sender).Source.ToString();
                BrowserL.GEtInstatce().AddHistory(new History(URL, GetTitle()));
            }
             ((TabItem)TabControls.Items[TabControls.SelectedIndex]).Header = GetTitle();
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
                AddBookmarksWindow win = new AddBookmarksWindow(path,GetTitle());
                win.Show();
            }
            catch(NullReferenceException ex)
            {

            }
        }
        //GoForward
        private void GOForwardButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).CanGoForward)
            {
                ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).GoForward();
            }
        }
        //GoBack
        private void GoBackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).CanGoBack)
            {
                ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).GoBack();
            }
        }
        //Refresh
        private void RefreshButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // Browser.Refresh();
            ((WebBrowser)((TabItem)TabControls.Items[TabControls.SelectedIndex]).Content).Refresh();
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

