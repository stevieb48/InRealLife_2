﻿using System.Data;
using System.Windows;
using System.Windows.Controls;
using LogicLayer;
using ClassInterfaces;
using Classes;
using System;
using System.Data.Common;

/*
 * This GUI is the main menu for each stage piece which allows the user to create a new piece,
 * edit selected piece, delete selected piece, perform selected.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: StageMain.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for StageMain.xaml
    /// </summary>
    public partial class StageMain : Page
    {
        // CONSTANTS
        private const string SCENARIO_MODE = "Scenario";
        private const string STAGE_MODE = "Stage";
        private const int EMPTY_INT = 0;

        // default mode
        private string mode = STAGE_MODE;

        // create new repository
        private Repository pieceRepository = new Repository();

        // new piece
        private IScenarioPiece currentPiece = new Stage();
        private IScenarioPiece selectedScenario = new Scenario();

        //
        public StageMain(IScenarioPiece incomingScenario)
        {
            this.selectedScenario = incomingScenario;
            InitializeComponent();
            SetMode();
            InitializeForm(selectedScenario);
        }

        // initialize the form
        private void InitializeForm(IScenarioPiece selectedScenario)
        {
            // reset list box
            lstvwScenarioPieces.Items.Clear();

            btnDeleteSelected.IsEnabled = false;
            btnPerformSelected.IsEnabled = false;

            //
            try
            {
                // data table containing data from results table
                //IScenarioPiece[] resultingList = pieceRepository.GetAllPiecesByType(selectedScenario);****************old code*************
                IScenarioPiece[] resultingList = pieceRepository.GetAllStagesByScenarioID(selectedScenario);


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
                pieceRepository.Dispose();
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
            //
            CreateStage newCreateStage = new CreateStage();

            //
            this.NavigationService.Navigate(new Uri("CreateStage.xaml", UriKind.Relative));
        }

        // delete selected button click event
        private void BtnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            // grab selected piece and put into variable
            IScenarioPiece selectedPiece = (IScenarioPiece)lstvwScenarioPieces.SelectedItem;

            //
            try
            {
                // run query to delete selected piece from DB
                int rowsaffected = pieceRepository.DeleteExistingPiece(selectedPiece);

                // if piece was deleted
                if (rowsaffected > EMPTY_INT)
                {
                    // Show user which piece was deleted
                    MessageBox.Show("The piece called " + selectedPiece.Name + " was deleted");
                }
                else
                {
                    // Show user the error if piece was not deleted
                    MessageBox.Show("Error deleting " + selectedPiece.Name);
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
                pieceRepository.Dispose();
            }

            // reset form
            InitializeForm(selectedScenario);
        }

        // perform selected piece button click event
        private void BtnPerformSelected_Click(object sender, RoutedEventArgs e)
        {
            // grab selected piece and put into variable
            IScenarioPiece selectedPiece = (IScenarioPiece)lstvwScenarioPieces.SelectedItem;

            //
            Running run = new Running(selectedPiece.ID);

            //
            this.NavigationService.Navigate(run);
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
            //
            btnEditSelected.IsEnabled = false;
        }

        // method to add piece data to list box
        private void AddDataToListBox(IScenarioPiece[] resultingList)
        {
            for (int i = 0; i < resultingList.Length; i++)
            {
                // add data table results to list view
                lstvwScenarioPieces.Items.Add(new Stage { ID = resultingList[i].ID, Name = resultingList[i].Name, Description = resultingList[i].Description });
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
            btnEditSelected.IsEnabled = true;
            btnDeleteSelected.IsEnabled = true;
        }

        // method to edit the selected item in the list
        private void BtnEditSelected_Click(object sender, RoutedEventArgs e)
        {
            // grab selected piece and put into variable
            IScenarioPiece selectedPiece = (IScenarioPiece)lstvwScenarioPieces.SelectedItem;

            //
            CreateStage newCreateStage = new CreateStage(selectedPiece, selectedScenario);

            //
            this.NavigationService.Navigate(newCreateStage);
        }

        // set mode type
        private void SetMode()
        {
            // pieceID is a stage
            if (currentPiece.GetType().ToString().Split('.')[1] == STAGE_MODE)
            {
                // set mode to stage
                mode = STAGE_MODE;
            }
            else
            {
                // set mode to scenario
                mode = SCENARIO_MODE;
            }
        }

        // button switch mode clikc event
        private void BtnSwitchMode_Click(object sender, RoutedEventArgs e)
        {
            // call new main menu
            MainMenu newMainMenu = new MainMenu();

            // switch navigation
            this.NavigationService.Navigate(newMainMenu);
        }
    }
}