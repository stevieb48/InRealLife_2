﻿using ClassInterfaces;
using LogicLayer;
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

/*
 * This GUI ...
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
        //
        private const string CREATE_MODE = "Create";
        private const string EDIT_MODE = "Edit";
        private const int EMPTY_INT = 0;

        //
        private string mode = CREATE_MODE;

        // create new repository
        private Repository pieceRepository = new Repository();

        //
        private IScenarioPiece currentPiece;

        public CreateNewOverall(IScenarioPiece piece)
        {
            InitializeComponent();
            this.currentPiece = piece;
            SetMode();
            InitializeForm();
        }

        // initialize the form
        private void InitializeForm()
        {
            txtbxScenarioTitle.Text = currentPiece.Name;
            txtbxScenarioDescription.Text = currentPiece.Description;
        }

        //
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // if mode is edit
            if (mode == EDIT_MODE)
            {
                // update scenario table with new textbox data
                pieceRepository.UpdateExisingPiece(currentPiece);
            }
            else if (mode == CREATE_MODE)
            {
                // insert new
                pieceRepository.InsertNewPiece(currentPiece);

                // change mode
                mode = EDIT_MODE;
            }
        }

        //
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            // call button to go back

        }

        //
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            // exit to main menu
        }

        //
        private void SetMode()
        {
            // pieceID is not empty which means edit a piece
            if (currentPiece.ID != EMPTY_INT)
            {
                mode = EDIT_MODE;
                EnableEditModeButtons();
            }
            else
            {
                mode = CREATE_MODE;
                EnableCreateModeButtons();
            }
        }

        //
        private void EnableEditModeButtons()
        {
            lblTitle.Content = (EDIT_MODE + " " + currentPiece.GetType().ToString().Split('.')[1]);
        }

        //
        private void EnableCreateModeButtons()
        {
            lblTitle.Content = (CREATE_MODE + " " + currentPiece.GetType().ToString().Split('.')[1]);
        }
    }
}