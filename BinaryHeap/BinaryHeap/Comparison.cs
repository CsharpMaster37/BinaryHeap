using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class ComparisonHeap
    {
        public int MinHeap(int x, int y)
        {
            return x - y;
        }
        public int MaxHeap(int x, int y)
        {
            return y - x;
        }
    }
}
