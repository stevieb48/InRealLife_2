using Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

/*
 * This GUI is the main menu for the Stage builder which allows the user to create a Stage form, edit a Stage form, 
 * delete an entire Stage, or preview a Stage.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/31/2018
 * file name: StageMainMenu.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for StageMainMenu.xaml
    /// </summary>
    public partial class StageMainMenu : Page
    {
        // create new database object
        DBComm newDBComm = new DBComm();

        public StageMainMenu()
        {
            InitializeComponent();
            InitializeForm();
        }

        // initialize the form
        private void InitializeForm()
        {
            // reset list box
            lstvwStages.Items.Clear();

            // enable create button
            // ***** change btnCreateStage, and btnEditStage(below) control back to true when edit Stage is incorporated ***********
            btnCreateStage.IsEnabled = false;

            btnDeleteStage.IsEnabled = false;
            btnPerformScenario.IsEnabled = false;

            // data table containing data from Stage table
            DataTable returnedStageTable = newDBComm.DisplayAllStages();

            // if data table has rows
            if (returnedStageTable.Rows.Count > 0)
            {
                // enable proper buttons
                StageListHasValues();

                // then add data to listbox
                AddDataToListBox(returnedStageTable);

                // sort

            }
            else
            {
                // else Stage list is empty
                StageListIsEmpty();
            }
        }

        // create Stage button click event
        private void BtnCreateStage_Click(object sender, RoutedEventArgs e)
        {

        }

        // delete Stage button click event
        private void BtnDeleteStage_Click(object sender, RoutedEventArgs e)
        {
            // CONSTANT used when comparing to the number 
            const int EMPTY_DB_RESULT = 0;

            int StageRowsDeleted = 0;

            // grab selected Stage and put into variable
            Stage selectedStage = (Stage)lstvwStages.SelectedItem;

            // run query to delete selected Stage from DB
            StageRowsDeleted = newDBComm.DeleteSelectedStage(selectedStage.ID);

            // if Stage was deleted
            if (StageRowsDeleted > EMPTY_DB_RESULT)
            {
                // Show user which Stage was deleted
                MessageBox.Show("The Stage called " + selectedStage.Name + " was deleted");

                // reset form
                InitializeForm();
            }
            else
            {
                // Show user error while Stage was deleted
                MessageBox.Show("Error deleting Stage");

                // reset form
                InitializeForm();
            }
        }

        // preview Stage button click event
        private void BtnPerformScenario_Click(object sender, RoutedEventArgs e)
        {
            //ScenarioPage newScenarioPage = new ScenarioPage();
            //this.NavigationService.Navigate(newScenarioPage);
        }

        // method for form behaviors if list is empty
        private void StageListIsEmpty()
        {
            btnEditStage.IsEnabled = false;
            btnDeleteStage.IsEnabled = false;
            btnPerformScenario.IsEnabled = false;
        }

        // method for form behaviors if list has data
        private void StageListHasValues()
        {
            // ***** change this btnEditStage control back to true when edit Stage is incorporated ***********
            btnEditStage.IsEnabled = false;
        }

        // method to add Stage data to Stage list box
        private void AddDataToListBox(DataTable returnedStageTable)
        {
            // loop to put Stage names from data table into Stage listbox items
            for (int i = 0; i < returnedStageTable.Rows.Count; i++)
            {
                // add data table results to list view
                lstvwStages.Items.Add(new Stage { ID = Int32.Parse(returnedStageTable.Rows[i][0].ToString()), Name = returnedStageTable.Rows[i][1].ToString() });
            }
        }

        // has Stages listbox selection changed
        private void LstvwStages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButtonsWhenStageSelected();
        }

        //
        private void EnableButtonsWhenStageSelected()
        {
            // enable buttons
            StageListHasValues();

            // enable perform Stage button
            btnPerformScenario.IsEnabled = true;

            // enable delete Stage button
            btnDeleteStage.IsEnabled = true;
        }

        private void BtnExitStageBuilder_Click(object sender, RoutedEventArgs e)
        {
            ManagmentOptions managmentOptions = new ManagmentOptions();
            this.NavigationService.Navigate(managmentOptions);
        }
    }
}