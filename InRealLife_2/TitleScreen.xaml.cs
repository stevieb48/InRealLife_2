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
    /// Interaction logic for TitleScreen.xaml
    /// </summary>
    public partial class TitleScreen : Page
    {
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void editScenarioBtnClick(object sender, RoutedEventArgs e)
        {
            ScenarioBuilderMain scenarioBuilder = new ScenarioBuilderMain();
            this.NavigationService.Navigate(scenarioBuilder);
        }

        private void playScenarioBtn_Click(object sender, RoutedEventArgs e)
        {
            ScenarioPage newScenarioPage = new ScenarioPage();
            this.NavigationService.Navigate(newScenarioPage);
        }

        // exit application click event
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}