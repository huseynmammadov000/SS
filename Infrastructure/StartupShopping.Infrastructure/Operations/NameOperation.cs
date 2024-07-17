using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Infrastructure.Operations
{
    public class NameOperation
    {
        public static string CharacterRegulatory(string name)
        {
            name.Replace("\"", "");
            return name;


        }
    }
}
