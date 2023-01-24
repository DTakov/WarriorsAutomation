using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summator
{
    public static class Summator
    {
        public static long Sum(int[] arr)
        {
            long sum = 0;

            for ( int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum;
        }

        public static double Average(int[] arr)
        {
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum/arr.Length;
        }
    }
}
