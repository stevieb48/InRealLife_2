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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class ManagmentOptions : Window
    {

        public IScenarioPiece Piece { get; set; }

        //
        public ManagmentOptions()
        {
            InitializeComponent();
        }

        //
        private void ManageScenariosBtn_Click(object sender, RoutedEventArgs e)
        {
            // make piece of type scenario
            Piece = new Scenario();

            // pass in the new piece to the main menu
            MainMenu mainMenu = new MainMenu(Piece);

            // switch navigation to main menu
            mainMenu.Show();

        }

        //
        private void ManageStagesBtn_Click(object sender, RoutedEventArgs e)
        {
            // make piece of type stage
            Piece = new Stage();

            // pass in the new piece to the main menu
            MainMenu mainMenu = new MainMenu(Piece);

            // switch navigation to main menu
            mainMenu.Show();
        }

        //
        private void ManageAnswersBtn_Click(object sender, RoutedEventArgs e)
        {
            // make piece of type answer
            Piece = new Answer();

            // pass in the new piece to the main menu
            MainMenu mainMenu = new MainMenu(Piece);

            // switch navigation to main menu
            mainMenu.Show();
        }

        //
        private void BtnExitManagement_Click(object sender, RoutedEventArgs e)
        {
            //TitleScreen titleScreen = new TitleScreen();
            //this.NavigationService.Navigate(titleScreen);
        }
    }
}