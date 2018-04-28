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
using System.Data.Common;

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for CreateStage.xaml
    /// </summary>
    public partial class CreateStage : Page
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string imagePath, audioPath, image;

        // CONSTANTS
        private const string CREATE_MODE = "Create";
        private const string EDIT_MODE = "Edit";
        private const int EMPTY_INT = 0;

        // mode variable set to create mode
        private string mode = CREATE_MODE;

        Stage currentStage = new Stage();
        IScenarioPiece currentPiece = new Scenario();

        Repository editStageRepository = new Repository();

        public CreateStage()
        {
            InitializeComponent();
            populateComboBox();
        }

        public CreateStage(int ID)
        {
            InitializeComponent();

            // set piece
            this.currentStage = new Stage(ID);

            // set mode based on information in piece
            SetMode();

            populateComboBox();

            // scenario combo box
            SetScenarioComboBox(currentPiece);

            // next stage answer 1 combo box
            SetAnswer1ComboBox(currentStage);

            // next stage answer 2 combo box
            SetAnswer2ComboBox(currentStage);


            // when mode is create mode
            if (mode == CREATE_MODE)
            {

            }
            // when mode is edit mode
            else if (mode == EDIT_MODE)
            {
                // set controls with data from selected piece
                titleBox.Text = currentStage.Name;
                descriptionBox.Text = currentStage.Description;
                answer1box.Text = currentStage.Answer1;
                answer2box.Text = currentStage.Answer2;
                uploadAudioBtn.Content = currentStage.AudioFilePath;
                string imageFilePath = System.IO.Path.Combine( "mediaFiles\\", currentStage.ImageFilePath);
                imagePath = imageFilePath;
                audioPath = System.IO.Path.Combine("mediaFiles\\", currentStage.AudioFilePath);
                imageBox.Source = new BitmapImage(new Uri(imageFilePath, UriKind.RelativeOrAbsolute));
                titleBox.Text = currentStage.Name;

                scenarioSelect.SelectedItem = currentStage.ScenarioID;

                answer1path.SelectedItem = currentStage.Ans1NextStagID;

                answer2path.SelectedItem = currentStage.Ans1NextStagID;
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Combobox changed \n");
            IScenarioPiece currentPiece = new Stage();
            Scenario newScenario = (Scenario)scenarioSelect.SelectedValue;

            answer1path.Items.Clear();
            answer2path.Items.Clear();

            IScenarioPiece[] resultingList = editStageRepository.GetAllPiecesByType(currentPiece, newScenario.ID);
            if (resultingList.Length > 0)
            {
                for (int i = 0; i < resultingList.Length; i++)
                {
                    answer1path.Items.Add(resultingList[i]);
                    answer2path.Items.Add(resultingList[i]);
                }

                answer1path.DisplayMemberPath = "Name";
                answer2path.DisplayMemberPath = "Name";
            }
            else
            {
                answer1path.Items.Clear();
                answer2path.Items.Clear();
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
                    image = justFileName;
                    Console.WriteLine(image);
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
            Stage previewStage = new Stage(0, titleBox.Text, descriptionBox.Text, 0, audioPath, imagePath, answer1box.Text, 0, answer2box.Text, 0);

            PreviewWindow preview = new PreviewWindow(previewStage);
            preview.Show();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(mode);
            // check mode
            if (mode == CREATE_MODE)
            {
                Stage answer1 = (Stage) answer1path.SelectedValue;
                Stage answer2 = (Stage) answer2path.SelectedValue;
                currentStage.Name = titleBox.Text;
                currentStage.Description = descriptionBox.Text;
                Scenario newScenario = (Scenario) scenarioSelect.SelectedValue;

                currentStage.ScenarioID = newScenario.ID;
                currentStage.AudioFilePath = "NULL";
                currentStage.ImageFilePath = image;
                currentStage.Answer2 = answer2box.Text;
                currentStage.Answer1 = answer1box.Text;

                if (answer1 == null)
                {
                    currentStage.Ans1NextStagID = 1;
                }
                else
                {
                    currentStage.Ans1NextStagID = answer1.ID;
                }

                if (answer2 == null)
                {
                    currentStage.Ans2NextStagID = 1;
                }
                else
                {
                    currentStage.Ans2NextStagID = answer2.ID;
                }

                Console.WriteLine(currentStage.ImageFilePath);
                bool starterflag = false;

                // see if check box to make stage a starter is not checked
                if (chkbxMakeStarter.IsChecked == false)
                {
                    // save data
                    editStageRepository.SaveStageData(currentStage, starterflag);
                }
                // checkbox to make starter is checked
                else
                {
                    // change flag to true
                    starterflag = true;

                    // save data
                    editStageRepository.SaveStageData(currentStage, starterflag);
                }
            }
            // else if mode is edit mode
            else if (mode == EDIT_MODE)
            {
                //
                bool starterflag = false;

                // see if check box to make stage a starter is not checked
                if (chkbxMakeStarter.IsChecked == false)
                {
                    // save data
                    editStageRepository.SaveStageData(currentStage, starterflag);
                }
                // checkbox to make starter is checked
                else
                {
                    // change flag to true
                    starterflag = true;

                    // save data
                    editStageRepository.SaveStageData(currentStage, starterflag);
                }
            }
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

        // set mode to create mode or edit mode
        private void SetMode()
        {
            // pieceID is not empty which means edit a piece edit mode
            if (currentStage.ID != EMPTY_INT)
            {
                // set mode to edit
                mode = EDIT_MODE;

                // enable editbuttons
                EnableEditModeButtons();
            }
            // else the piece must be empty create mode
            else if (currentStage.ID == EMPTY_INT)
            {
                // set to create mode
                mode = CREATE_MODE;
            }
        }

        // method to enable controls for edit mode
        private void EnableEditModeButtons()
        {
            try
            {
                // grab information for current stage
                this.currentStage = editStageRepository.GetNextStage(currentStage.ID);

                // set checkbox starter to whether current stageID is a starter
                chkbxMakeStarter.IsChecked = editStageRepository.IsItStarter(currentStage.ID);
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
                editStageRepository.CleanUp();
            }
        }

        private void SetScenarioComboBox(IScenarioPiece currentPiece)
        {
            IScenarioPiece[] resultingList = editStageRepository.GetAllPiecesByType(currentPiece);
            if (resultingList.Length > 0)
            {
                for (int i = 0; i < resultingList.Length; i++)
                {
                    scenarioSelect.Items.Add(new Scenario { ID = resultingList[i].ID, Name = resultingList[i].Name, Description = resultingList[i].Description });
                }

                scenarioSelect.DisplayMemberPath = "Name";
                scenarioSelect.SelectionChanged += OnSelectedIndexChanged;
            }
            else
            {
                scenarioSelect.Items.Clear();
            }
        }

        private void SetAnswer1ComboBox(Stage currentPiece)
        {
            IScenarioPiece currentStageAnswer = currentPiece;
            IScenarioPiece[] resultingList = editStageRepository.GetAllPiecesByType(currentStageAnswer, currentPiece.ScenarioID);
            if (resultingList.Length > 0)
            {
                for (int i = 0; i < resultingList.Length; i++)
                {
                    answer1path.Items.Add(new Stage { ID = resultingList[i].ID, Name = resultingList[i].Name, Description = resultingList[i].Description });
                }

                answer1path.DisplayMemberPath = "Name";
                answer1path.SelectionChanged += OnSelectedIndexChanged;
            }
            else
            {
                answer1path.Items.Clear();
            }
        }

        private void SetAnswer2ComboBox(Stage currentPiece)
        {
            IScenarioPiece currentStageAnswer = currentPiece;
            IScenarioPiece[] resultingList = editStageRepository.GetAllPiecesByType(currentStageAnswer, currentPiece.ScenarioID);
            if (resultingList.Length > 0)
            {
                for (int i = 0; i < resultingList.Length; i++)
                {
                    answer2path.Items.Add(new Stage { ID = resultingList[i].ID, Name = resultingList[i].Name, Description = resultingList[i].Description });
                }

                answer2path.DisplayMemberPath = "Name";
                answer2path.SelectionChanged += OnSelectedIndexChanged;
            }
            else
            {
                answer2path.Items.Clear();
            }    
        }

        public void populateComboBox()
        {
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
                scenarioSelect.SelectionChanged += OnSelectedIndexChanged;
            }
            else
            {
                scenarioSelect.Items.Clear();
            }
        }
    }
}
