using System;
using System.Collections.Generic;
using System.Text;

namespace CRIF.CodeTest1
{
    public static class Caculator
    {
        public static int calculateDiagonals(int n,int[][] s)
        {
            var d1 = 0;
            var d2 = 0;

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        d1 += s[i][j];
                    }
                    if (i + j == n - 1)
                    {
                        d2 += s[i][j];
                    }
                }
            }
            return Math.Abs(d1 - d2);
        }

    }
}
