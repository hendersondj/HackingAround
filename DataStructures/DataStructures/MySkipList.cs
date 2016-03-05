using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MySkipList<T> where T : IComparable
    {
        public Node head;

        public void Add(T value)
        {
            Count++;

            Node newNode = new Node();
            newNode.Value = value;
            if (head == null)
            { 
                head = newNode;
                return;
            }
            
            if (newNode.Value.CompareTo(head.Value) < 0)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }
            
            Node current = head;
            while (current.Next != null && newNode.Value.CompareTo(current.Next.Value) > 0)
            {
                current = current.Next;
            }

            // new node is largest in the list
            if (current.Next == null)
            {
                current.Next = newNode;
            }
            // new node needs to be inserted
            else
            {
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        public void Remove(T value)
        {

        }

        public bool Contains(T value)
        {
            Node current = head;
            while (current != null && value.CompareTo(current.Value) >= 0)
            {
                current = current.Next;
            }
            return value.CompareTo(current.Value) == 0;
        }

        public int Height;
        public int Count;

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public class Node
        {
            public Node Next;
            public T Value;
        }
    }
}
