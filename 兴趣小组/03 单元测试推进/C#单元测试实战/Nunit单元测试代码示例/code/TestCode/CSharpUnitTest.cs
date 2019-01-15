using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CSharpUnit
{
    using NUnit.Framework;
    [TestFixture]
    class CSharpUnitTest
    {
        private int a;
        private int b;
        [SetUp]
        public void InitializeOperands()
        {
            //设定初始化值
            a = 10;
            b = 2;
        }
        //Add方法测试方法
        [Test]
        public void AddTest() 
        {
            Program p = new Program();
            int expect = 12;
            int sum = p.Add(a, b);
            Assert.AreEqual(expect, sum);
        }
        //Dec测试方法
        [Test]
        public void DecTest()
        {
            Program p = new Program();
            int expect = 8;
            int dec = p.Dec(a, b);
            Assert.AreEqual(expect, dec);
           
        }
        //Div测试方法的异常测试
        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DevExpectedException()
        {
            Program p = new Program();
            int zero = 0;
            int infinit = a / zero;
            Assert.Fail("Should have gotten a exception in one second");
            Assert.AreEqual(0, infinit);
        }
        //Mul测试方法的ignore测试
        [Test]
        [Ignore]
        public void MulIgnoreTest() 
        {
            Program p = new Program();
            int except = 20;
            int Mul=p.Mul(a,b);
            Assert.AreEqual(except, Mul);
        }
    }
    public abstract class NUnitTestextend 
    {
        public int a = 5;
    }
    [TestFixture]
    public class NUnitTest_abstracttry : NUnitTestextend
    {
        [Test]
        public void AbstractTry_Multest()
        {
            Program p = new Program();
            int except =500;
            int b = 100;
            int Mul = p.Mul(a, b);
            Assert.AreEqual(except, Mul);
        }
    }
    class testgenericlist 
    {
        public void ListContent()
        {
            System.Collections.Generic.List<int> list = new List<int>();
            for (int x = 0; x < 5; x++)
            {
                list.Add(x);
            }
            foreach (int i in list) 
            {
                System.Console.Write(i + "");
            }
            Console.WriteLine("\nDone");
            Console.Read();
        }
        //static void main(string[] args) 
        //{
        //    string configtest=
        //}
    }
}
