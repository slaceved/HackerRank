using System;
using System.Linq;
using System.Runtime.InteropServices;


namespace InterestingFibonacciSum
{
    /// <summary>
    /// Tuzki's love for Fibonacci numbers led him to formulate the following interesting function, , on an array, :
    /// F(A) = (Fibonacci(Sum(A)))%(10^9+7)
    /// where denotes the sum of array 's elements and denotes the Fibonacci number. 
    /// Tuzki is so obsessed with this interesting function that he decides to calculate the following expression, , accurately and efficiently:
    /// G = (Sum F(A L...R))%(10^9+7)  where the sum 1 less than or equal to L less than or equal to R less than or equal to n
    /// This is a tough task for Tuzki and he can't do it alone! Given the values of and array for queries, help Tuzki by finding and printing the value of modulo on a new line for each query.Input Format
    /// The first line contains a single integer, , denoting the number of queries.The subsequent lines describe each query over two lines:
    /// The first line of each query contains an integer, , denoting the size of array.
    /// The second line of each query contains space-separated integers denoting the respective values of array .
    ///For each query, print the value of G modulo 10^9 + 7 on a new line.
    /// Sample Input
    /// 2
    /// 2
    /// 1 1
    /// 3
    /// 1 2 3
    ///Sample Output
    ///3
    ///19
    /// Explaination
    /// Query 0:
    /// F[(1,1)] = fibo(1) = 1, where (x,y) denotes the range in the array
    /// F[(2,2)] = fibo(1) = 1
    /// F[(1,2)] = fibo(2) = 1
    /// G = (1+1+1)%(10^9+7) = 3
    /// Query 1:
    /// F[(1,1)] = fibo(1) = 1
    /// F[(2,2)] = fibo(2) = 1
    /// F[(3,3)] = fibo(3) = 2
    /// F[(1,2)] = fibo(3) = 2
    /// F[(2,3)] = fibo(5) = 5
    /// F[(1,3)] = fibo(6) = 8
    /// G = (1+1+2+2+5+8)%(10^9+7) = 19
    /// </summary>
    internal class Solution
    {
        public static void Main(string[] args)
        {
            var input = Console.In;
            var testCases = Convert.ToInt32(input.ReadLine());
            long FOfA;
            for (var i = 0; i < testCases; i++)
            {
                var arraySize = Convert.ToInt32(input.ReadLine());
                var a = new int[arraySize];
                const char splitBy = ' ';
                var nums = input.ReadLine()?.Split(splitBy.ToString().ToCharArray());

                for (var x = 0; x < arraySize; x++)
                {
                    a[x] = Convert.ToInt32(nums?[x]);
                }

                var sumA = a.Sum();

                FOfA = Fibonacci.GenerateNthFibonacci(sumA)%(Power(10, 9) + 7);



                Console.WriteLine(Fibonacci.GenerateNthFibonacci(sumA) % (Power(10,9) + 7));

            }
            
            Console.Read();
        }//main

        /// <summary>
        /// Computes the power of an <see cref="System.Int32"/> to a given exponent.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) method when the exponent is 1; otherwise O(n) for larger exponents.
        /// </remarks>
        /// <param name="baseNumber">Base number.</param>
        /// <param name="exponent">Exponent to use.</param>
        /// <returns>The value of the base raised to the exponent.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>exponent</strong> is less than <strong>0</strong>.</exception>
        public static int Power(int baseNumber, int exponent)
        {
            if (exponent == 0)
            {
                return 1; // n^0 = 1
            }

            var power = baseNumber;
            while (exponent > 1)
            {
                power *= baseNumber;
                exponent--;
            }

            return power;
        }//Power
    }//class

    public class Fibonacci
    {
        /// <summary>
        /// Generates the Nth Fibonacci number.
        /// </summary>
        /// <param name="n">The Nth Fibonacci number.</param>
        /// <returns>The Nth number in the Fibonacci sequence.</returns>
        public static long GenerateNthFibonacci(int n)
        {

            return GenerateFibonacciSequence(n)[n];
        }

        /// <summary>
        /// Generates the Nth Fibonacci number.
        /// </summary>
        /// <param name="upperBoundN">The upper bound N.</param>
        /// <returns>A series of Fibonacci numbers until the upperBoundN number.</returns>
        public static long[] GenerateFibonacciSequence(int upperBoundN)
        {

            if (upperBoundN < 0)
            {
                throw new ArgumentOutOfRangeException("SetIndexMustBePostive");
            }

            long[] numbers = new long[upperBoundN + 1];

            numbers[0] = 0;

            if (upperBoundN >= 1)
            {
                numbers[1] = 1;

                for (int i = 2; i <= upperBoundN; i++)
                {
                    numbers[i] = numbers[i - 1] + numbers[i - 2];
                }
            }

            return numbers;
        }
    }
}
