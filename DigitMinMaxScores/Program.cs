using System;
using System.Linq;

namespace DigitMinMaxScores
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            var a = Convert.ToInt32(Console.ReadLine());
            var b = Convert.ToInt32(Console.ReadLine());
            var score = 0;

            while (a <= b)
            {
                var result = a.ToString().Where(char.IsDigit).ToArray();
                for (var i = 1; i < result.Length - 1; i++)
                {
                    if (result[i - 1] <= 0) continue;
                    if (result[i + 1] <= 0) continue;
                    if (result[i] < result[i - 1] && result[i] < result[i + 1])
                    {
                        score++;
                    }
                    if (result[i] > result[i - 1] && result[i] > result[i + 1])
                    {
                        score++;
                    }
                }
                a++;
            }
            Console.WriteLine(score);
            Console.Read();
        }
    }
}
