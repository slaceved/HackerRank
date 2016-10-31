using System;

namespace SumArrayOfInts
{
    /// <summary>
    /// Sum an Array of Integers
    /// </summary>
    internal class Solution
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == null) return;
            var n = int.Parse(input);
            const char splitBy = ' ';
            var nums = Console.ReadLine()?.Split(splitBy);
            if (nums == null) return;
            var sum = 0;
            for (var i = 0; i < n; i++)
            {
                sum += int.Parse(nums[i]);
            }
            Console.WriteLine(sum);
        }
    }
}