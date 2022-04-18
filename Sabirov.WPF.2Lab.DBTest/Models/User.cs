using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabirov.WPF._2Lab.DBTest
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Role { get; set; }
        public static List<User> Users =new List<User>();
        
    }
}
