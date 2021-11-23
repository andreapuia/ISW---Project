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
using DentalOffice.Views;
using DentalOffice.ViewModels;
using DentalOffice.Models;
using DentalOffice.Models.DataAccesslayer;
using DentalOffice.Views.DoctorViews;

namespace DentalOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            string Name = this.nameBox.Text.ToString();
            string Password = this.passwordBox.Password.ToString();

            User user = UserDAL.GetUserPr(Name, Password);

            if(user is null)
            {
                MessageBox.Show("User account not found!", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else if(user.Role == Role.administrator)
            {
                AdministratorW adminWindow = new AdministratorW(user);
                adminWindow.Show();
                this.Close();
            }
            else
            {
                DoctorW doctorWindow = new DoctorW(user);
                doctorWindow.Show();
                this.Close();
            }

            
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}