using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AlgoDataStructures;
using System;

namespace Algo2Tests
{
    //TODO: Create Test For Every SLL and DLL Method
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void SLL_AddTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            Assert.AreEqual(0, list.Count);

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(4, list.Head.Value);
            Assert.AreEqual(3, list.Head.Next.Value);
        }

        [TestMethod]
        public void SLL_InsertTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(6, -1));

            list.Add(4);
            list.Add(3);

            list.Insert(6, 1);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(6, 99));

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(6, list.Get(1));
        }

        [TestMethod]
        public void SLL_CountTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            Assert.AreEqual(0, list.Count);

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void SLL_GetTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Get(-1));

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list.Get(1));

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list.Get(3));
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Get(6));
        }

        [TestMethod]
        public void SLL_RemoveTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(4, list.Remove());
            Assert.AreEqual(1, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list.Remove());
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void SLL_RemoveAtTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(-1));

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list.RemoveAt(1));
            Assert.AreEqual(1, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(4, list.RemoveAt(0));
            Assert.AreEqual(2, list.Count);

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(5));
        }

        [TestMethod]
        public void SLL_RemoveLastTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list.RemoveLast());
            Assert.AreEqual(1, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list.RemoveLast());
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void SLL_ToStringTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            Assert.AreEqual(string.Empty, list.ToString());

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("4, 3", list.ToString());

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("4, 3, 2, 1", list.ToString());
        }

        [TestMethod]
        public void SLL_ClearTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list.Head);

            list.Add(2);
            list.Add(1);
            list.Add(16);

            Assert.AreEqual(3, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list.Head);
        }

        [TestMethod]
        public void SLL_SearchTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            list.Add(4);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(-1, list.Search(1));
            Assert.AreEqual(0, list.Search(4));

            list.Add(2);
            list.Add(1);
            list.Add(16);

            Assert.AreEqual(5, list.Search(16));
            Assert.AreEqual(-1, list.Search(96));
            Assert.AreEqual(3, list.Search(2));
        }

        [TestMethod]
        public void DLL_AddTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.AreEqual(0, list.Count);

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(4, list.Head.Value);
            Assert.AreEqual(3, list.Head.Next.Value);
        }

        [TestMethod]
        public void DLL_InsertTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(6, -1));

            list.Add(4);
            list.Add(3);

            list.Insert(6, 1);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(6, 99));

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(6, list.Get(1));
        }

        [TestMethod]
        public void DLL_CountTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.AreEqual(0, list.Count);

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void DLL_GetTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Get(-1));

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list.Get(1));

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list.Get(3));
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Get(6));
        }

        [TestMethod]
        public void DLL_RemoveTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(4, list.Remove());
            Assert.AreEqual(1, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list.Remove());
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void DLL_RemoveAtTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(-1));

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list.RemoveAt(1));
            Assert.AreEqual(1, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(4, list.RemoveAt(0));
            Assert.AreEqual(2, list.Count);

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(5));
        }

        [TestMethod]
        public void DLL_RemoveLastTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list.RemoveLast());
            Assert.AreEqual(1, list.Count);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list.RemoveLast());
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void DLL_ToStringTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.AreEqual(string.Empty, list.ToString());

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("4, 3", list.ToString());

            list.Add(2);
            list.Add(1);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("4, 3, 2, 1", list.ToString());
        }

        [TestMethod]
        public void DLL_ClearTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            list.Add(4);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list.Head);

            list.Add(2);
            list.Add(1);
            list.Add(16);

            Assert.AreEqual(3, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list.Head);
        }

        [TestMethod]
        public void DLL_SearchTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            list.Add(4);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(-1, list.Search(1));
            Assert.AreEqual(0, list.Search(4));

            list.Add(2);
            list.Add(1);
            list.Add(16);

            Assert.AreEqual(5, list.Search(16));
            Assert.AreEqual(-1, list.Search(96));
            Assert.AreEqual(3, list.Search(2));
        }
    }
}