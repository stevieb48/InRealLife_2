﻿using Microsoft.Win32;
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

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for CreateScenario.xaml
    /// </summary>
    public partial class CreateScenario : Page
    {
        public CreateScenario()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imageBox.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void uploadAudioBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
               
            }

        }

        private void previewBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Stage name: " + titleBox.Text);
            Console.WriteLine("Stage description: " + descriptionBox.Text);
            Console.WriteLine("Answer 1: " + answer1box.Text);
            Console.WriteLine("Answer 2: " + answer2box.Text);
            Console.WriteLine("Image source: " + imageBox.Source.ToString());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            String insertString = "INSERT INTO Stage VALUE (" + titleBox.Text + "," + descriptionBox.Text + "," + "ScenarioID" + "," + "NULL" + "," + imageBox.Source.ToString() + ")";
            String insertanswer1 = "INSERT INTO Answer VALUE (Name" + "," + answer1box.Text + "," + " StageID" + ", " + "NextStageID" + ")";
            String insertanswer2 = "INSERT INTO Answer VALUE (Name" + "," + answer2box.Text + "," + " StageID" + ", " + "NextStageID" + ")";
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
