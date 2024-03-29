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
        string imagePath, audioPath, image, justFileName;

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

        public CreateStage(IScenarioPiece currentPiece, IScenarioPiece currentScenario)
        {
            InitializeComponent();

            // set piece
            this.currentStage = new Stage(currentPiece.ID);

            // set mode based on information in piece
            SetMode();            

            // when mode is create mode
            if (mode == CREATE_MODE)
            {
                populateComboBox();
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
                string imageFilePath = System.IO.Path.Combine(currentDirectory, "mediaFiles", currentStage.ImageFilePath);
                imagePath = imageFilePath;
                audioPath = System.IO.Path.Combine(currentDirectory, "mediaFiles", currentStage.AudioFilePath);
                if(File.Exists(imageFilePath))
                {
                    imageBox.Source = new BitmapImage(new Uri(imageFilePath, UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("The assigned image for this Stage does not exist on your computer. \n Would you like to use a different one?", "IRL- Error Message", MessageBoxButton.YesNo);

                    switch(result)
                    {
                        case MessageBoxResult.Yes:
                            uploadImage();
                            break;

                        case MessageBoxResult.No:
                            break;
                    }
                                            
                }

                if (File.Exists(audioPath))
                {
                    MediaPlayer mp = new MediaPlayer();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("The assigned audio file for this Stage does not eist on your computer. \n Would you like to use a different one?", "IRL- Error Message", MessageBoxButton.YesNo);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            uploadAudio();
                            break;

                        case MessageBoxResult.No:
                            break;
                    }

                }



                // scenario combo box
                populateComboBox();

                // next stage answer 1 combo box
                //SetAnswer1ComboBox(currentStage);

                // next stage answer 2 combo box
                //SetAnswer2ComboBox(currentStage);

                scenarioSelect.Text = currentScenario.Name;
               

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

        private void uploadImage()
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
                    justFileName = System.IO.Path.GetFileName(op.FileName);
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

        private void uploadAudio()
        {
            bool done = true;
            do
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "MP3 files (*.mp3; *.wav)|*.mp3; *.wav|All files (*.*)|*.*";
                if (op.ShowDialog() == true)
                {
                    justFileName = System.IO.Path.GetFileName(op.FileName);
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

                //checks if a scenario has been selected, doesn't allow save if not
                if(scenarioSelect.SelectedValue == null)
                {
                    MessageBox.Show("You must select a Scenario to attach the Stage to.");
                    return;
                }
                else
                {
                    Scenario newScenario = (Scenario)scenarioSelect.SelectedValue;
                    currentStage.ScenarioID = newScenario.ID;
                   
                }
                                
                currentStage.AudioFilePath = justFileName;
                currentStage.ImageFilePath = image;
                currentStage.Answer2 = answer2box.Text;
                currentStage.Answer1 = answer1box.Text;
                //sets answer next stage id to default value if null
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

                SetStage();

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
            this.NavigationService.Navigate(new StageMain((IScenarioPiece)scenarioSelect.SelectedValue));
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

        private void imageBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            uploadImage();
        }

        private void uploadAudioBtn_Click(object sender, RoutedEventArgs e)
        {
            uploadAudio();
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
                editStageRepository.Dispose();
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

        private void SetStage()
        {
            Stage answer1 = (Stage)answer1path.SelectedValue;
            Stage answer2 = (Stage)answer2path.SelectedValue;

            //checks if a scenario has been selected, doesn't allow save if not
            if (scenarioSelect.SelectedValue == null)
            {
                MessageBox.Show("You must select a Scenario to attach the Stage to.");
                return;
            }
            else
            {
                Scenario newScenario = (Scenario)scenarioSelect.SelectedValue;
                currentStage.ScenarioID = newScenario.ID;
            }
            currentStage.ID = currentStage.ID;
            currentStage.Name = titleBox.Text;
            currentStage.Description = descriptionBox.Text;
            currentStage.AudioFilePath = justFileName;
            currentStage.ImageFilePath = image;
            currentStage.Answer1 = answer1box.Text;
            if (answer1 == null)
            {
                currentStage.Ans1NextStagID = 1;
            }
            else
            {
                currentStage.Ans1NextStagID = answer1.ID;
            }
            currentStage.Answer2 = answer2box.Text;
            if (answer2 == null)
            {
                currentStage.Ans2NextStagID = 1;
            }
            else
            {
                currentStage.Ans2NextStagID = answer2.ID;
            }
        }
    }
}
