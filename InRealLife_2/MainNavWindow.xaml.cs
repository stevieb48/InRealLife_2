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

/*
 * This GUI is the main menu for the scenario builder which allows the user to create a scenario form, edit a scenario form, 
 * delete an entire scenario, or preview a scenario.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: MainWindow.xaml.cs
 * version: 1.0
 */

namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for MainNavWindow.xaml
    /// </summary>
    public partial class MainNavWindow : NavigationWindow
    {
        public MainNavWindow()
        {
            InitializeComponent();
        }
    }
}
