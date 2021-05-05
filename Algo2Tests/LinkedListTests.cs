using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AlgoDataStructures;

namespace Algo2Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void SLL_EmptyList()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            int expectedCount = 0;
            int actualCount = list.Count;
            string expectedString = "";
            string actualString = list.ToString();
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_Methods()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Insert(1, 0);
            var count = list.Count;
            var value = list.Get(0);
            var removed = list.Remove();
            var last = list.RemoveLast();
            var listString = list.ToString();
            list.Clear();
            var index = list.Search(1);
        }

        [TestMethod]
        public void DLL_AddTest()
        {
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();

            dll.Add(10);

            Assert.AreEqual(1, dll.Count);
        }
    }
}