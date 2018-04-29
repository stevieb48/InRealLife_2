using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Classes;
using ClassInterfaces;
using LogicLayer;

/*
 * This GUI ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: Running.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for Running.xaml
    /// </summary>
    public partial class Running : Page
    {
        // create new repository
        private Repository pieceRepository = new Repository();

        //
        private IScenarioPiece currentScenario;
        private Stage currentStage = new Stage();

        // flag to determine if this is the first run assume it is
        public static bool FirstRunFlag = true;

        //
        private string currentDirectory = Directory.GetCurrentDirectory();
        private MediaPlayer soundFX = new MediaPlayer();

        //
        public Running(int Scenario)
        {
            InitializeComponent();
            Start(Scenario);
        }

        //
        public void Start(int ScenarioId)
        {
            //
            try
            {
                if (!FirstRunFlag)
                {
                    //
                    currentStage = pieceRepository.GetNextStage(ScenarioId);

                    //
                    currentScenario = new Scenario(currentStage.ScenarioID);

                    //
                    currentScenario = pieceRepository.GetPieceByID(currentScenario);
                }
                else
                {
                    //
                    FirstRunFlag = false;

                    //
                    currentScenario = new Scenario(ScenarioId);

                    //
                    currentScenario = pieceRepository.GetPieceByID(currentScenario);

                    //
                    currentStage = pieceRepository.GetFirstStage(currentScenario.ID);
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

            //
            ScenarioName.Text = currentScenario.Name;
            StageDescription.Text = currentStage.Description;
            Text1.Text = currentStage.Answer1;
            Text2.Text = currentStage.Answer2;

            //***********************imageFileName*************************** 
            string imageFileName = currentStage.ImageFilePath;
            Console.WriteLine(imageFileName);
            string imageFilePath = System.IO.Path.Combine("mediaFiles\\", imageFileName);
            Console.WriteLine(imageFilePath);
            ImageBlock.Source = new BitmapImage(new Uri(imageFilePath, UriKind.RelativeOrAbsolute));

            //****************soundFileName************************* 
            string soundFileName = currentStage.AudioFilePath;
            string soundFilePath = System.IO.Path.Combine(currentDirectory, "mediaFiles", soundFileName);
            soundFX.Open(new Uri(soundFilePath, UriKind.RelativeOrAbsolute));
            soundFX.Play();
        }

        // answer A
        private void BtnChoiceA_Click(object sender, RoutedEventArgs e)
        {
            //
            Running run = new Running(currentStage.Ans1NextStagID);

            //
            this.NavigationService.Navigate(run);
        }

        // answer B
        private void BtnChoiceB_Click(object sender, RoutedEventArgs e)
        {
            //
            Running run = new Running(currentStage.Ans2NextStagID);

            //
            this.NavigationService.Navigate(run);
        }

        // exit button click event
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //
            this.NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
        }
    }
}