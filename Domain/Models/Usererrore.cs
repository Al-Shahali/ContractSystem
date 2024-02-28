using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    public class User
    {
        public int UsrCod { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public static class Usererrore
    {
        public static object GetMSG(string errcod)
        {
            Dictionary<string, string> list = new Dictionary<string, string>
            {
                {"GEN100"," Saved success"},


                {"STP100"," invalid Login"},
            };

            return new
            {
                errcod = errcod,
                errmsg = list[errcod]
            };
        }
        public static User CheckUser(string name, string password)
        {
            List<User> list = new List<User>{
                new User()
                {
                    UsrCod=1000,
                    Name="user1",
                    Password="pass1"
                },
               new User()
                {
                    UsrCod=1001,
                    Name="user2",
                    Password="pass2"
                },
            };

            return list.Where(e => e.Name == name && e.Password == password).FirstOrDefault();
        }
    }
}
