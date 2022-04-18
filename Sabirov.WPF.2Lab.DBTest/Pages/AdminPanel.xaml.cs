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

namespace Sabirov.WPF._2Lab.DBTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();

            DataTable bookTB = Operations.CreateZaprosSQLWITHRES("select" +
                " * from Books;");
            foreach (DataRow dataRow in bookTB.Rows)
            {
                bookIds.Children.Add(new TextBlock()
                {
                    Text = dataRow.ItemArray[1].ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    Background =  new SolidColorBrush(Colors.AntiqueWhite),
                    
                });
                bookNames.Children.Add(new TextBlock()
                {
                    Text = dataRow.ItemArray[0].ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    Background = new SolidColorBrush(Colors.AntiqueWhite),
                });
                bookDescs.Children.Add(new TextBlock()
                {
                    Text = dataRow.ItemArray[2].ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    Background = new SolidColorBrush(Colors.AntiqueWhite),
                });
            }
            
        }
        public static bool IsAdded()
        {
            DataTable bookTB = Operations.CreateZaprosSQLWITHRES("select" +
                   " * from Books;");
            int fCount = bookTB.Rows.Count;
            Operations.CreateZaprosSQL($"insert into Books values(N'TestBook',N'TestBookDesc');");
            DataTable bookTBnew = Operations.CreateZaprosSQLWITHRES("select" +
                   " * from Books;");
            if (fCount<bookTBnew.Rows.Count)
                return true;
            else
                return false;
        }
        private void LogFormBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new InfoPanel());
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            BookTool bookCreatePage = new BookTool();
            bookCreatePage.Show();
        }
    }
}
