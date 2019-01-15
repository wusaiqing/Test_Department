using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpUnit.SRC;

namespace CSharpUnit.UTC
{
    using NUnit.Framework;
    //testsort class
    [TestFixture]
    class SortAlgorithmTest
    {
        //BubbleSort test
        [Test]
        public void BubbleSortTest()
        {
            SortAlgorithm s = new SortAlgorithm();
            int[] except = { 9, 15, 20, 34, 36, 45, 49, 99 };
            int[] input = { 45, 34, 9, 36, 49, 20, 99, 15 };
            int[] arr = s.BubbleSort(input);
            Assert.AreEqual(except, arr);
        }

        //SwapSort test
        [Test]
        public void SwapSortTest()
        {
            SortAlgorithm s = new SortAlgorithm();
            int[] except = { 9, 15, 20, 34, 36, 45, 49, 99 };
            int[] input = { 45, 34, 9, 36, 49, 20, 99, 15 };
            int[] arr = s.SwapSort(input);
            Assert.AreEqual(except, arr);
        }

        //QuickSort test
        [Test]
        public void QuickSortTest()
        {
            SortAlgorithm s = new SortAlgorithm();
            int[] except = { 9, 15, 20, 34, 36, 45, 49, 99 };
            int[] input = { 45, 34, 9, 36, 49, 20, 99, 15 };
            int[] arr = s.QuickSort(input);
            Assert.AreEqual(except, arr);
        }
    }
}
