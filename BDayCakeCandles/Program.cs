using System;
using System.Linq;

namespace BDayCakeCandles
{
    internal static class Solution
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == null) return;
            var n = int.Parse(input);
            if (!Between(n, 1, 10^5))
            {
                Console.WriteLine("Error: The number of candles entered is not between 1 and 10^5.");
            }

            var heightTemp = Console.ReadLine()?.Split(' ');
            if (heightTemp == null) return;
            var height = Array.ConvertAll(heightTemp, int.Parse);
            if (height.Length != n)
            {
                Console.WriteLine("Error: The number of candles entered does not equal the quantity of candle heights entered.");
            }
            
            //retVal = count number of candles at highest height
            var candleCount = (from i in height
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
