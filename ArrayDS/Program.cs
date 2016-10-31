using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDS
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class Solution
    {

        static void Main(String[] args)
        {
           int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            if( n != arr.Length)
            {
                Console.WriteLine("Error: The number quoted and actual data input does not match.");
            }

            StringBuilder retVal = new StringBuilder();

            for (int i = (arr.Length -1); i >= 0; i--)
            {
                retVal.AppendFormat("{0} ", arr[i]);
            }

            Console.WriteLine(retVal.ToString());
            Console.ReadKey();
        }
    }

}
