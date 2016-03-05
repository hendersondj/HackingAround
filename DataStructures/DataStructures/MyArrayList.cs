using System;
using System.Collections;

namespace DataStructures
{
    class MyArrayList<T> where T : IComparable
    {
        private T[] _array;
        public MyArrayList(int size)
        {
            ArrayList list = new ArrayList();
            _array = new T[size];
        }

        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        public void Add(T item)
        {
            T[] temp = new T[_array.Length + 1];
            _array.CopyTo(temp, 0);
            temp[temp.Length - 1] = item;
            _array = temp;
        }
        public void Insert(T item, int index)
        {
            if (index > _array.Length)
                throw new IndexOutOfRangeException();
            T[] temp = new T[_array.Length + 1];
            for (int i = 0; i < index; i++)
            {
                temp[i] = _array[i];
            }
            temp[index] = item;
            for (int i = index + 1; i < temp.Length; i++)
            {
                temp[i] = _array[i - 1];
            }
            _array = temp;
        }

        public void Delete(int index)
        {
            T[] temp = new T[_array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                temp[i] = _array[i];
            }
            for (int i = index; i < temp.Length; i++)
            {
                temp[i] = _array[i + 1];
            }
            _array = temp;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(item))
                    return true;
            }
            return false;
        }
        public void Sort()
        {
            BubbleSort();
        }

        private void BubbleSort()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                for (int j = i + 1; j < _array.Length; j++)
                {
                    if (_array[i].CompareTo(_array[j]) > 0)
                    {
                        T temp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = temp;
                    }
                }
            }
        }

        private void MergeSort()
        {
            //int mid = _array.Length / 2;
        }

        private void QuickSort()
        {
        }

        public void Reverse()
        {
            //ReverseNewArray();
            ReverseReuseArray();
        }
        private void ReverseNewArray()
        {
            T[] temp = new T[_array.Length];
            for (int i = 0; i < _array.Length; i++)
            {
                temp[i] = _array[_array.Length - 1 - i];
            }
            _array = temp;
        }

        private void ReverseReuseArray()
        {
            int begin = 0;
            int end = _array.Length - 1;
            while (begin < end)
            {
                T temp = _array[begin];
                _array[begin] = _array[end];
                _array[end] = temp;
                begin++;
                end--;
            }
        }

        public void Print()
        {
            foreach (T i in _array)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
    }
}
