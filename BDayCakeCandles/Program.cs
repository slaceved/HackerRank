using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDayCakeCandles
{
    static class Solution
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (!Between(n, 1, 10^5))
            {
                Console.WriteLine("Error: The number of candles entered is not between 1 and 10^5.");
            }

            string[] height_temp = Console.ReadLine().Split(' ');
            int[] height = Array.ConvertAll(height_temp, Int32.Parse);
            if (height.Length != n)
            {
                Console.WriteLine("Error: The number of candles entered does not equal the quantity of candle heights entered.");
            }
            
            //retVal = count number of candles at highest height
            int candleCount = (from i in height
                               where i.Equals(height.Max()) 
                               where Between(i, 1, 10^7)
                               select i).Count();

            if(candleCount == 0)
            {
                Console.WriteLine("Error: The highest candle input is not between 1 and 10^7.");
            }
            else
            {
                Console.WriteLine(candleCount);
            }
        }

        public static bool Between(this int num, int lower, int upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

    }
}
