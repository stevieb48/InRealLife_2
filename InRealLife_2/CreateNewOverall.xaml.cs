using ClassInterfaces;
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

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for CreateNewOverall.xaml
    /// </summary>
    public partial class CreateNewOverall : Page
    {
        //
        private const string CREATE_MODE = "create";
        private const string EDIT_MODE = "edit";

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

            //
            EnableButtons();
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
            else
            {
                // insert new
                pieceRepository.InsertNewPiece(currentPiece);
            }
        }

        //
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            // call button exit click

        }

        //
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            // exit to main menu
        }

        //
        private void SetMode()
        {
            // pieceID is not empty which means create a piece
            if (currentPiece.ID != 0)
            {
                mode = EDIT_MODE;
            }
        }

        //
        private void EnableButtons()
        {
            // if mode is edit
            if (mode == EDIT_MODE)
            {
                // update scenario table with new textbox data
                pieceRepository.UpdateExisingPiece(currentPiece);
            }
            else
            {
                // insert new
                pieceRepository.InsertNewPiece(currentPiece);
            }
        }
    }
}