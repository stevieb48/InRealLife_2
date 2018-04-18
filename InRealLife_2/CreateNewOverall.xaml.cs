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

        public CreateNewOverall()
        {
            InitializeComponent();
            InitializeForm();
        }

        // initialize the form
        private void InitializeForm()
        {
            // load textboxes with information
            //DataTable resultingDT = pieceRepository.GetAllPiecesByType(this.currentPiece);

            // enable buttons

        }

        //
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // update scenario table with new textbox data
            //pieceRepository

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
    }
}