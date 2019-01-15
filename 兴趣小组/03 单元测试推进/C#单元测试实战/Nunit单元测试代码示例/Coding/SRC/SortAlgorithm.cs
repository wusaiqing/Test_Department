using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.SRC
{
    //Sort Algorithm
    class SortAlgorithm
    {
        public int Container;

        //BubbleSort
        public int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        Container = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = Container;
                    }
                    for (int k = 0; k < arr.Length; k++)
                    {
                        Console.Write(arr[k] + ",");
                    }
                    Console.WriteLine();
                }
            }
            return arr;
        }
        //Swap Sort
        public int[] SwapSort(int[] arr)
        {
            int temp = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                Container = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[Container])
                    {
                        Container = j;
                    }
                }
                if (arr[Container] < arr[i - 1])
                {
                    temp = arr[Container];
                    arr[Container] = arr[i - 1];
                    arr[i - 1] = temp;
                }
            }
            return arr;
        }
        //Quick Sort
        public int QuickSortKey(int[] arr, int b, int e)
        {
            int key = arr[b];
            int i = b;
            int j = e;
            while (i != j)
            {

                while (arr[j] > key)
                    --j;
                Container = arr[j];
                arr[j] = key;
                arr[i] = Container;
                while (arr[i] < key)
                    ++i;
                Container = arr[i];
                arr[i] = key;
                arr[j] = Container;
            }
            return j;
        }
        public void QuickSort(int[] arr, int p, int q)
        {
            while (p >= q) return;
            int r = QuickSortKey(arr, p, q);
            QuickSort(arr, p, r - 1);
            QuickSort(arr, r + 1, q);
        }
        public int[] QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
            return arr;
        }
    }
}
