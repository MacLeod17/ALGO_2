using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Count()
        {
            int testCount = 10;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < testCount; i++)
            {
                tree.Add(i);
            }
            Assert.AreEqual(testCount, tree.Count);
        }

        [TestMethod]
        public void Add()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(0);
            tree.Add(2);
            tree.Add(1);
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void Contains()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(0);
            tree.Add(1);
            Assert.AreEqual(true, tree.Contains(1));
        }

        [TestMethod]
        public void Remove()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(4);
            tree.Add(5);
            tree.Remove(1);
            Assert.AreEqual(4, tree.Count);
            tree.Remove(3);
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void Clear()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(0);
            tree.Add(2);
            tree.Add(1);
            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void InOrder()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(3);
            Assert.AreEqual("1, 2, 3, 4, 5", tree.InOrder());
        }

        [TestMethod]
        public void PreOrder()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(3);
            Assert.AreEqual("4, 2, 1, 3, 5", tree.PreOrder());
        }

        [TestMethod]
        public void PostOrder()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(3);
            Assert.AreEqual("1, 3, 2, 5, 4", tree.PostOrder());
        }

        [TestMethod]
        public void Height()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(3);
            Assert.AreEqual(3, tree.Height());
            tree.Remove(1);
            tree.Remove(2);
            Assert.AreEqual(2, tree.Height());

        }

        [TestMethod]
        public void ToArray()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(2);
            int[] testArray = new int[] { 1, 2, 4, 5 };
            Assert.AreEqual(testArray.ToString(), tree.ToArray().ToString());
        }
    }
}