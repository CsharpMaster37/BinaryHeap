using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryHeap;

namespace RealizeBinaryHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrMin = new int[10] {4,1,3,2,16,9,10,14,8,7};
            int[] arrMax = new int[10] {7,8,14,10,9,16,2,3,1,4};
            BinaryHeap<int> heap = new BinaryHeap<int>(arrMin);
            foreach(var item in heap.GetHeap())
            {
                Console.Write(item + " ");
            }
        }
    }
}
