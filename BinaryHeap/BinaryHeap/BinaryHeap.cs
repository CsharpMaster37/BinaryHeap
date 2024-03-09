using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class BinaryHeap<T>
    {
        private int _capacity = 4;
        private T[] _items;
        public int Count { get; private set; }
        private IComparer<T> _comparer;
        
        public BinaryHeap()
        {
            _capacity = 4;
            _items = new T[_capacity];
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private int LeftChild(int index)
        {
            return 2 * index + 1;
        }

        private int RightChild(int index)
        {
            return 2 * index + 2;
        }

        public int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }

        public void Heapify(int index)
        {
            int left = LeftChild(index);
            int right = RightChild(index);
            var largest = index;
            if (left < Count && _comparer.Compare(_items[left], _items[index]) > 0)
            { largest = left; }
            if (right < Count && _comparer.Compare(_items[right], _items[largest]) > 0)
            { largest = right; }

            if (largest == index) return;
            var temp = _items[largest];
            _items[largest] = _items[index];
            _items[index] = temp;
            Heapify(largest);
        }

        public T Peek()
        {
            return _items[0];
        }

        public void IncrementCapacity()
        {
            _capacity *= 2;
            T[] _tempItems = new T[_capacity];
            Array.Copy(_items, 0, _tempItems, 0, Count);
            _items = _tempItems;
        }
    }
}
