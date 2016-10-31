using System;
using System.Collections.Generic;

namespace HikingSelfies
{
    class Solution
    {
        public static void Main(string[] args)
        {
            var input = Console.In;
            var friends = Convert.ToInt32(input.ReadLine());
            var frames = Convert.ToInt32(input.ReadLine());

            var f = new int[friends];
            for (var i = 0; i < friends; i++)
            {
                f[i] = i;
            }

            var pics = CreateSubsets(f).Count;

            Console.WriteLine(Math.Abs(pics - frames));
            Console.Read();
        }

        internal static List<T[]> CreateSubsets<T>(T[] originalArray)
        {
            var subsets = new List<T[]>();

            foreach (var t in originalArray)
            {
                var subsetCount = subsets.Count;
                subsets.Add(new[] {t});

                for (var j = 0; j < subsetCount; j++)
                {
                    var newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = t;
                    subsets.Add(newSubset);
                }
            }

            return subsets;
        }
    }
}

