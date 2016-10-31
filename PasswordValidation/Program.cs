using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PasswordValidation
{
    class Program
    {
        public static bool StrongPassword(string password)
        {
            //12 characters, at least 1 Upper case leeter, at least 1 lower case letter, at least 1 number
            Regex rgx = new Regex(@"(?=.{12,})(?=.*[A-Z])(?=.*\d)(?=.*[a-z])");
            Match mat = rgx.Match(password);
            if (!mat.Success) { return false; }


            //begins with uppercase and lower case letters, then a number, then more uppercase and lower case letters
            Regex regx = new Regex(@"[A-Z, a-z]+[0-9]+[A-Z, a-z]+");
            Match match = regx.Match(password);
            if (!match.Success) { return false; }


            return true;
        }
            static void Main(string[] args)
        {
            Console.WriteLine(StrongPassword("Strong1Password"));
            Console.WriteLine(StrongPassword("strong1password"));
            Console.WriteLine(StrongPassword("sTrong1passWord"));
            Console.WriteLine(StrongPassword("sTrongpassWord"));
            Console.WriteLine(StrongPassword("sTrongspassWord"));
            Console.WriteLine(StrongPassword("passWord"));
            Console.ReadKey();
        }
    }
}
