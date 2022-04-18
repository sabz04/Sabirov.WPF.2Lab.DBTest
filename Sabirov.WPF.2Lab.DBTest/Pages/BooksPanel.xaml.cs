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
    /// Логика взаимодействия для BooksPanel.xaml
    /// </summary>
    public partial class BooksPanel : Page
    {
       
        public BooksPanel()
        {
            InitializeComponent();
           
            DataTable bookTB = Operations.CreateZaprosSQLWITHRES("select" +
                " * from Books;");
            foreach(DataRow dataRow in bookTB.Rows)
            {
                bookIds.Children.Add(new TextBlock() {
                Text = dataRow.ItemArray[1].ToString(),
                TextWrapping = TextWrapping.Wrap
                });
                bookNames.Children.Add(new TextBlock()
                {
                    Text = dataRow.ItemArray[0].ToString(),
                    TextWrapping = TextWrapping.Wrap
                });
                bookDescs.Children.Add(new TextBlock()
                {
                    Text = dataRow.ItemArray[2].ToString(),
                    TextWrapping= TextWrapping.Wrap
                });
            }
        }
        public static bool BooksLoad()
        {
            DataTable bookTB = Operations.CreateZaprosSQLWITHRES("select" +
                   " * from Books;");
            if(bookTB.Rows.Count > 0)
                 return true;
            else
                return false;

        }
    }
}
