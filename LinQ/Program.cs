using System.ComponentModel;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System;
namespace LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //            1)Basic Anonymous Function

            //Task: Create a simple anonymous function using a lambda expression that takes an integer and returns its square.

            #region Task1
            Func<int, int> GetSquare = static delegate (int x)
            {
                return x;
            };

            Console.WriteLine(GetSquare(1));
            #endregion;

            //2)Anonymous Function with Multiple Parameters

            //Task: Write an anonymous function that takes two integers and returns their sum.

            #region Task2
            Func<int, int, int> Sum = static delegate (int a, int b)
            {

                return a + b;
            };

            Console.WriteLine("Get Sum of two numbers");

            Console.Write("Num1: ");
            int.TryParse(Console.ReadLine(), out int num1);

            Console.Write("Num2: ");
            int.TryParse(Console.ReadLine(), out int num2);

            Console.WriteLine(Sum(num1, num2));
            #endregion;

            //3)Action Anonymous Function

            //Task: Create an anonymous function using Action that takes a string and prints it to the console.
            Action<string> PrintConsole = static delegate (string input) { Console.WriteLine(input); };

            Console.WriteLine("Write a value and get it");

            string? value = Console.ReadLine();

            if (value is not null)
                PrintConsole(value);

            */

            //4)Filtering with Anonymous Functions

            //Task: Use an anonymous function with List<int>.Where to filter out even numbers from a list.

            #region Task4
            List<int> ints1 = [];
            var FilterOutEven = delegate (List<int> numbers)
            {
                ints1 = numbers.Where(num => num % 2 == 1).ToList();
                Console.WriteLine(string.Join(", ", ints1));
            };

            List<int> ints = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];


            FilterOutEven(ints);

            Console.WriteLine(string.Join(", ", ints1));
            #endregion;

            //5)Complex Filtering and Transformation

            //Task: Use an anonymous function to filter a list of integers to only those that are prime, then multiply each prime number by 2.

            var FilterDoublePrimes = delegate (List<int> numbers)
            {
                return numbers.Where(num =>
                 {
                     if (IsPrime(num)) return true;
                     return false;
                 }).Select(num => num * 2).ToList();
            };

            static bool IsPrime(int number)
            {
                if (number <= 1) return false;
                if (number == 2) return true; // 2 is the only even prime number
                if (number % 2 == 0) return false; // Exclude even numbers greater than 2

                int boundary = (int)Math.Floor(Math.Sqrt(number));

                for (int i = 3; i <= boundary; i += 2)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            var primeDOubledNums = FilterDoublePrimes(ints);

            Console.WriteLine(string.Join(", ", primeDOubledNums));

            //6)Chained Anonymous Functions

            //Task: Create a chain of anonymous functions that first filters a list of integers to even numbers, then doubles each number, and finally sums the results.

            #region Task6
            var FilterDoubleEvens = delegate (List<int> numbers)
            {
                return numbers.Where(num => num % 2 == 0).Select(num => num * 2).ToList();
            };

            var primeDOubledNums2 = FilterDoubleEvens(ints);
            Console.WriteLine(string.Join(", ", primeDOubledNums2));


            #endregion;

        }
    }
}
