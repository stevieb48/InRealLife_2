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
using Utilities;

/*
 * This Page ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 4/23/2018
 * file name: Login.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class Login : Page
    {
        // CONSTANTS
        const string LOGIN_MODE = "login";
        const string CREATE_MODE = "create";

        private const string INVALIDLOGIN = "INVALID LOGIN";
        private const string NOT_FOUND = "NOT FOUND";

        // mode variable
        string mode = LOGIN_MODE;

        // create new repository
        private Repository accountsRepository = new Repository();

        //
        public Login()
        {
            InitializeComponent();
        }

        //
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // blank account
            IAccount loginAccount;
                
            // if textboxes are null
            if (txtbxLogin.Text != null || txtbxPassword.Text != null)
            {
                MessageBox.Show("ERROR : Must enter a username and password");
            }
            // try to login
            else if (UtilityMethods.ValInputString(txtbxLogin.Text) && UtilityMethods.ValInputString(txtbxPassword.Text))
            {
                // call the repo passing in login and password
                loginAccount = accountsRepository.LogIntoAccount(txtbxLogin.Text, txtbxPassword.Text);

                //
                if (loginAccount.Login == NOT_FOUND)
                {
                    //
                    MessageBox.Show("ERROR : " + loginAccount.Name);

                    // refresh form
                }
                //
                else if (loginAccount.Login == INVALIDLOGIN)
                {
                    //
                    MessageBox.Show("ERROR : " + loginAccount.Name);

                    // refresh form

                }
                //
                else if(loginAccount.Login == txtbxLogin.Text && loginAccount.Password == txtbxPassword.Text)
                {
                    // set mode to global

                    // change forms

                }
                //
                else
                {
                    //
                    MessageBox.Show("ERROR : unknown login failure");

                    // refresh form

                }
            }
            //
            else
            {
                //
                MessageBox.Show("ERROR : not valid input");

                // refresh form

            }
        }

        //
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        //
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}