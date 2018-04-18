using System;
using System.Collections;
using System.Collections.Generic;
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
        private Repository repository = new Repository();

        //
        private IScenarioPiece currentScenario;
        private Stage currentStage = new Stage();
        private IScenarioPiece currentAnswer1;
        private IScenarioPiece currentAnswer2;

        public static bool FirstRunFlag = true;

        //DataHandler data = new DataHandler();

        public Running(int Scenario)
        {           
            InitializeComponent();
            Start(Scenario);
            ImageBlock.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\MediaFiles\\flat.tire.10.jpg", UriKind.Absolute));
        }

        public void Start(int ScenarioId)
        {
            if (!FirstRunFlag)
            {
                currentStage = repository.GetNextStage(ScenarioId);
                // scenarioID must be a stage id from an answer choice(stage.nextID)
                currentScenario = new Scenario(currentStage.ScenarioID);
                currentScenario = repository.GetPieceByID(currentScenario);

                currentAnswer1 = new Answer(currentStage.Answer1ID);
                currentAnswer1 = repository.GetPieceByID(currentAnswer1);
                currentAnswer2 = new Answer(currentStage.Answer2ID);
                currentAnswer2 = repository.GetPieceByID(currentAnswer2);
            }
            else
            {
                FirstRunFlag = false;

                currentScenario = new Scenario(ScenarioId);
                currentScenario = repository.GetPieceByID(currentScenario);
                currentStage = repository.GetFirstStage(currentScenario.ID);
                currentAnswer1 = new Answer(currentStage.Answer1ID);
                currentAnswer1 = repository.GetPieceByID(currentAnswer1);
                currentAnswer2 = new Answer(currentStage.Answer2ID);
                currentAnswer2 = repository.GetPieceByID(currentAnswer2);
            }

            //data.Intetialize(ScenarioId);
            ScenarioName.Text = currentScenario.Name;
            StageDescription.Text = currentStage.Description;
            Text1.Text = currentAnswer1.Description;
            Text2.Text = currentAnswer2.Description;           
        }

        /*
        public void Update(int AnswerNumber)
        {
            if (AnswerNumber == 1)
            {
                if (data.answer2.NextStageID == 0)
                {
                   // MainMenu main = new MainMenu();
                    //main.Show();
                    //Close();
                    this.NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
                }
                else
                {
                    data.Update(AnswerNumber);

                    Text1.Text = currentAnswer1.Description;
                    Text2.Text = currentAnswer2.Description;
                    StageDescription.Text = currentStage.Description;
                }
            }
            else if (AnswerNumber == 2)
            {
                if (data.answer2.NextStageID == 0)
                {
                   // MainMenu main = new MainMenu();
                    this.NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
                    //Close();
                }
                else
                {
                    data.Update(AnswerNumber);

                    Text1.Text = currentAnswer1.Description;
                    Text2.Text = currentAnswer2.Description;
                    StageDescription.Text = currentStage.Description;
                }
            }
        }
        */

        private void BtnChoiceA_Click(object sender, RoutedEventArgs e)
        {
            //Update(1);
            Running run = new Running(currentStage.Ans1NextStagID);
            this.NavigationService.Navigate(run);
        }

        private void BtnChoiceB_Click(object sender, RoutedEventArgs e)
        {
            //Update(2);
            Running run = new Running(currentStage.Ans2NextStagID);
            this.NavigationService.Navigate(run);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           // MainMenu main = new MainMenu();
            //main.Show();
            //Close();
            this.NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
        }
    }
}