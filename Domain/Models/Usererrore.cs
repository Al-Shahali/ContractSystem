using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public static class Usererrore
    {
        public static string GetMSG(string msg)
        {
            Dictionary<string,string> list = new Dictionary<string, string>
            {
                {"GEN100"," Saved success"}
            } ;

            return list[msg];
        }
    }
}
