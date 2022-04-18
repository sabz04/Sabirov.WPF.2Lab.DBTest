﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace Sabirov.WPF._2Lab.DBTest
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static Login curLog = new Login();
        public Login()
        {
            MainWindow.user = null;
            InitializeComponent();
            curLog = this;
            Operations.GetUsersFromDBSQL();   
        }
        public static bool IsUserExists(string userName, string userPass)
        {
            DataTable dt = Operations.CreateZaprosSQLWITHRES($"Select * from Users where" +
                $" Pass = '{userPass}' and Name = '{userName}';");
            if (dt.Rows.Count > 0)
                return true;
            else
               return false; 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void AcceptBTN_Click(object sender, RoutedEventArgs e)
        {

            DataTable dt = Operations.CreateZaprosSQLWITHRES($"Select * from Users where" +
                $" Pass = '{PassTB.Text}' and Name = '{LoginTB.Text}';");
            
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь найден.");
                MainWindow.mainWindow.frame.Navigate(new InfoPanel());
                MainWindow.mainWindow.LoginPageBTN.Opacity = 1;
            } 
            else
                MessageBox.Show("Нет такого. Пройдите регистрацию."); 
        }
        
    }
}
