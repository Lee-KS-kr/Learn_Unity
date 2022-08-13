using System;

namespace CSharp.Properties
{
    public class Workout
    {
        public static void Main(string[] args)
        {
            int ret = Factorial(11);
            Console.WriteLine(ret);
        }

        static void Multiple()
        {
            for (int i = 2; i < 10; i++)
            {
                Console.WriteLine($"{i}단");
                for (int j = 1; j < 10; j++)
                {
                    Console.WriteLine($"    {i} * {j} = {i * j}");
                }
            }
        }

        static void Triangle()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        static int Factorial(int n)
        {
            if (n == 1) return n;
            return n * Factorial(n - 1);
        }
    }
}