using Sabirov.WPF._2Lab.DBTest.Pages;
using System;
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
    /// Логика взаимодействия для InfoPanel.xaml
    /// </summary>
    public partial class InfoPanel : Page
    {
        public static InfoPanel infPan = new InfoPanel();
        
        public InfoPanel()
        {
            InitializeComponent();
            LoadUI();
            LoadUser();
            infPan = this;
            
                
        }
        private void LoadUI()
        {
            AdminBTN.Opacity = 0;
            MainWindow.mainWindow.RegPageBTN.IsEnabled = false;
            MainWindow.mainWindow.LoginPageBTN.IsEnabled = false;
            //if (MainWindow.user != null)
            //    return;
            Operations.SetUser(Login.curLog.LoginTB.Text,Login.curLog.PassTB.Text);
            MainWindow.mainWindow.BookPageBTN.Visibility = Visibility.Visible;
            MainWindow.mainWindow.InfoPageBTN.Visibility = Visibility.Visible;
            
        }
        private void LoadUser()
        {
            LoginTB.Text = MainWindow.user.Name;
            PassTB.Text = MainWindow.user.Pass;
            if (MainWindow.user.Role == "User")
                StatusLB.Text += $" = Пользователь";
            else if (MainWindow.user.Role == "Admin")
            {
                AdminBTN.Opacity = 1;
                StatusLB.Text += $" = Администратор";
            }
        }
        

        public static bool IsAdmin(string userName)
        {
            string role = "";
            DataTable tb = Operations.CreateZaprosSQLWITHRES($"Select Role from Users where Name = '{userName}'");
            foreach (DataRow item in tb.Rows)
                role = item.ItemArray[0].ToString(); 
            if(role == "Admin")
                return true;
            else
                return false;
        }
        public static bool IsUser(string userName)
        {
            string role = "";
            DataTable tb = Operations.CreateZaprosSQLWITHRES($"Select Role from Users where Name = '{userName}'");
            foreach (DataRow item in tb.Rows)
                role = item.ItemArray[0].ToString();

            if (role == "User")
                return true;
            else
                return false;
        }
        private void LogFormBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.BookPageBTN.Visibility = Visibility.Hidden;
            MainWindow.mainWindow.InfoPageBTN.Visibility = Visibility.Hidden;
            MainWindow.mainWindow.RegPageBTN.IsEnabled = true;
            MainWindow.mainWindow.LoginPageBTN.IsEnabled = true;
            MainWindow.mainWindow.frame.Navigate(new Login());
        }

        private void AdminBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new AdminPanel());
        }
    }
}
