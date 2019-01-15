using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit
{
    class Program
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
            //if (0 == b)
            //{
            //    Console.Write("被除数不能为0");
            //    return 0;
            //}
            //else 
                return a / b;
        }
        static void Main(string[] args)
        {
        }
    }
}
