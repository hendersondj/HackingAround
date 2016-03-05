using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
	// more
    // things to test
    // writing sort methods - bubble sort, merge sort, quick sort, others?
    // create a priorityQueue
    // more research into hash functions and what makes a good one (string, int, objects)
    // look up google programming tests
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.TestMyArray();
            //program.TestCustomArray();
            //program.TestQueue();
            //program.TestStack();
            //program.TestLinkedList();
            //program.TestQueue();
            //program.TestHashtable();
            //program.TestBinaryTree();
            //program.TestSkipList();
            //program.TestGraph();
            program.TestLinkedListCycles();

            Console.WriteLine(program.Convert("45"));
            Console.WriteLine(program.Convert("1"));
            Console.WriteLine(program.ReverseWords("the quick brown fox".ToCharArray()));
        }

        private int Convert(string val)
        {
            char[] chars = val.ToCharArray();
            int retVal = 0;
            // error checks
            // if string empty
            // if string has non-numeric chars (or decimal point)
            // first char is negative sign
            
            for(int i = 0; i < chars.Length; i++)
            {
                retVal *= 10;
                retVal += (chars[i] - 48);
            }
            return retVal;
        }

        private char[] ReverseWords(char[] input)
        {
            // reverse entire string
            for(int i =0; i < input.Length / 2; i++)
            {
                char temp;
                temp = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = temp;
            }

            int wordBeginning = 0;
            for(int i =0; i < input.Length; i++)
            {
                if(input[i] == ' ' || i == input.Length - 1)
                {
                    int wordEnd = (i - 1);
                    for (int j = 0; j < (wordEnd-wordBeginning+1)/2; j++)
                    {
                        char temp;
                        temp = input[wordBeginning+j];
                        input[wordBeginning + j] = input[wordEnd - j];
                        input[wordEnd - j] = temp;
                    }
                    wordBeginning = i + 1;
                }
            }
            return input;
        }

        private void TestMyArray()
        {
            int size = 5;
            MyArrayList<int> array = new MyArrayList<int>(size);
            for (int i = 0; i < size; i++)
            {
                array[i] = (size - i);
            }
            array.Print();

            array.Add(9);
            array.Print();

            array.Insert(13, 0);
            array.Print();
            array.Insert(45, 7);
            array.Print();
            array.Delete(2);
            array.Print();

            Console.WriteLine("contains 45:" + array.Contains(45));
            Console.WriteLine("contains 456:" + array.Contains(456));

            array.Reverse();
            array.Print();

            array.Sort();
            array.Print();
        }

        private void TestCustomArray()
        {

            //Array.Sort(array);
            //foreach (int i in array)
            //{
            //    Console.Write(i + ",");
            //}
            //Console.WriteLine();
            //int index = Array.BinarySearch(array, 1);
            //Console.WriteLine(index);


            //int[,] mdArray = new int[4, 5];
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        mdArray[i, j] = i * j;
            //    }
            //}

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.WriteLine("Array[" + i+ ","+j+"]=" + mdArray[i,j]);
            //    }
            //}
            //Console.WriteLine();
        }

        private void TestStack()
        {
            Console.WriteLine("Stack tests");
            MyStack<int> stack = new MyStack<int>();
            stack.Push(4);
            stack.Push(45);
            stack.Push(0);
            stack.Push(2);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }

        private void TestQueue()
        {
            Console.WriteLine("Queue tests");
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(7);
            queue.Enqueue(9);
            queue.Enqueue(3);
            queue.Enqueue(5);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }

        private void TestLinkedList()
        {
            Console.WriteLine("Linked list tests");
            LinkedList<int> list = new LinkedList<int>();
            list.Add(4);
            list.Add(45);
            list.Add(6);
            list.Add(2);
            list.Add(9);
            Console.WriteLine(list.Find(45).Value);
        }

        private void TestHashtable()
        {
            Console.WriteLine("Hashtable tests");
            MyHashtable<string, string> hashtable = new MyHashtable<string, string>();

            hashtable.Add("1234", "Scott");
            hashtable.Add("2345", "Sam");
            hashtable.Add("4321", "Jisun");
            hashtable.Add("1324", "Dave");
            hashtable.Add("1432", "Jess");
            hashtable.Add("4231", "Olaf");
            hashtable.Add("4312", "Nick");
            hashtable.Add("2341", "Moose");

            Console.WriteLine(hashtable.ContainsKey("2341"));
            Console.WriteLine(hashtable["2341"]);
        }

        private void TestBinaryTree()
        {
            Console.WriteLine("binary tree tests");
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Add(4);
            tree.Add(5);
            tree.Add(3);
            tree.Add(1);
            tree.Add(2);
            Console.WriteLine(tree.ToString());
            tree.Delete(3);
            Console.WriteLine(tree.ToString());
        }

        private void TestSkipList()
        {
            Console.WriteLine("skip list tests");
            MySkipList<int> skipList = new MySkipList<int>();
            skipList.Add(5);
            skipList.Add(1);
            skipList.Add(9);
            skipList.Add(7);
            skipList.Add(6);
            skipList.Print();
        }

        private void TestGraph()
        {
        }

        private void TestLinkedListCycles()
        {
            LinkedListCycles<int> list = new LinkedListCycles<int>();
            Node<int> node = new Node<int>(5);
            Node<int> node2 = new Node<int>(6);
            Node<int> node3 = new Node<int>(7);
            Node<int> node4 = new Node<int>(8);
            list.Add(node, null);
            Console.WriteLine(list.ContainsCycles());
            list.Add(node2, node);
            Console.WriteLine(list.ContainsCycles());
            list.Add(node3, node2);
            node3.Next = node;
            Console.WriteLine(list.ContainsCycles());
        }
    }

}
