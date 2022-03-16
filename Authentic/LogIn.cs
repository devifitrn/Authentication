using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authentication
{
    class LogIn
    {
        public string name { get; set; }
        public string pass { get; set; }
        public void masuk()
        {

            Console.Write("Username : ");
            name = Console.ReadLine();
            Console.Write("Password : ");
            pass = Console.ReadLine();
            
        }


    }

}

