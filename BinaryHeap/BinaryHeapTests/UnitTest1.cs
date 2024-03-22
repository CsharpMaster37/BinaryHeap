using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BinaryHeap;

namespace BinaryHeapTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBuildMinHeap()
        {
            int[] arr = new int[5] { 5, 4, 3, 2, 1 };
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MinHeap<int>());
            int[] targetarr = new int[5] { 1, 2, 3, 5, 4 };
            int i = 0;
            foreach (var item in heap.GetHeap())
            {
                Assert.AreEqual(targetarr[i], item);
                i++;
            }
        }
        [TestMethod]
        public void TestBuildMaxHeap()
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MaxHeap<int>());
            int[] targetarr = new int[5] { 5, 4, 3, 1, 2 };
            int i = 0;
            foreach (var item in heap.GetHeap())
            {
                Assert.AreEqual(targetarr[i], item);
                i++;
            }
        }
        [TestMethod]
        public void TestPeek()
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MaxHeap<int>());
            Assert.AreEqual(5, heap.Peek());
        }
        [TestMethod]
        public void TestPopk()
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MaxHeap<int>());
            Assert.AreEqual(5, heap.PopWithoutRecursive());


        }
        [TestMethod]
        public void TestDecCount()
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MaxHeap<int>());
            heap.PopWithoutRecursive();
            Assert.AreEqual(4, heap.Count);
        }
        [TestMethod]
        public void TestIncCount()
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MaxHeap<int>());
            heap.Insert(7);
            Assert.AreEqual(6, heap.Count);
        }
        [TestMethod]
        public void TestPyramidSort()
        {
            int[] arr = new int[1000];
            for (int i = 999; i >= 0; i--)
            {
                arr[i] = i;
            }
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MinHeap<int>());
            for (int i = 0; i < 1000; i++)
            {
                arr[i] = heap.PopWithoutRecursive();
            }
            int[] sortedarr = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                sortedarr[i] = i;
            }
            int q = 0;
            foreach (var item in arr)
            {
                Assert.AreEqual(item, sortedarr[q]);
                q++;
            }
        }
    }
}
