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

        public DNode() { }

        public DNode(T val)
        {
            Value = val;
        }
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

            DNode<T> newNode = new DNode<T>(val);

            if (Head == null) Head = newNode;

            else
            {
                DNode<T> tail = Head;

                while (tail.Next != null)
                {
                    tail = tail.Next;
                }

                tail.Next = newNode;
                newNode.Previous = tail;
            }
            Count++;
        }

        /* Removes all values in the list */
        public void Clear()
        {
            /*
            Set Head to Null and everything will die
            */

            Head = null;
            Count = 0;
        }

        /* Returns the value at the given index. Any index less than zero or equal 
         * to or greater than Count should throw an index out of bounds exception */
        public T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            DNode<T> node = Head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Value;
        }

        /* Inserts a new value at a given index, pushing the existing value at that index to the next index spot, and so on. 
         * Insert may ONLY target indices that are currently in use. In other words, if you have 5 elements in your list, 
         * you may insert at any index between 0 and 4 inclusive. Index 5 would be considered out of bounds as it is not 
         * currently in use during the insertion process. Any index less than zero or equal to or greater than Count should 
         * throw an index out of bounds exception */
        public void Insert(T val, int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            DNode<T> newNode = new DNode<T>(val);
            if (index == 0)
            {
                Head.Previous = newNode;
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            DNode<T> prevNode = Head;

            int currentIndex = 1;
            while (currentIndex < index)
            {
                prevNode = prevNode.Next;
                currentIndex++;
            }

            newNode.Next = prevNode.Next;
            var nextNode = prevNode.Next;
            nextNode.Previous = newNode;
            prevNode.Next = newNode;
            Count++;
        }

        /* Removes and returns the first value in the list */
        public T Remove()
        {
            /*
            Store The First Value
            head = head.next
            return firstValue
            */

            T value = Head.Value;
            Head = Head.Next;
            Head.Previous = null;
            Count--;

            return value;
        }

        /* Removes and returns the value at a given index. Any index less than zero or 
         * equal to or greater than Count should throw an index out of bounds exception */
        public T RemoveAt(int index)
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
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            T value;
            if (index == 0)
            {
                value = Head.Value;
                Head = Head.Next;
                Count--;
                return value;
            }

            DNode<T> prevNode = Head;

            int currentIndex = 0;
            while (currentIndex < index - 1)
            {
                prevNode = prevNode.Next;
                currentIndex++;
            }

            value = prevNode.Next.Value;
            prevNode.Next = prevNode.Next.Next;
            if (prevNode.Next != null)
            {
                var nextNode = prevNode.Next.Next;
                nextNode.Previous = prevNode;
            }
            Count--;

            return value;
        }

        /* Removes and returns the last value in the list */
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
            if (Head == null)
            {
                return default;
            }

            T value;
            if (Head.Next == null)
            {
                value = Head.Value;
                Head = null;
                return value;
            }

            DNode<T> secondToLast = Head;

            while (secondToLast.Next.Next != null)
            {
                secondToLast = secondToLast.Next;
            }

            value = secondToLast.Next.Value;
            secondToLast.Next = null;
            Count--;

            return value;
        }

        /* Searches for a value in the list and returns the first index of that value 
         * when found. If the key is not found in the list, the method returns -1 */
        public int Search(T val)
        {
            int index = -1;

            DNode<T> node = Head;

            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(val))
                {
                    index = i;
                    break;
                }
                node = node.Next;
            }

            return index;
        }

        public override string ToString()
        {
            string list = string.Empty;

            if (Head == null) return list;

            DNode<T> node = Head;

            list += node.Value;
            node = node.Next;

            while (node != null)
            {
                list += $", {node.Value}";
                node = node.Next;
            }

            return list;
        }
    }
}
