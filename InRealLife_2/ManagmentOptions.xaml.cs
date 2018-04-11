using Classes;
using ClassInterfaces;
using System.Windows;
using System.Windows.Controls;

/*
 * This GUI ....
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/05/2018
 * file name: ManagmentOptions.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for TitleScreen.xaml
    /// </summary>
    public partial class ManagmentOptions : Page
    {
        //
        IScenarioPiece piece;

        //
        public ManagmentOptions()
        {
            InitializeComponent();
        }

        //
        private void ManageScenariosBtn_Click(object sender, RoutedEventArgs e)
        {
            // make piece of type scenario
            piece = new Scenario();

            // pass in the new piece to the main menu
            MainMenu mainMenu = new MainMenu(piece);

            // switch navigation to main menu
            this.NavigationService.Navigate(mainMenu);
        }

        //
        private void ManageStagesBtn_Click(object sender, RoutedEventArgs e)
        {
            // make piece of type stage
            piece = new Stage();

            // pass in the new piece to the main menu
            MainMenu mainMenu = new MainMenu(piece);

            // switch navigation to main menu
            this.NavigationService.Navigate(mainMenu);
        }

        //
        private void ManageAnswersBtn_Click(object sender, RoutedEventArgs e)
        {
            // make piece of type answer
            piece = new Answer();

            // pass in the new piece to the main menu
            MainMenu mainMenu = new MainMenu(piece);

            // switch navigation to main menu
            this.NavigationService.Navigate(mainMenu);
        }

        //
        private void BtnExitManagement_Click(object sender, RoutedEventArgs e)
        {
            //TitleScreen titleScreen = new TitleScreen();
            //this.NavigationService.Navigate(titleScreen);
        }
    }
}