using System.Data;
using System.Windows;
using System.Windows.Controls;
using LogicLayer;
using ClassInterfaces;
using Classes;
using System;

/*
 * This GUI is the main menu for each scenario piece which allows the user to create a new piece,
 * edit selected piece, delete selected piece, perform selected.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: MainMenu.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        // CONSTANTS
        private const string SCENARIO_MODE = "Scenario";
        private const string STAGE_MODE = "Stage";
        private const int EMPTY_INT = 0;

        // Flag variable for current mode by default it is set to Scenario Mode
        private string mode = SCENARIO_MODE;

        // create new repository
        private Repository pieceRepository = new Repository();

        // new piece
        private IScenarioPiece currentPiece = new Scenario();

        // constructor
        public MainMenu()
        {
            InitializeComponent();
            //this.currentPiece = piece;
            SetMode();
            InitializeForm();
        }

        // initialize the form
        private void InitializeForm()
        {
            // reset list box
            lstvwScenarioPieces.Items.Clear();

            // enable create button
            // ***** change btnCreateNew, and btnEditExisting(below) control back to true when edit piece is incorporated ***********

            btnDeleteSelected.IsEnabled = false;
            btnPerformSelected.IsEnabled = false;

            // data table containing data from results table
            IScenarioPiece[] resultingList = pieceRepository.GetAllPiecesByType(currentPiece);

            // if data table has rows
            if (resultingList.Length > 0)
            {
                // enable proper buttons
                ScenarioListHasValues();

                // then add data to listbox
                AddDataToListBox(resultingList);
            }
            else
            {
                // else list is empty
                ScenarioPieceListIsEmpty();
            }

            // set label content to specific piece type
            lblCurrentList.Content = ("Current " + mode + " List");
            lblTitle.Content = (mode + " Management");
            btnExitMenu.Content = ("Exit " + mode + " Management");
        }

        // exit builder button click event
        private void BtnExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // create new piece button click event
        private void BtnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            IScenarioPiece scenario = new Scenario();
            CreateNewOverall newCreateNewOverall = new CreateNewOverall(scenario.ID);
            this.NavigationService.Navigate(newCreateNewOverall);
        }

        // delete selected button click event
        private void BtnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            // grab selected piece and put into variable
            IScenarioPiece selectedPiece = (IScenarioPiece)lstvwScenarioPieces.SelectedItem;

            // run query to delete selected piece from DB
            int rowsaffected = pieceRepository.DeleteExistingPiece(selectedPiece);

            // if piece was deleted
            if (rowsaffected > EMPTY_INT)
            {
                // Show user which piece was deleted
                MessageBox.Show("The piece called " + selectedPiece.Name + " was deleted");

                // reset form
                InitializeForm();
            }
            else
            {
                // Show user the error if piece was not deleted
                MessageBox.Show("Error deleting " + selectedPiece.Name);

                // reset form
                InitializeForm();
            }
        }

        // perform selected piece button click event
        private void BtnPerformSelected_Click(object sender, RoutedEventArgs e)
        {
            // grab selected piece and put into variable
            IScenarioPiece selectedPiece = (IScenarioPiece)lstvwScenarioPieces.SelectedItem;

            Running run = new Running(selectedPiece.ID);
            this.NavigationService.Navigate(run);
            //run.Show();

            // hide main menu form form
            //this.Hide();
        }

        // method for form behaviors if list is empty
        private void ScenarioPieceListIsEmpty()
        {
            btnEditSelected.IsEnabled = false;
            btnDeleteSelected.IsEnabled = false;
            btnPerformSelected.IsEnabled = false;
        }

        // method for form behaviors if list has data
        private void ScenarioListHasValues()
        {
            // ***** change this btnEditSelected control back to true when edit piece is incorporated ***********
            btnEditSelected.IsEnabled = false;
        }

        // method to add piece data to list box
        private void AddDataToListBox(IScenarioPiece[] resultingList)
        {
            for (int i = 0; i < resultingList.Length; i++)
            {
                // add data table results to list view
                lstvwScenarioPieces.Items.Add(new Scenario { ID = resultingList[i].ID, Name = resultingList[i].Name, Description = resultingList[i].Description });
            }
        }

        // has listbox selection changed
        private void LstvwScenarioPieces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButtonsWhenPieceSelected();
        }

        // method to enable appropriate buttons when item in list is selected
        private void EnableButtonsWhenPieceSelected()
        {
            // enable buttons
            ScenarioListHasValues();

            // enable perform button
            btnPerformSelected.IsEnabled = true;

            btnDeleteSelected.IsEnabled = true;
            btnEditSelected.IsEnabled = true;
        }

        // method to edit the selected item in the list
        private void BtnEditSelected_Click(object sender, RoutedEventArgs e)
        {
            // grab selected piece and put into variable
            IScenarioPiece selectedPiece = (IScenarioPiece)lstvwScenarioPieces.SelectedItem;
            CreateNewOverall newCreateNewOverall = new CreateNewOverall(selectedPiece.ID);
            this.NavigationService.Navigate(newCreateNewOverall);
        }

        private void SetMode()
        {
            // pieceID is not empty which means edit a piece
            if (currentPiece.GetType().ToString().Split('.')[1] != SCENARIO_MODE)
            {
                mode = STAGE_MODE;
                //EnableEditModeButtons();
            }
            else
            {
                mode = SCENARIO_MODE;
                //EnableCreateModeButtons();
            }
        }

        private void BtnSwitchMode_Click(object sender, RoutedEventArgs e)
        {
            //IScenarioPiece stage = new Stage();
            StageMain newStageMain = new StageMain();
            this.NavigationService.Navigate(newStageMain);
            //this.NavigationService.Navigate(new Uri("StageMain.xaml", UriKind.Relative));
        }
    }
}