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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
            Operations.GetUsersFromDBSQL();
        }
        public static bool IsUserExists(string userName, string userPass)
        {
            DataTable dt = Operations.CreateZaprosSQLWITHRES($"Select * from Users where" +
                $" Pass = '{userPass}' and Name = '{userName}';");
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }
        private void AcceptBTN_Click(object sender, RoutedEventArgs e)
        {
            
            DataTable dt = Operations.CreateZaprosSQLWITHRES($"Select * from Users where Pass = '{PassTB.Text}' and Name = '{LoginTB.Text}';");
            
            if (dt.Rows.Count > 0)
                MessageBox.Show("Пользователь найден. Попытка регистрации прервана,перейдите во вкладку авторизации.");
            else
            {
                Operations.CreateZaprosSQL($"insert into Users values('{LoginTB.Text}', '{PassTB.Text}', 'User'); ");
                MessageBox.Show("Регистрация прошла успешно.");
            }    
        }
    }
}
