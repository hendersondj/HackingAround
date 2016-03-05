using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MyQueue<T> where T : IComparable<T>
    {
        private LinkedList<T> _queue;
        public MyQueue()
        {
            _queue = new LinkedList<T>();
        }
        public void Enqueue(T item)
        {
            _queue.Add(item);
        }

        public T Dequeue()
        {
            return _queue.RemoveHead().Value;
        }
    }
}
