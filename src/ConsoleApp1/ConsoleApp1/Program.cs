using System;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of balls: ");
            var r = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter max ball number: ");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter max powerball number: ");
            var p = int.Parse(Console.ReadLine());

            Console.WriteLine("Odds are 1 in " + CalculateOdds(r, n, p));
        }

        private static BigInteger CalculateFactorial(int n)
        {
            BigInteger f = 1;

            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }

            return f;
        }

        private static BigInteger CalculateOdds(int r, int n, int p)
        {
            return (CalculateFactorial(n) / (CalculateFactorial(r) * CalculateFactorial(n - r))) * p;
        }
    }
}
