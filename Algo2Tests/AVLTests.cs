using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;
using System.Linq;

namespace AVLUnitTester
{
    [TestClass]
    public class AVLUnitTests
    {
        [TestMethod]
        public void AddOneValueToEmptyTree()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(10);

            string expected = "10";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesToTree()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesSingleRightRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(1337);
            avl.Add(24);
            avl.Add(10);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesSingleLeftRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(10);
            avl.Add(24);
            avl.Add(1337);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesDoubleLeftRightRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(1337);
            avl.Add(10);
            avl.Add(24);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesDoubleRightLeftRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(10);
            avl.Add(1337);
            avl.Add(24);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddManyValuesNoRotations()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            string expected = "24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);                        
        }

        [TestMethod]
        public void AddManyValuesInDescendingOrder()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(1500);
            avl.Add(1400);
            avl.Add(1350);
            avl.Add(1337);
            avl.Add(110);
            avl.Add(100);
            avl.Add(90);
            avl.Add(24);
            avl.Add(13);
            avl.Add(12);
            avl.Add(11);
            avl.Add(10);
            avl.Add(9);
            avl.Add(8);
            avl.Add(7);

            string expected = "24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddManyValuesInAscendingOrder()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(7);
            avl.Add(8);
            avl.Add(9);
            avl.Add(10);
            avl.Add(11);
            avl.Add(12);
            avl.Add(13);
            avl.Add(24);
            avl.Add(90);
            avl.Add(100);
            avl.Add(110);
            avl.Add(1337);
            avl.Add(1350);
            avl.Add(1400);
            avl.Add(1500);

            string expected = "24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddManyValuesWithDoubleRotations()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(100);
            avl.Add(90);
            avl.Add(7);
            avl.Add(8);
            avl.Add(9);
            avl.Add(12);
            avl.Add(13);
            avl.Add(10);
            avl.Add(11);
            avl.Add(110);
            avl.Add(1400);
            avl.Add(1337);
            avl.Add(1350);
            avl.Add(1500);

            string expected = "12, 9, 100, 8, 10, 24, 1337, 7, 11, 13, 90, 110, 1400, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLeftLeaf()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);

            avl.Remove(10);

            string expected = "24, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRightLeaf()
        {
            AVLTree<int> avl = new AVLTree<int>();

            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);

            avl.Remove(1337);

            string expected = "24, 10";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRoot()
        {
            AVLTree<int> avl = new AVLTree<int>();

            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);

            avl.Remove(24);

            string expected = "1337, 10";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLeftBranchRoot()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(10);

            string expected = "24, 11, 1337, 8, 12, 100, 1400, 7, 9, 13, 90, 110, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRightBranchRoot()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(1337);

            string expected = "24, 10, 1350, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRootFromLargeTree()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(24);

            string expected = "90, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 110, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

       

        [TestMethod]
        public void CountIsCorrectAfterAdd()
        {
            AVLTree<int> avl = new AVLTree<int>();
            int expected = 15;

            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            Assert.AreEqual(expected, avl.Count);
        }

        [TestMethod]
        public void CountIsCorrectAfterRemove()
        {
            AVLTree<int> avl = new AVLTree<int>();
            int expected = 14;

            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(10);

            Assert.AreEqual(expected, avl.Count);
        }

        [TestMethod]
        public void CountIsCorrectAfterAddRemoveAdd()
        {
            AVLTree<int> avl = new AVLTree<int>();
            int expected = 13;

            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(10);
            avl.Remove(1337);
            avl.Remove(24);

            avl.Add(1842);

            Assert.AreEqual(expected, avl.Count);
        }

        [TestMethod]
        public void ToArraySequenceIsCorrect()
        {
            AVLTree<int> avl = new AVLTree<int>();
            int[] expectedArr = { 24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500 };

            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            string expected = ArrayToString(expectedArr);
            string actual = ArrayToString(avl.ToArray());
            Assert.AreEqual(expected, actual);
        }

        private string ArrayToString(int[] a)
        {
            StringBuilder sb = new StringBuilder();

            if (a.Length > 0)
            {
                sb.Append(a[0]);
                for (int i = 1; i < a.Length; i++)
                {
                    sb.Append(", ");
                    sb.Append(a[i]);
                }

            }

            return sb.ToString();
        }
    }
}
