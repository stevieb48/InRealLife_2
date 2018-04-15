using System.Data;
using System.Windows;
using System.Windows.Controls;
using LogicLayer;
using ClassInterfaces;
using Classes;

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
    public partial class ScenarioMainMenu : Window
    {
        // create new repository
        private Repository pieceRepository = new Repository();
        
        //
        private IScenarioPiece currentPiece = new Scenario();

        public ScenarioMainMenu()
        {
            InitializeComponent();
            InitializeForm();
            //this.currentPiece = new Answer(); 
        }

        // initialize the form
        private void InitializeForm()
        {
            // reset list box
            lstvwScenarioPieces.Items.Clear();

            // enable create button
            // ***** change btnCreateNew, and btnEditExisting(below) control back to true when edit piece is incorporated ***********
            btnCreateNew.IsEnabled = false;
            btnDeleteSelected.IsEnabled = false;
            btnPerformSelected.IsEnabled = false;

            // data table containing data from results table
            DataTable resultingDT = pieceRepository.GetAllPiecesByType(this.currentPiece);

            // if data table has rows
            if (resultingDT.Rows.Count > 0)
            {
                // enable proper buttons
                ScenarioListHasValues();
                    
                // then add data to listbox
                AddDataToListBox(resultingDT);
            }
            else
            {
                // else list is empty
                ScenarioPieceListIsEmpty();
            }

            // set label content to specific piece type
            lblCurrentList.Content = ("Current " + currentPiece.GetType().ToString().Split('.')[1] + " List");
            lblTitle.Content = (currentPiece.GetType().ToString().Split('.')[1] + " Management");
            btnExitMenu.Content = ("Exit " + currentPiece.GetType().ToString().Split('.')[1] + " Management");
        }

        // exit builder button click event
        private void BtnExitMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // create new piece button click event
        private void BtnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            // hide current form
            // this.Hide();

            // load form to edit piece
            // .show();
        }

        // delete selected button click event
        private void BtnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            // CONSTANT used when comparing to the number 
            const int EMPTY_DB_RESULT = 0;

            // grab selected piece and put into variable
            IScenarioPiece selectedPiece = (IScenarioPiece)lstvwScenarioPieces.SelectedItem;

            // run query to delete selected piece from DB
            int rowsaffected = pieceRepository.DeleteExistingPiece(selectedPiece);

            // if piece was deleted
            if (rowsaffected > EMPTY_DB_RESULT)
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
            Running run = new Running(1);
            run.Show();

            // hide main menu form form
            this.Hide();
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
        private void AddDataToListBox(DataTable results)
        {
            // loop to put pieces from data table into listbox items
            for (int i = 0; i < results.Rows.Count; i++)
            {
                // add data table results to list view
                lstvwScenarioPieces.Items.Add(new Scenario { ID = int.Parse(results.Rows[i][0].ToString()), Name = results.Rows[i][1].ToString() });
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
        }

        // method to edit the selected item in the list
        private void BtnEditSelected_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}