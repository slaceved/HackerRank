using System;

namespace CountingValleys
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            const int seaLevel = 0;
            var distance = seaLevel;
            var steps = Convert.ToInt32(Console.ReadLine());
            var readLine = Console.ReadLine();
            if (readLine == null) return;
            var directions = readLine.Split();
            var Ucount = 0;
            var Dcount = 0;

            if(steps != directions.Length)
                Console.WriteLine("Invalid data provided, try again.");

            foreach(var d in directions)
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
            //TBD: format output
        }
    }
}
