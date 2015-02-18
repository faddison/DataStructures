using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Graphs.BST;

namespace Tests
{
    [TestFixture]
    class OrderedBinaryTreeTests
    {
        private OrderedBinarySearchTree tree { get; set; }

        [SetUp]
        public void SetUp()
        {
            tree = new OrderedBinarySearchTree(new BinaryTreeNode(5));
        }

        [Test]
        public void ConstructorTest_CreateNewOrderedBinaryTree()
        {
            Assert.AreEqual(5, tree.Root.Key);
            Assert.IsNull(tree.Root.Left);
            Assert.IsNull(tree.Root.Right);
        }

        [Test]
        public void InsertTest_InsertSingle_LessThanRoot()
        {
            tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(4, tree.Root.Left.Key);
        }

        [Test]
        public void InsertTest_InsertSingle_EqualToRoot()
        {
            tree.Insert(new BinaryTreeNode(5));
            Assert.AreEqual(5, tree.Root.Left.Key);
        }

        [Test]
        public void InsertTest_InsertSingle_GreaterThanRoot()
        {
            tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(6, tree.Root.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_GreaterAndLessThanRoot()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(4, tree.Root.Left.Key);
            Assert.AreEqual(6, tree.Root.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_GreaterAndLessThanRoot_InReverseOrder()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(4, tree.Root.Left.Key);
            Assert.AreEqual(6, tree.Root.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_BothLessThanRoot_SecondGreaterThanFirst()
        {
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(3, tree.Root.Left.Key);
            Assert.AreEqual(4, tree.Root.Left.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_BothLessThanRoot_FirstGreaterThanSecond()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(4, tree.Root.Left.Key);
            Assert.AreEqual(3, tree.Root.Left.Left.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_BothgreaterThanRoot_FirstGreaterThanSecond()
        {
            tree.Insert(new BinaryTreeNode(7));
            tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(7, tree.Root.Right.Key);
            Assert.AreEqual(6, tree.Root.Right.Left.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_BothgreaterThanRoot_SecondGreaterThanFirst()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(6, tree.Root.Right.Key);
            Assert.AreEqual(7, tree.Root.Right.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftLeftLeft()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(2));
            Assert.AreEqual(4, tree.Root.Left.Key);
            Assert.AreEqual(3, tree.Root.Left.Left.Key);
            Assert.AreEqual(2, tree.Root.Left.Left.Left.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftLeftRight()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(4, tree.Root.Left.Key);
            Assert.AreEqual(2, tree.Root.Left.Left.Key);
            Assert.AreEqual(3, tree.Root.Left.Left.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftRightLeft()
        {
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(2, tree.Root.Left.Key);
            Assert.AreEqual(4, tree.Root.Left.Right.Key);
            Assert.AreEqual(3, tree.Root.Left.Right.Left.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftRightRight()
        {
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(2, tree.Root.Left.Key);
            Assert.AreEqual(3, tree.Root.Left.Right.Key);
            Assert.AreEqual(4, tree.Root.Left.Right.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightRightRight()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(7));
            tree.Insert(new BinaryTreeNode(8));
            Assert.AreEqual(6, tree.Root.Right.Key);
            Assert.AreEqual(7, tree.Root.Right.Right.Key);
            Assert.AreEqual(8, tree.Root.Right.Right.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightRightLeft()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(6, tree.Root.Right.Key);
            Assert.AreEqual(8, tree.Root.Right.Right.Key);
            Assert.AreEqual(7, tree.Root.Right.Right.Left.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightLeftRight()
        {
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(8, tree.Root.Right.Key);
            Assert.AreEqual(6, tree.Root.Right.Left.Key);
            Assert.AreEqual(7, tree.Root.Right.Left.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightLeftLeft()
        {
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(7));
            tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(8, tree.Root.Right.Key);
            Assert.AreEqual(7, tree.Root.Right.Left.Key);
            Assert.AreEqual(6, tree.Root.Right.Left.Left.Key);
        }

        [Test]
        public void CountTest_InsertThree_LeftLeftLeft()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(2));
            Assert.AreEqual(3, tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_LeftLeftRight()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(3, tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_LeftRightLeft()
        {
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(3, tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_LeftRightRight()
        {
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(3, tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightRightRight()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(7));
            tree.Insert(new BinaryTreeNode(8));
            Assert.AreEqual(3, tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightRightLeft()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(3, tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightLeftRight()
        {
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(3, tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightLeftLeft()
        {
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(7));
            tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(3, tree.Count());
        }


        [Test]
        public void FindTest_InsertThree_LeftLeftLeft()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(2));
            Assert.IsNotNull(tree.Find(2));
        }

        [Test]
        public void FindTest_InsertThree_LeftLeftRight()
        {
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(3));
            Assert.IsNotNull(tree.Find(3));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightLeft()
        {
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(4));
            tree.Insert(new BinaryTreeNode(3));
            Assert.IsNotNull(tree.Find(3));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightRight()
        {
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(4));
            Assert.IsNotNull(tree.Find(4));
        }

        [Test]
        public void FindTest_InsertThree_RightRightRight()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(7));
            tree.Insert(new BinaryTreeNode(8));
            Assert.IsNotNull(tree.Find(8));
        }

        [Test]
        public void FindTest_InsertThree_RightRightLeft()
        {
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(7));
            Assert.IsNotNull(tree.Find(7));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftRight()
        {
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(6));
            tree.Insert(new BinaryTreeNode(7));
            Assert.IsNotNull(tree.Find(7));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftLeft()
        {
            tree.Insert(new BinaryTreeNode(8));
            tree.Insert(new BinaryTreeNode(7));
            tree.Insert(new BinaryTreeNode(6));
            Assert.IsNotNull(tree.Find(6));
        }
    }
}
