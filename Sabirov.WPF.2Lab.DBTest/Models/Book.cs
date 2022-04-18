using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabirov.WPF._2Lab.DBTest.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public static List<Book> Books = new List<Book>();
    }
}
