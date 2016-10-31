using System;
using System.Text.RegularExpressions;

namespace PasswordValidation
{
    internal class Solution
    {
        public static bool StrongPassword(string password)
        {
            //12 characters, at least 1 Upper case leeter, at least 1 lower case letter, at least 1 number
            var rgx = new Regex(@"(?=.{12,})(?=.*[A-Z])(?=.*\d)(?=.*[a-z])");
            var mat = rgx.Match(password);
            if (!mat.Success) { return false; }

            //begins with uppercase and lower case letters, then a number, then more uppercase and lower case letters
            var regx = new Regex(@"[A-Z, a-z]+[0-9]+[A-Z, a-z]+");
            var match = regx.Match(password);
            return match.Success;
        }
         public static void Main(string[] args)
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
