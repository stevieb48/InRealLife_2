using Microsoft.Win32;
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
using Classes;
using ClassInterfaces;
using LogicLayer;
using System.IO;

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for CreateStage.xaml
    /// </summary>
    public partial class CreateStage : Page
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string imagePath, audioPath;

        public CreateStage()
        {
            InitializeComponent();
            Repository pieceRepository = new Repository();
            IScenarioPiece currentPiece = new Scenario();

            IScenarioPiece[] resultingList = pieceRepository.GetAllPiecesByType(currentPiece);
            if (resultingList.Length > 0)
            {
                for (int i = 0; i < resultingList.Length; i++)
                {
                    scenarioSelect.Items.Add(new Scenario { ID = resultingList[i].ID, Name = resultingList[i].Name, Description = resultingList[i].Description });
                }

                scenarioSelect.DisplayMemberPath = "Name";
            }
            else
            {

            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool done = true;
            do
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                if (op.ShowDialog() == true)
                {
                    imageBox.Source = new BitmapImage(new Uri(op.FileName));
                    imagePath = op.FileName;
                    string justFileName = System.IO.Path.GetFileName(op.FileName);
                    string saveFilePath = System.IO.Path.Combine(currentDirectory, "mediaFiles", justFileName);
                    if (File.Exists(saveFilePath))
                    {
                        MessageBoxResult result = MessageBox.Show(justFileName + " already exists.\n\n Would you like to use it in this stage?", "IRL- Error Message", MessageBoxButton.YesNoCancel);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                justFileName = System.IO.Path.GetFileName(op.FileName);
                                done = true;
                                break;
                            case MessageBoxResult.No:
                                done = false;
                                break;
                            case MessageBoxResult.Cancel:
                                justFileName = null;
                                done = true;
                                break;
                        }
                    }
                    else
                        File.Copy(op.FileName, saveFilePath);
                }
            } while (!done);
        }

        private void uploadAudioBtn_Click(object sender, RoutedEventArgs e)
        {
            bool done = true;
            do
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "MP3 files (*.mp3; *.wav)|*.mp3; *.wav|All files (*.*)|*.*";
                if (op.ShowDialog() == true)
                {
                    string justFileName = System.IO.Path.GetFileName(op.FileName);
                    audioPath = op.FileName;
                    string saveFilePath = System.IO.Path.Combine(currentDirectory, "mediaFiles", justFileName);
                    if (File.Exists(saveFilePath))
                    {
                        MessageBoxResult result = MessageBox.Show(justFileName + " already exists.\n\n Would you like to use it in this scenario?", "IRL- Error Message", MessageBoxButton.YesNoCancel);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                justFileName = System.IO.Path.GetFileName(op.FileName);
                                done = true;
                                break;
                            case MessageBoxResult.No:
                                done = false;
                                break;
                            case MessageBoxResult.Cancel:
                                justFileName = null;
                                done = true;
                                break;
                        }
                    }
                    else
                        File.Copy(op.FileName, saveFilePath);
                }
            } while (!done);

        }

        private void previewBtn_Click(object sender, RoutedEventArgs e)
        {
            /* Console.WriteLine("Stage name: " + titleBox.Text);
             Console.WriteLine("Stage description: " + descriptionBox.Text);
             Console.WriteLine("Answer 1: " + answer1box.Text);
             Console.WriteLine("Answer 2: " + answer2box.Text);
             Console.WriteLine("Image source: " + imageBox.Source.ToString());
             Scenario newScenario = (Scenario)scenarioSelect.SelectedValue;
             Console.WriteLine("ID = : " + newScenario.ID);*/

            Stage previewStage = new Stage(0, titleBox.Text, descriptionBox.Text, 0, audioPath, imagePath, answer1box.Text, 0, answer2box.Text, 0);
            
            PreviewWindow preview = new PreviewWindow(previewStage);
            preview.Show();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            String insertString = "INSERT INTO Stage VALUE ('" + titleBox.Text + "','" + descriptionBox.Text + "'," + "ScenarioID" + "," + "'NULL'" + ",'" + imageBox.Source.ToString() + "')";
            String insertanswer1 = "INSERT INTO Answer VALUE (Name" + ",'" + answer1box.Text + "'," + " StageID" + ", " + "NextStageID" + ")";
            String insertanswer2 = "INSERT INTO Answer VALUE (Name" + ",'" + answer2box.Text + "'," + " StageID" + ", " + "NextStageID" + ")";

            Answer a1 = new Answer();
            Answer a2 = new Answer();

            Stage newStage  = new Stage();
            newStage.Name = titleBox.Text;
            newStage.Description = descriptionBox.Text;
            Scenario newScenario = (Scenario)scenarioSelect.SelectedValue;
            newStage.ScenarioID = newScenario.ID;
            newStage.AudioFilePath = "NULL";
            newStage.ImageFilePath = imageBox.Source.ToString();
            newStage.Answer1 = answer1box.Text;
            newStage.Ans1NextStagID = 0;
            newStage.Answer2 = answer2box.Text;
            newStage.Ans2NextStagID = 0;


        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public ComboBox ScenarioSelect
        {
            get => scenarioSelect;
            set => scenarioSelect = value;
        }
    }
}
