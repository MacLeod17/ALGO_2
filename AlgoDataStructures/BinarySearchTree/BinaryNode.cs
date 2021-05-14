using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures.BinarySearchTree
{
    public class BinaryNode<T> where T : IComparable
    {
        private BinaryNode<T> Left { get; set; }
        private BinaryNode<T> Right { get; set; }
        private BinaryNode<T> Parent { get; set; }

        public T Data { get; set; }

        public BinaryNode() { }
        public BinaryNode(T val)
        {
            Data = val;
        }

        public void Add(T val)
        {
            if (val.CompareTo(Data) < 0)
            {
                if (Left == null) Left = new BinaryNode<T>(val) { Parent = this }; 
                else Left.Add(val);
            }
            if (val.CompareTo(Data) > 0)
            {
                if (Right == null) Right = new BinaryNode<T>(val) { Parent = this }; 
                else Right.Add(val);
            }
        }

        // (Left, Root, Right)
        public string InOrder()
        {
            string value = string.Empty;
            if (Left != null)
            {
                value += Left.InOrder();
            }
            value += $"{Data}, ";
            if (Right != null)
            {
                value += Right.InOrder();
            }

            return value;
        }

        // (Left, Right, Root)
        public string PostOrder()
        {
            string value = string.Empty;
            if (Left != null)
            {
                value += Left.PostOrder();
            }
            if (Right != null)
            {
                value += Right.PostOrder();
            }
            value += $"{Data}, ";

            return value;
        }

        // (Root, Left, Right)
        public string PreOrder()
        {
            string value = string.Empty;
            value += $"{Data}, ";
            if (Left != null)
            {
                value += Left.PreOrder();
            }
            if (Right != null)
            {
                value += Right.PreOrder();
            }

            return value;
        }

        public bool Contains(T val)
        {
            // Check this Data if equal return true
            if (Data.Equals(val)) return true;

            //if val < data && left exists go left
                //return the return boolean
            if (Left != null && val.CompareTo(Data) < 0) return Left.Contains(val);
            //if val > data && right exists go right
                //return the return boolean
            if (Right != null && val.CompareTo(Data) > 0) return Right.Contains(val);

            return false;
        }

        public BinaryNode<T> Remove(BinaryNode<T> node, T val)
        {
            if (val.CompareTo(node.Data) < 0)
            {
                node.Left = Remove(node.Left, val);
            }
            else if (val.CompareTo(node.Data) > 0)
            {
                node.Right = Remove(node.Right, val);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }
                node.Data = MaxValue(node.Left);
                node.Left = Remove(node.Left, node.Data);
            }

            return node;
        }

        public T MaxValue(BinaryNode<T> node)
        {
            while (node.Right != null) node = node.Right;

            return node.Data;
        }

        public int ToArray(T[] newArrayWithData, int index)
        {
            // Left Root Right
            if (Left != null)
            {
                index = Left.ToArray(newArrayWithData, index);
            }
            // Assign Value To Array
            newArrayWithData[index++] = Data;
            if (Right != null)
            {
                index = Right.ToArray(newArrayWithData, index);
            }

            return index;
        }

        public int Height()
        {
            //if no children return (1 I guess?)
            if (Left == null && Right == null) return 1;

            //leftMaxSize = 0;
            //rightMaxSize = 0;
            int leftMaxSize = 0;
            int rightMaxSize = 0;

            //check if left not null
                //leftMaxSize = left.Height()
            if (Left != null) leftMaxSize = Left.Height();
            //check if right not null
                //rightMaxSize = right.Height()
            if (Right != null) rightMaxSize = Right.Height();

            return Math.Max(leftMaxSize, rightMaxSize) + 1;
        }
    }
}
