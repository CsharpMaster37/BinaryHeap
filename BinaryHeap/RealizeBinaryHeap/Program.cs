using System;
using BinaryHeap;
using System.Diagnostics;

namespace RealizeBinaryHeap
{
    internal class Program
    {
        public static Stopwatch sw = new Stopwatch();
        public static void PyramidSort(int[] arr)
        {
            BinaryHeap<int> heap = new BinaryHeap<int>(arr, new MinHeap<int>());
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = heap.Pop();
            }
        }

        //метод возвращающий индекс опорного элемента
        static void QuickSort(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(A, p, r);
                QuickSort(A, p, q - 1);
                QuickSort(A, q + 1, r);
            }
        }

        static int Partition(int[] A, int p, int r)
        {
            int x = A[r];
            int i = p - 1;
            for (int j = p; j <= r - 1; j++)
            {
                if (A[j] <= x)
                {
                    i++;
                    Swap(ref A[i], ref A[j]);
                }
            }
            Swap(ref A[i + 1], ref A[r]);
            return i + 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
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
                arr[i] = i;
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
            TestSortedArray(PyramidSort);
            TestSortedArray(QuickSort);
            Console.WriteLine("__________________________________");
            Console.WriteLine("Not Sorted:");
            TestNotSortedArray(PyramidSort);
            TestNotSortedArray(QuickSort);
            Console.WriteLine("__________________________________");
            Console.WriteLine("Half Sorted:");
            TestHalfSortedArray(PyramidSort);
            TestHalfSortedArray(QuickSort);
            Console.WriteLine("__________________________________");
        }
    }
}
