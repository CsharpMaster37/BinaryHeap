using System;
using System.Collections.Generic;

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
            _items = new T[_capacity];
            _comparer = Comparer<T>.Default;
        }

        public BinaryHeap(T[] array, IComparer<T> comparer)
        {
            Count = array.Length;
            while (_capacity < Count)
                _capacity *= 2;
            _comparer = comparer;
            _items = new T[_capacity];
            Array.Copy(array, 0, _items, 0, Count);
            for (int i = _items.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public T PopWithRecursive()
        {
            if (Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            T maxItem = _items[0];
            _items[0] = _items[Count - 1];
            Count--;
            Heapify(0);
            return maxItem;
        }

        public T PopWithoutRecursive()
        {
            if (Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            T maxItem = _items[0];
            _items[0] = _items[Count - 1];
            Count--;
            HeapifyNonRecursive(0);
            return maxItem;
        }



        public void Insert(T item)
        {
            if (Count == _capacity)
                IncrementCapacity();
            Count++;
            _items[Count-1] = item;
            Heapify(Parent(Count - 1));
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

        public T[] GetHeap()
        {
            T[] returnvalues = new T[Count];
            Array.Copy(_items, 0, returnvalues, 0, Count);
            return returnvalues;
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
            if (largest == index) 
                return;
            Swap(largest, index);
            Heapify(largest);
        }
        private void HeapifyNonRecursive(int index)
        {
            while (true)
            {
                int left = LeftChild(index);
                int right = RightChild(index);
                int largest = index;
                if (left < Count && _comparer.Compare(_items[left], _items[index]) > 0)
                    largest = left;
                if (right < Count && _comparer.Compare(_items[right], _items[largest]) > 0)
                    largest = right;
                if (largest == index)
                    return;
                Swap(largest, index);
                index = largest;
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = temp;
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
