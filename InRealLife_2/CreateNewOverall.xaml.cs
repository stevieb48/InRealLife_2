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
        // create new repository
        //private Repository pieceRepository = new Repository();

        //
        //private IScenarioPiece currentPiece = new Scenario();

        //
        private const string CREATE_MODE = "create";
        private const string EDIT_MODE = "edit";

        //
        private string mode;

        public CreateNewOverall(int ID)
        {
            InitializeComponent();
            InitializeForm(ID);
        }

        // initialize the form
        private void InitializeForm(int ID)
        {
            // is ID null
            // load create mode

            // is ID not null
            //load edit mode

            // get piece info

            // enable buttons
        }

        //
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // if mode is edit
            // update scenario table with new textbox data
            //pieceRepository

            // if mode is create
            // insert new
            // pieceRepository
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

        private void EnableButtons()
        {

        }

        private void CreateMode()
        {
            // mode = Create
            mode = CREATE_MODE;

            // do stuff
        }

        private void EditMode()
        {
            // mode = Edit
            mode = EDIT_MODE;

            // load textboxes with information
            //DataTable resultingDT = pieceRepository.GetAllPiecesByType(this.currentPiece);
        }
    }
}