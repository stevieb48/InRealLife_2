using Classes;
using ClassInterfaces;
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

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for TitlePage.xaml
    /// </summary>
    public partial class TitlePage : Page
    {
        public TitlePage()
        {
            InitializeComponent();
        }


        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            //IScenarioPiece scenario = new Scenario();
            MainMenu newMainMenu = new MainMenu();
            this.NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
        }

      

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
