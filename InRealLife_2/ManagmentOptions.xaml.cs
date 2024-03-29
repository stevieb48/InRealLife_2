﻿using Classes;
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
    public partial class ManagmentOptions : Page
    {
        //
        public ManagmentOptions()
        {
            InitializeComponent();
        }

        //
        private void ManageScenariosBtn_Click(object sender, RoutedEventArgs e)
        {
            // call appropriate menu
            //ScenarioMainMenu scenarioMainMenu = new ScenarioMainMenu();

            // switch navigation to main menu
            //scenarioMainMenu.Show();
        }

        //
        private void ManageStagesBtn_Click(object sender, RoutedEventArgs e)
        {
            // call appropriate menu
            //StageMainMenu StageMainMenu = new StageMainMenu();

            // switch navigation to main menu
            //StageMainMenu.Show();
        }

        //
        private void ManageAnswersBtn_Click(object sender, RoutedEventArgs e)
        {
            // call appropriate menu
            //AnswerMainMenu answerMainMenu = new AnswerMainMenu();

            // switch navigation to main menu
            //answerMainMenu.Show();
        }

        //
        private void BtnExitManagement_Click(object sender, RoutedEventArgs e)
        {
            //TitleScreen titleScreen = new TitleScreen();
            //this.NavigationService.Navigate(titleScreen);
        }
    }
}