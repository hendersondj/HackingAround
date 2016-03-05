using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MyBinaryTree<T> where T : IComparable<T>
    {
        private Node head;

        public MyBinaryTree()
        {
        }

        public void Add(T item)
        {
            Node node = new Node();
            node.value = item;

            if (head == null)
            {
                head = node;
                return;
            }

            Add(node, head);
        }

        private void Add(Node newNode, Node currentNode)
        {
            if (newNode.value.CompareTo(currentNode.value) < 0)
            {
                if (currentNode.left == null)
                {
                    currentNode.left = newNode;
                }
                else
                {
                    Add(newNode, currentNode.left);
                }
            }
            else if (newNode.value.CompareTo(currentNode.value) > 0)
            {
                if (currentNode.right == null)
                {
                    currentNode.right = newNode;
                }
                else
                {
                    Add(newNode, currentNode.right);
                }
            }
            else
            {
                throw new InvalidOperationException("tree already contains value");
            }
        }

        public void Delete(T value)
        {
            Delete(value, head);
        }

        private bool Delete(T value, Node currentNode)
        {
            if (currentNode == null)
                return false;

            if (value.CompareTo(currentNode.value) < 0)
            {
                if (Delete(value, currentNode.left))
                {
                    currentNode.left = null;
                }
                return false;
            }
            else if (value.CompareTo(currentNode.value) > 0)
            {
                if( Delete(value, currentNode.right))
                {
                    currentNode.right = null;
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Contains(T value)
        {
            return Contains(value, head);
        }

        private bool Contains(T value, Node currentNode)
        {
            if (currentNode == null)
                return false;

            if (value.CompareTo(currentNode.value) < 0)
                return Contains(value, currentNode.left);
            else if (value.CompareTo(currentNode.value) > 0)
                return Contains(value, currentNode.right);
            else
                return true;
        }

        public override string ToString()
        {
            return GetString(head);
        }

        private string GetString(Node current)
        {
            if(current != null)
            {
                return GetString(current.left) + current.value + "," + GetString(current.right);
            }
            return string.Empty;
        }

        private class Node
        {
            public T value;
            public Node left;
            public Node right;
        }
    }
}
