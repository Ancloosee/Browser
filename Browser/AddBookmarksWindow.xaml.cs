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
using System.Windows.Shapes;

namespace Browser
{
    /// <summary>
    /// Interaction logic for AddBookmarksWindow.xaml
    /// </summary>
    public partial class AddBookmarksWindow : Window
    {
        public AddBookmarksWindow(string URL,string Name=null)
        {
            InitializeComponent();
            this.URLTB.Text = URL;

            if (Name == null)
                this.NameTB.Text = URL;
            else
                this.NameTB.Text = Name;

           
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            BrowserL.GEtInstatce().AddBookmarks(new Bookmark(this.URLTB.Text, NameTB.Text));
            MessageBox.Show("Закладка добавленна");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
