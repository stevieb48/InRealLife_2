using Classes;
using DataLayer;
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
 * This GUI is the main menu for the Answer builder which allows the user to create a Answer form, edit a Answer form, 
 * delete an entire Answer, or preview a Answer.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/31/2018
 * file name: AnswerMainMenu.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for AnswerMainMenu.xaml
    /// </summary>
    public partial class AnswerMainMenu : Page
    {
        // create new database object
        DataBaseCommunication newDBComm = new DataBaseCommunication();

        public AnswerMainMenu()
        {
            InitializeComponent();
            InitializeForm();
        }

        // initialize the form
        private void InitializeForm()
        {
            // reset list box
            lstvwAnswers.Items.Clear();

            // enable create button
            // ***** change btnCreateAnswer, and btnEditAnswer(below) control back to true when edit Answer is incorporated ***********
            btnCreateAnswer.IsEnabled = false;

            btnDeleteAnswer.IsEnabled = false;
            btnPerformScenario.IsEnabled = false;

            // data table containing data from Answer table
            DataTable returnedAnswerTable = newDBComm.DisplayAllAnswers();

            // if data table has rows
            if (returnedAnswerTable.Rows.Count > 0)
            {
                // enable proper buttons
                AnswerListHasValues();

                // then add data to listbox
                AddDataToListBox(returnedAnswerTable);

                // sort

            }
            else
            {
                // else Answer list is empty
                AnswerListIsEmpty();
            }
        }

        // create Answer button click event
        private void BtnCreateAnswer_Click(object sender, RoutedEventArgs e)
        {

        }

        // delete Answer button click event
        private void BtnDeleteAnswer_Click(object sender, RoutedEventArgs e)
        {
            // CONSTANT used when comparing to the number 
            const int EMPTY_DB_RESULT = 0;

            int AnswerRowsDeleted = 0;

            // grab selected Answer and put into variable
            Answer selectedAnswer = (Answer)lstvwAnswers.SelectedItem;

            // run query to delete selected Answer from DB
            AnswerRowsDeleted = newDBComm.DeleteSelectedAnswer(selectedAnswer.ID);

            // if Answer was deleted
            if (AnswerRowsDeleted > EMPTY_DB_RESULT)
            {
                // Show user which Answer was deleted
                MessageBox.Show("The Answer called " + selectedAnswer.Name + " was deleted");

                // reset form
                InitializeForm();
            }
            else
            {
                // Show user error while Answer was deleted
                MessageBox.Show("Error deleting Answer");

                // reset form
                InitializeForm();
            }
        }

        // preview Answer button click event
        private void BtnPerformScenario_Click(object sender, RoutedEventArgs e)
        {
            //ScenarioPage newScenarioPage = new ScenarioPage();
            //this.NavigationService.Navigate(newScenarioPage);
        }

        // method for form behaviors if list is empty
        private void AnswerListIsEmpty()
        {
            btnEditAnswer.IsEnabled = false;
            btnDeleteAnswer.IsEnabled = false;
            btnPerformScenario.IsEnabled = false;
        }

        // method for form behaviors if list has data
        private void AnswerListHasValues()
        {
            // ***** change this btnEditAnswer control back to true when edit Answer is incorporated ***********
            btnEditAnswer.IsEnabled = false;
        }

        // method to add Answer data to Answer list box
        private void AddDataToListBox(DataTable returnedAnswerTable)
        {
            // loop to put Answer names from data table into Answer listbox items
            for (int i = 0; i < returnedAnswerTable.Rows.Count; i++)
            {
                // add data table results to list view
                lstvwAnswers.Items.Add(new Answer { ID = Int32.Parse(returnedAnswerTable.Rows[i][0].ToString()), Name = returnedAnswerTable.Rows[i][1].ToString() });
            }
        }

        // has Answers listbox selection changed
        private void LstvwAnswers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButtonsWhenAnswerSelected();
        }

        //
        private void EnableButtonsWhenAnswerSelected()
        {
            // enable buttons
            AnswerListHasValues();

            // enable perform Answer button
            btnPerformScenario.IsEnabled = true;

            // enable delete Answer button
            btnDeleteAnswer.IsEnabled = true;
        }

        private void BtnExitAnswerBuilder_Click(object sender, RoutedEventArgs e)
        {
            ManagmentOptions managmentOptions = new ManagmentOptions();
            this.NavigationService.Navigate(managmentOptions);
        }       
    }
}