using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MorganAndAString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.In;
            var testCases = Convert.ToInt32(input.ReadLine());

            for (var i = 0; i < testCases; i++)
            {
                var inputA = input.ReadLine()?.ToUpper();
                var inputB = input.ReadLine()?.ToUpper();
                int indexA = 0, indexB = 0;
                var result = new StringBuilder();

                Debug.Assert(inputA != null, "inputA != null");
                Debug.Assert(inputB != null, "inputB != null");

                while (indexA < inputA.Length && indexB < inputB.Length)
                {
                    if (inputA[indexA] < inputB[indexB]) //a at index is smaller
                    {
                        result.Append(inputA[indexA]);
                        indexA++;
                        Console.WriteLine("a selected");
                        Console.WriteLine("a value = {0}, {1} ",inputA[indexA].GetHashCode(), inputA[indexA]);
                        Console.WriteLine("b value = {0}, {1}", inputB[indexB].GetHashCode(), inputB[indexB]);
                    }
                    else if (inputA[indexA] > inputB[indexB]) //b at index is smaller
                    {
                        result.Append(inputB[indexB]);
                        indexB++;
                        Console.WriteLine("b selected");
                        Console.WriteLine("a value = {0}, {1}", inputA[indexA].GetHashCode(), inputA[indexA]);
                        Console.WriteLine("b value = {0}, {1}", inputB[indexB].GetHashCode(), inputB[indexB]);
                    }
                    else //a and b at index are equal
                    {
                        var comparer = new LexicographicCharArrayComparer();
                        var a = inputA.Substring(indexA + 1, inputA.Length - indexA - 1) + "z";
                        var b = inputB.Substring(indexB + 1, inputB.Length - indexB - 1) + "z";

                        var retVal = comparer.Compare(a.ToCharArray(), b.ToCharArray());
                        if (retVal < 0) //a string is smaller
                        {
                            result.Append(inputA[indexA]);
                            indexA++;
                            Console.WriteLine("a selected");
                            Console.WriteLine("a string = {0}, {1}", a.GetHashCode(), a);
                            Console.WriteLine("b string = {0}, {1}", b.GetHashCode(), b);
                        }
                        else if (retVal > 0) //b string is smaller
                        {
                            result.Append(inputB[indexB]);
                            indexB++;
                            Console.WriteLine("b selected");
                            Console.WriteLine("a string = {0}, {1}", a.GetHashCode(), a);
                            Console.WriteLine("b string = {0}, {1}", b.GetHashCode(), b);
                        }
                        else //a and b strings are equal
                        {
                            result.Append(inputA[indexA]);
                            indexA++;
                            Console.WriteLine("a selected -- whole string is equal");
                            Console.WriteLine("a string = {0}, {1}", a.GetHashCode(), a);
                            Console.WriteLine("b string = {0}, {1}", b.GetHashCode(), b);
                        }
                    }
                }
                result.Append(inputA.Substring(indexA)).Append(inputB.Substring(indexB));
                Console.WriteLine(result.ToString());
            } //testcase for loop

            Console.WriteLine();
            Console.WriteLine("Press enter to close...");
            Console.Read();
        } //main
    } //solution class

    internal class LexicographicCharArrayComparer : Comparer<char[]>
    {
        public override int Compare(char[] x, char[] y)
        {
            if (x == null || y == null)
                return Default.Compare(x, y);

            var lengthComp = x.Length.CompareTo(y.Length);

            return lengthComp != 0 ? lengthComp : StringComparer.Ordinal.Compare(new string(x), new string(y));
        }
    }//lexicographicCharArrayComparer class
} //namespace