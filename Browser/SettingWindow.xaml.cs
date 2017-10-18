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
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
            this.StyleComboBox.SelectedIndex = BrowserL.GEtInstatce().styleList.IndexOf(BrowserL.GEtInstatce().CurrentTheme.Replace(@"Themes/", String.Empty).Replace(".xaml", String.Empty));
        }

        private void ClearHIstoryButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите очистить историю???","Очистить историю", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                BrowserL.GEtInstatce().History.Clear();
            
        }

        private void StyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // BrowserL.GEtInstatce().CurrentTheme = ((ComboBoxItem)StyleComboBox.SelectedItem).Content.ToString();
            BrowserL.GEtInstatce().CurrentTheme = ((string)StyleComboBox.SelectedItem);


            ResourceDictionary resourceDict = Application.LoadComponent(new Uri(BrowserL.GEtInstatce().CurrentTheme,UriKind.Relative)) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

        }

        
    }
}
