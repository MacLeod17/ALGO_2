using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class DNode<T>
    {
        public T Value { get; set; }
        public DNode<T> Next { get; set; }
        public DNode<T> Previous { get; set; }
    }

    public class DoubleLinkedList<T> where T : IComparable<T>
    {
        public int Count { get; set; }
        public DNode<T> Head { get; set; }

        public void Add(T val)
        {
            /*
            Create a Node
            if (head == null)
                head = new Node

            Count++
            */
        }

        public void Clear()
        {
            /*
            Set Head to Null and everything will die
            */
        }

        public T Get(int index)
        {
            return default;
        }

        public T Insert(T val, int index)
        {
            return default;
        }

        public T Remove()
        {
            /*
            Store The First Value
            head = head.next
            return firstValue
            */

            return default;
        }

        public T RemoveAt(int value)
        {
            /*
            indexToFind = x
            if (indexToFind < 0 || indexToFind >= count)
                throw error

            index = 0
            iterateAllNodes from Start to Stop at x-1
                index++

            returnValue = previous.next.value
            compareNode.next = previous.next?.next

            count--
            */

            return default;
        }

        public T RemoveLast()
        {
            /*
            tempNode
            nextNode = head

            while(nextNode.next != null)
                nextNode = nextNode.next

            count--

            or

            lastNode = head

            do
                lastNode = lastNode.next
            while(lastNode.next.next != null)

            or

            secondToLast.next.value
            secondToLast.next = null
            */

            return default;
        }

        public int Search(T val)
        {
            return default;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
