using Classes;
using ClassInterfaces;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Utilities;

/*
 * This GUI allows the user to create or edit scenarios.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/18/2018
 * file name: CreateNewOverall.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for CreateNewOverall.xaml
    /// </summary>
    public partial class CreateNewOverall : Page
    {
        // CONSTANTS
        private const string CREATE_MODE = "Create";
        private const string EDIT_MODE = "Edit";
        private const int EMPTY_INT = 0;

        // create new repository
        private Repository pieceRepository = new Repository();

        // mode variable set to create mode
        private string mode = CREATE_MODE;

        // forms scenario piece
        private IScenarioPiece currentPiece;

        public CreateNewOverall(int ID)
        {
            InitializeComponent();
            this.currentPiece = new Scenario(ID);
            InitializeForm();
        }

        // initialize the form
        private void InitializeForm()
        {
            // to determine if updating or inserting
            SetMode();
        }

        // when user clicks to save. checka the mode and does the appropriate
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UtilityMethods.ValInputString(txtbxScenarioTitle.Text) && UtilityMethods.ValInputString(txtbxScenarioDescription.Text))
            {
                try
                {
                    // if mode is edit
                    if (mode == EDIT_MODE)
                    {
                        // set current piece to new piece with data to change
                        this.currentPiece = new Scenario(this.currentPiece.ID, txtbxScenarioTitle.Text, txtbxScenarioDescription.Text);

                        //Repository repo = new Repository();
                        pieceRepository.UpdateExisingPiece(this.currentPiece);

                        //
                        MainMenu newMainMenu = new MainMenu();

                        //
                        this.NavigationService.Navigate(newMainMenu);
                    }
                    else if (mode == CREATE_MODE)
                    {
                        // set current piece to new piece with new info
                        this.currentPiece = new Scenario(txtbxScenarioTitle.Text, txtbxScenarioDescription.Text);

                        //Repository repo = new Repository();
                        pieceRepository.InsertNewPiece(this.currentPiece);

                        // change mode
                        mode = EDIT_MODE;

                        //
                        MainMenu newMainMenu = new MainMenu();

                        //
                        this.NavigationService.Navigate(newMainMenu);
                    }
                }
                catch (DbException ex)
                {
                    // exception thrown
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception ex)
                {
                    // exception thrown
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    // cleanup
                    pieceRepository.CleanUp();
                }
            }
            else
            {
                //
                MessageBox.Show("ERROR : Incorrect input ... try again");

                //
                txtbxScenarioTitle.Text = currentPiece.Name;
                txtbxScenarioDescription.Text = currentPiece.Description;
            }            
        }

        // to cancel this operation
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            // call button to go back
            this.NavigationService.GoBack();
        }

        // to exit the program
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // sets the mode to tell the form how to handle the data
        private void SetMode()
        {
            // pieceID is not empty which means edit a piece
            if (currentPiece.ID != EMPTY_INT)
            {
                mode = EDIT_MODE;
                EnableEditModeButtons();
            }
            else if (currentPiece.ID == EMPTY_INT)
            {
                mode = CREATE_MODE;
                EnableCreateModeButtons();
            }
        }

        // method to enable controls for edit mode
        private void EnableEditModeButtons()
        {
            //Repository pieceRepository = new Repository();
            lblTitle.Content = (EDIT_MODE + " " + currentPiece.GetType().ToString().Split('.')[1]);

            try
            {
                currentPiece = pieceRepository.GetPieceByID(currentPiece);
            }
            catch (DbException ex)
            {
                // exception thrown
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                // exception thrown
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // cleanup
                pieceRepository.CleanUp();
            }

            txtbxScenarioTitle.Text = currentPiece.Name;
            txtbxScenarioDescription.Text = currentPiece.Description;
        }

        // method to enable controls for create mode
        private void EnableCreateModeButtons()
        {
            //
            lblTitle.Content = (CREATE_MODE + " " + currentPiece.GetType().ToString().Split('.')[1]);
            txtbxScenarioTitle.Text = currentPiece.Name;
            txtbxScenarioDescription.Text = currentPiece.Description;
        }
    }
}