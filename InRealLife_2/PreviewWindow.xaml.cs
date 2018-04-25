using Classes;
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
using System.Windows.Shapes;

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        private MediaPlayer soundFX = new MediaPlayer();
        public PreviewWindow(Stage ps)
        {
            InitializeComponent();
            ScenarioName.Text = ps.Name;
            ImageBlock.Source = new BitmapImage(new Uri(ps.ImageFilePath, UriKind.RelativeOrAbsolute));
            StageDescription.Text = ps.Description;
            AnswerText1.Text = ps.Answer1;
            AnswerText2.Text = ps.Answer2;
            soundFX.Open(new Uri(ps.AudioFilePath, UriKind.RelativeOrAbsolute));
            soundFX.Play();

        }

        private void btnChoiceA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChoiceB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
