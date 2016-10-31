using System;
using System.Text;

namespace ArrayDS
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == null) return;
            var n = int.Parse(input);
            var arrTemp = Console.ReadLine()?.Split(' ');
            if (arrTemp == null) return;
            var arr = Array.ConvertAll(arrTemp, Int32.Parse);
            if( n != arr.Length)
            {
                Console.WriteLine("Error: The number quoted and actual data input does not match.");
            }

            var retVal = new StringBuilder();
            for (var i = (arr.Length -1); i >= 0; i--)
            {
                retVal.AppendFormat("{0} ", arr[i]);
            }

            Console.WriteLine(retVal.ToString());
            Console.Read();
        }
    }

}
