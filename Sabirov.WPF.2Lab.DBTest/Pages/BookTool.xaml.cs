using Sabirov.WPF._2Lab.DBTest.Models;
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

namespace Sabirov.WPF._2Lab.DBTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookTool.xaml
    /// </summary>
    public partial class BookTool : Window
    {
        public BookTool()
        {
            InitializeComponent();
            Operations.GetBooksFromDBSQL();
            this.Title = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in Book.Books)
            {
                if(item.Name == NameTB.Text)
                {
                    MessageBox.Show("Такая книга уже существует.");
                    return;
                }
            }
            
            Operations.CreateZaprosSQL($"insert into Books values(N'{NameTB.Text}',N'{DescTB.Text}');");
            MainWindow.mainWindow.frame.Navigate(new AdminPanel());
            
            this.Visibility = Visibility.Hidden;
            
        }
    }
}
