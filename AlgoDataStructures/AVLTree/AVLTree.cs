using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class AVLTree<T> where T : IComparable
    {
        AVLNode<T> root;

        public int Count { get; set; }

        public void Add(T val)
        {
            if (root == null) root = new AVLNode<T>(val);
            else root = root.Add(val);
            Count++;
        }

        public bool Contains(T val)
        {
            return root != null ? root.Contains(val) : false;
        }

        public void Remove(T val)
        {
            if (root != null && root.Contains(val))
            {
                root = root.Remove(root, val);
                Count--;
            }
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public string InOrder()
        {
            string inOrder = root != null ? root.InOrder() : string.Empty;

            return inOrder.Remove(inOrder.Length - 2);
        }

        public string PreOrder()
        {
            string preOrder = root != null ? root.PreOrder() : string.Empty;

            return preOrder.Remove(preOrder.Length - 2);
        }

        public string PostOrder()
        {
            string postOrder = root != null ? root.PostOrder() : string.Empty;

            return postOrder.Remove(postOrder.Length - 2);
        }

        public int Height()
        {
            return root != null ? root.Height() : 0;
        }

        public T[] ToArray()
        {
            if (root != null)
            {
                int numLevels = root.Height();
                int index = 0;

                T[] arr = new T[Count];

                for (int i=0; i < numLevels; i++)
                {
                    index = root.ToArray(arr, i, index);
                }

                return arr;
            }

            return null;
        }
    }
}
