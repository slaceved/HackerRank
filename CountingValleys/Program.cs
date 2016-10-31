using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingValleys
{
    class Solution
    {
        static void Main(string[] args)
        {
            const int seaLevel = 0;
            int distance = seaLevel;
            int steps = Convert.ToInt32(Console.ReadLine());
            var readLine = Console.ReadLine();
            if (readLine == null) return;
            var directions = readLine.Split();
            int Ucount = 0;
            int Dcount = 0;

            if(steps != directions.Length)
                Console.WriteLine("Invalid data provided, try again.");

            foreach(string d in directions)
            {
                switch (d)
                {
                    case "D":
                        distance--;
                        Dcount++;
                        break;
                    case "U":
                        distance++;
                        Ucount++;
                        break;
                    default:
                        Console.WriteLine("Invalid input for direction.");
                        break;
                }

                

                

            }
        }
    }
}
