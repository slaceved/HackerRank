using System;
using System.Collections.Generic;
using System.IO;

namespace SparseArray
{
    public static class Solution
    {
        private static int Main(string[] args)
        {
            var m = new Dictionary<string, int>();
            using (var stdin = Console.In)
            using (var stdout = Console.Out)
            {
                int n = 0, q = 0;
                string str;

                var strN = stdin.ReadLine();
                int tempInt;
                if (int.TryParse(strN, out tempInt))
                    n = tempInt;

                for (var i = 0; i < n; i++)
                {
                    str = stdin.ReadLine();
                    if (!string.IsNullOrEmpty(str))
                        m.Add(str,i);
                }

                var strQ = stdin.ReadLine();
                if (int.TryParse(strQ, out tempInt))
                    q = tempInt;

                for (var i = 0; i < q; i++)
                {
                    str = stdin.ReadLine();
                    if (string.IsNullOrEmpty(str)) continue;
                    m.TryGetValue(str, out tempInt);
                    stdout.WriteLine(tempInt);
                }
            }
            return 0;
        }
    }
}
