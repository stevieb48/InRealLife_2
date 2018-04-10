using Classes;
using LogicLayerInterfaces;
using System.Windows;
using System.Windows.Controls;

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for TitleScreen.xaml
    /// </summary>
    public partial class ManagmentOptions : Page
    {
        public ManagmentOptions()
        {
            InitializeComponent();
        }

        private void ManageScenariosBtn_Click(object sender, RoutedEventArgs e)
        {
            // make scenario piece of type scenario
            //IScenarioPiece scenario = new Scenario();

            //ScenarioMainMenu scenarioMainMenu = new ScenarioMainMenu(scenario);
            //this.NavigationService.Navigate(scenarioMainMenu);
        }

        //
        private void ManageStagesBtn_Click(object sender, RoutedEventArgs e)
        {
            // make scenario piece of type stage
            //IScenarioPiece stage = new Stage();

            //StageMainMenu stageMainMenu = new StageMainMenu(stage);
            //this.NavigationService.Navigate(stageMainMenu);
        }

        //
        private void ManageAnswersBtn_Click(object sender, RoutedEventArgs e)
        {
            // make scenario piece of type answer
            //IScenarioPiece answer = new Answer();

            //AnswerMainMenu answerMainMenu = new AnswerMainMenu(answer);
            //this.NavigationService.Navigate(answerMainMenu);
        }

        private void BtnExitManagement_Click(object sender, RoutedEventArgs e)
        {
            //TitleScreen titleScreen = new TitleScreen();
            //this.NavigationService.Navigate(titleScreen);
        }
    }
}