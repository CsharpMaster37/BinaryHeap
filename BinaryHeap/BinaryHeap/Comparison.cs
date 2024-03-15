using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class MaxHeap<T> : IComparer<T>
    {
        private IComparer<T> defaultComparer = Comparer<T>.Default;
        public int Compare(T x, T y)
        {
            return defaultComparer.Compare(x, y);
        }
    }
    public class MinHeap<T> : IComparer<T>
    {
        private IComparer<T> defaultComparer = Comparer<T>.Default;
        public int Compare(T x, T y)
        {
            return defaultComparer.Compare(y, x);
        }
    }
}
