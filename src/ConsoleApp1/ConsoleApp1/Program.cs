using System;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of white balls: ");
            var r = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter max white ball number: ");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter max red ball number: ");
            var p = int.Parse(Console.ReadLine());

            Console.WriteLine("Odds are 1 in " + CalculateOdds(r, n, p));

            var ticket = Draw(r, n, p);
            int[] matchedDrawing;

            BigInteger count = 0;

            while (true)
            {
                count++;

                var drawing = Draw(r, n, p);

                if (IsMatch(ticket, drawing))
                {
                    matchedDrawing = drawing;
                    break;
                }
            }

            Console.WriteLine("Ticket " + string.Join(" ", ticket) + " matched " + string.Join(" ", matchedDrawing) + " after " + count + " drawings!");
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

        private static readonly Random random = new Random();

        private static int[] Draw(int r, int n, int p)
        {
            var whiteBalls = Enumerable.Range(1, n).OrderBy(x => random.Next()).Take(r);
            var redBall = Enumerable.Range(1, p).OrderBy(x => random.Next()).Take(1);

            return whiteBalls.Concat(redBall).ToArray();
        }

        private static bool IsMatch(int[] drawing1, int[] drawing2)
        {
            var drawing1WhiteBalls = drawing1.Take(drawing1.Length - 1).OrderBy(b => b);
            var drawing1RedBall = drawing1.Last();

            var drawing2WhiteBalls = drawing2.Take(drawing2.Length - 1).OrderBy(b => b);
            var drawing2RedBall = drawing2.Last();

            return drawing1RedBall == drawing2RedBall && string.Join(" ", drawing1WhiteBalls) == string.Join(" ", drawing2WhiteBalls);
        }
    }
}
