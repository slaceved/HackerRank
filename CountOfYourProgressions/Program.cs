using System;

namespace CountOfYourProgressions
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            var arrayCount= Convert.ToInt32(Console.ReadLine());
            var nums = new int[arrayCount];
            for (var x = 0; x < arrayCount; x++)
            {
                nums[x] = Convert.ToInt32(Console.ReadLine());
            }
           
            var result = 0;
            for(var i = 0; i < arrayCount; i++)
            {
                var a1 = nums[i];
                result++;
                for (var j = i + 1; j < arrayCount; j++)
                {
                    var a2 = nums[j];
                    var delta = a2 - a1;
                    result = FindMatch(j, a2, delta, nums, result);
                }
            }
            Console.WriteLine(result + 1 + nums.Length);
            Console.Read();
        }//main

        public static int FindMatch(int index, int a2, int delta, int[] nums, int result)
        {
            for (var k = index + 1; k < nums.Length; k++)
            {
                var a3 = nums[k];
                var step = a3 - a2;
                if (step != delta) continue;
                result++;
                result += FindMatch(k, a3, delta, nums, result);
            }
            return result;
        }
    }//class
}//namespace
