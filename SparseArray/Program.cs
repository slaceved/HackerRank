using System;


namespace SparseArray
{
    public static class Solution
    {
        private static void Main(string[] args)
        {
            var sa = new SparseArray();

            using (var stdin = Console.In)
            using (var stdout = Console.Out)
            {
                //stdout.WriteLine("Enter the N value:");
                var strN = stdin.ReadLine();
                int tempInt;
                int n;
                if (int.TryParse(strN, out tempInt) && tempInt.Between(1, 1000))
                    n = tempInt;
                else
                {
                    stdout.WriteLine("The N value must be an integer between 1 and 1000.");
                    while (!int.TryParse(stdin.ReadLine(), out tempInt) && tempInt.Between(1, 1000))
                        stdout.WriteLine("The N value must be an integer between 1 and 1000.");
                    n = tempInt;
                }
                
                //stdout.WriteLine("Enter the strings:");
                string tempStr;
                for (var i = 0; i < n; i++)
                {
                    tempStr = stdin.ReadLine();
                    if (string.IsNullOrEmpty(tempStr))
                    {
                        stdout.WriteLine("The String input can not be null.");
                    }
                    else
                    {
                        if (tempStr.Length.Between(1, 20))
                        {
                            sa.Add(tempStr);
                        }
                        else
                        {
                            stdout.WriteLine("The string input must be a length of at least 1 and less than 20.");
                            while (tempStr.Length.Between(1, 20))
                                stdout.WriteLine("The string input must be a length of at least 1 and less than 20.");
                            sa.Add(tempStr);
                        }
                    }
                }

                //stdout.WriteLine("Enter the Q value:");
                var strQ = stdin.ReadLine();
                int q;
                if (int.TryParse(strQ, out tempInt) && tempInt.Between(1, 1000))
                    q = tempInt;
                else
                {
                    stdout.WriteLine("The Q value must be an integer.");
                    while (!int.TryParse(stdin.ReadLine(), out tempInt) && tempInt.Between(1, 1000))
                        stdout.WriteLine("The Q value must be an integer.");
                    q = tempInt;

                }

                //stdout.WriteLine("Enter the queries:");
                for (var i = 0; i < q; i++)
                {
                    tempStr = stdin.ReadLine();
                    if (string.IsNullOrEmpty(tempStr))
                    {
                        stdout.WriteLine("The query input call not be null");
                    }
                    else
                    {
                        if (tempStr.Length.Between(1, 20))
                        {
                            stdout.WriteLine(sa.IndexOf(tempStr));
                        }
                        else
                        {
                            stdout.WriteLine("The string input must be a length greater than 1 and less than 20.");
                            while (tempStr.Length.Between(1, 20))
                                stdout.WriteLine("The string input must be a length greater than 1 and less than 20.");
                            stdout.WriteLine(sa.IndexOf(tempStr));
                        }
                    }
                }
      
            } //using
        }

    } //class

    public static class Utils
    {
        
         public static bool Between(this int num, int lower, int upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }
    }

} //namespace
