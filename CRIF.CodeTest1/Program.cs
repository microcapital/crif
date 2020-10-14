using System;

namespace CRIF.CodeTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, n;
            int[][] s = new int[100][];
            Console.WriteLine("Input:");
            n = int.Parse(Console.ReadLine());

            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    s[i][j] = int.Parse(Console.ReadLine());
                }
            }

           var diff= Caculator.calculateDiagonals(i, s);
            Console.WriteLine(diff);
        }
    }
}
