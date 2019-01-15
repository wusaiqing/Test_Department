using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.UTC
{
    using NUnit.Framework;
    [TestFixture]
    class CalculateTest
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
            Calculate p = new Calculate();
            int expect = 12;
            int sum = p.Add(a, b);
            Assert.AreEqual(expect, sum);
        }
        //Dec测试方法
        [Test]
        public void DecTest()
        {
            Calculate p = new Calculate();
            int expect = 8;
            int dec = p.Dec(a, b);
            Assert.AreEqual(expect, dec);

        }
        //Div测试方法的异常测试
        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DevExpectedException()
        {
            Calculate p = new Calculate();
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
            Calculate p = new Calculate();
            int except = 20;
            int Mul = p.Mul(a, b);
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
            Calculate p = new Calculate();
            int except = 500;
            int b = 100;
            int Mul = p.Mul(a, b);
            Assert.AreEqual(except, Mul);
        }
    }
    //genericlist test
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
    }
}
