using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MyStack<T> where T :new()
    {
        private T[] _stack;

        public MyStack()
        {
            _stack = new T[0];
        }

        public void Push(T item)
        {
            T[] temp = new T[_stack.Length + 1];
            Array.Copy(_stack, 0, temp, 1, _stack.Length);
            temp[0] = item;
            _stack = temp;
        }

        public T Pop()
        {
            if (_stack.Length == 0)
                return default(T);

            T[] temp = new T[_stack.Length - 1];
            Array.Copy(_stack, 1, temp, 0, _stack.Length - 1);
            T retVal = _stack[0];
            _stack = temp;
            return retVal;
        }
    }

}
