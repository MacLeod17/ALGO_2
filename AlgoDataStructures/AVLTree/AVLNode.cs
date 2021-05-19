using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class AVLNode<T> where T : IComparable
    {
        private AVLNode<T> Left { get; set; }
        private AVLNode<T> Right { get; set; }
        private AVLNode<T> Parent { get; set; }

        public T Data { get; set; }

        public AVLNode() { }
        public AVLNode(T val)
        {
            Data = val;
        }

        #region AVL Methods
        public void Add(T val)
        {
            // Not Modified Yet
            if (val.CompareTo(Data) < 0)
            {
                if (Left == null) Left = new AVLNode<T>(val) { Parent = this };
                else Left.Add(val);
            }
            if (val.CompareTo(Data) > 0)
            {
                if (Right == null) Right = new AVLNode<T>(val) { Parent = this };
                else Right.Add(val);
            }
        }

        public AVLNode<T> RR_Rotation(AVLNode<T> unbalanced)
        {
            AVLNode<T> pivot = unbalanced.Left;

            unbalanced.Left = pivot.Right;
            pivot.Right = unbalanced;

            return pivot;
        }

        public AVLNode<T> LL_Rotation(AVLNode<T> unbalanced)
        {
            AVLNode<T> pivot = unbalanced.Right;

            unbalanced.Right = pivot.Left;
            pivot.Left = unbalanced;

            return pivot;
        }

        public AVLNode<T> RL_Rotation(AVLNode<T> unbalanced)
        {
            // Not Modified Yet
            return default;
        }

        public AVLNode<T> LR_Rotation(AVLNode<T> unbalanced)
        {
            // Not Modified Yet
            return default;
        }

        public int ToArray(T[] newArrayWithData, int index)
        {
            // Not Modified Yet

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
        #endregion

        #region Unmodified BST Methods
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

        public AVLNode<T> Remove(AVLNode<T> node, T val)
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

        public T MaxValue(AVLNode<T> node)
        {
            while (node.Right != null) node = node.Right;

            return node.Data;
        }

        public int Height()
        {
            //if no children return 0
            /* I changed it to return 1 because A: that made the test pass, and B: I figured that needed to be done 
             * so that when there are no children the current node is still accounted for (similar to doing the +1
             * after the Math.Max). */
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
        #endregion
    }
}
