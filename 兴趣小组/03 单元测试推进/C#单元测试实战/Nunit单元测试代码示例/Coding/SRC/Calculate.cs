using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit
{
    //Calculate class
    class Calculate
    {
        /// <summary>
        /// Add方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Add(int a, int b)
        {
            return a + b;
        }
        /// <summary>
        /// Dec方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Dec(int a, int b) 
        {
            return (a-b);
        }
        /// <summary>
        /// Mul方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Mul(int a, int b)
        {
            return (a*b);
        }
        /// <summary>
        /// Div方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Div(int a, int b)
        {
            if (0 == b)
            {
                Console.Write("被除数不能为0");
                return 0;
            }
            else 
                return a / b;
        }
        //main 方法
        //static void Main(string[] args)
        //{
        //    Sort s = new Sort();
        //    int[] except = { 9, 15, 20, 34, 36, 45, 49, 99 };
        //    int[] arr = { 45, 34, 9, 36, 49, 20, 99, 15 };
        //    s.QuickSort(arr, 0, arr.Length - 1);
        //    int temp = arr[0];
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        Console.Write(arr[i] + ",");
        //    }
        //    Console.Read();
        //}
    }
    
}
