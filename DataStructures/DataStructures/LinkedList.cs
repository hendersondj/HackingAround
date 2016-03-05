using System;

namespace DataStructures
{
    class LinkedList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail; 
                
        public LinkedList()
        {

        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else if (head == tail)
            {
                head.Next = newNode;
            }
            else
            {
                tail.Next = newNode;
            }
            tail = newNode;
        }

        public Node<T> Find(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                    return current;
                current = current.Next;
            }
            return new Node<T>(default(T));
        }

        public Node<T> RemoveTail()
        {
            Node<T> current = head;
            Node<T> retVal = tail;
            while (current != null)
            {
                if (current.Next == tail)
                {
                    current.Next = null;
                    tail = current;
                }
                current = current.Next;
            }
            return retVal;
        }

        public Node<T> RemoveHead()
        {
            Node<T> retVal = head;
            head = head.Next;
            return retVal;
        }
    }

    public class Node<T>
    {
        public T Value;
        public Node<T> Next;

        public Node(T item)
        {
            Value = item;
        }
    }

    public class LinkedListCycles<T>
    {
        public Node<T> head;
        public void Add(Node<T> newNode, Node<T> after)
        {
            if (head == null || after == null)
            {
                head = newNode;
                return;
            }
            after.Next = newNode;
        }

        public bool ContainsCycles()
        {
            // finds cycle to head
            if (head == null) return false;
            //Node<T> current = head;
            //while (current != null)
            //{
            //    if (current.Next == head)
            //        return true;
            //    current = current.Next;
            //}
            //return false;

            Node<T> slow = head;
            Node<T> fast = head.Next;
            while (slow != null && fast != null && fast.Next != null)
            {
                if (slow == fast || slow == fast.Next ) return true;
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return false;
        }
    }
}