using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Algorithm
{
    /// <summary>
    /// Extension methods for a sort algorithm.
    /// </summary>
    public static class SortExtensions
    {
        public static int[] QuickSort(this int[] source,
            int left,
            int right)
        {
            if (left<right)
            {
                int i=left;
                int j=right;
                var temp = source[left];
                
                while (i!=j)
                {
                    while (source[j]>= temp && i<j)
                    {
                        j--;
                    }
                    while (source[i] <= temp && i < j)
                    {
                        i++;
                    }
                    if (i<j)
                    {
                        var tmp = source[i];
                        source[i] = source[j];
                        source[j] = tmp;
                    }
                }
                source[left] = source[i];
                source[i] = temp;
                source.QuickSort(left, i-1);
                source.QuickSort(i+1, right);
            }
            return source;
        }

        public static int[] BubbleSort(this int[] source)
        {
            for (int i = 0; i < source.Length-1; i++)
            {
                for (int j = i+1; j < source.Length; j++)
                {
                    if (source[i]>source[j])
                    {
                        var temp = source[i];
                        source[i] = source[j];
                        source[j] = temp;
                    }
                }
            }
            return source;
        }
    }
}
