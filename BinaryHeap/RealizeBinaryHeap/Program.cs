using System;
using BinaryHeap;
using System.Diagnostics;

namespace RealizeBinaryHeap
{
    internal class Program
    {
        public static Stopwatch sw = new Stopwatch();
        public static void PyramidSortWithRecursive(int[] arr)
        {
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MinHeap<int>());
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = heap.PopWithRecursive();
            }
        }
        public static void PyramidSortWithoutRecursive(int[] arr)
        {
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MinHeap<int>());
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = heap.PopWithoutRecursive();
            }
        }

        public static void TestSortedArray(Action<int[]> methodSort)
        {
            int[] arr = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                arr[i] = i;
            }
            sw.Restart();
            methodSort.Invoke(arr);
            sw.Stop();
            Console.WriteLine($"{methodSort.Method}: {sw.ElapsedMilliseconds}");
        }
        public static void TestNotSortedArray(Action<int[]> methodSort)
        {
            int[] arr = new int[10000];
            for (int i = 9999; i >=0; i--)
            {
                arr[i] = 9999-i;
            }
            sw.Restart();
            methodSort.Invoke(arr);
            sw.Stop();
            Console.WriteLine($"{methodSort.Method}: {sw.ElapsedMilliseconds}");
        }
        public static void TestHalfSortedArray(Action<int[]> methodSort)
        {
            int[] arr = new int[10000];
            for (int i = 0; i <5000 ; i++)
            {
                arr[i] = i;
            }
            for (int i = 5000; i < 10000; i++)
            {
                arr[i] = 9999-i;
            }
            sw.Restart();
            methodSort.Invoke(arr);
            sw.Stop();
            Console.WriteLine($"{methodSort.Method}: {sw.ElapsedMilliseconds}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Sorted:");
            TestSortedArray(PyramidSortWithRecursive);
            TestSortedArray(PyramidSortWithoutRecursive);
            Console.WriteLine("__________________________________");
            Console.WriteLine("Not Sorted:");
            TestNotSortedArray(PyramidSortWithRecursive);
            TestNotSortedArray(PyramidSortWithoutRecursive);
            Console.WriteLine("__________________________________");
            Console.WriteLine("Half Sorted:");
            TestHalfSortedArray(PyramidSortWithRecursive);
            TestHalfSortedArray(PyramidSortWithoutRecursive);
            Console.WriteLine("__________________________________");
        }
    }
}
