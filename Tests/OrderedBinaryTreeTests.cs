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
        private OrderedBinarySearchTree Tree { get; set; }

        [SetUp]
        public void SetUp()
        {
            Tree = new OrderedBinarySearchTree(new BinaryTreeNode(5));
        }

        [Test]
        public void ConstructorTest_CreateNewOrderedBinaryTree()
        {
            Assert.AreEqual(5, Tree.Root.Key);
            Assert.IsNull(Tree.Root.Left);
            Assert.IsNull(Tree.Root.Right);
        }

        #region Insert

        [Test]
        public void InsertTest_InsertSingle_LessThanRoot()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(4, Tree.Root.Left.Key);
        }

        [Test]
        public void InsertTest_InsertSingleDuplicate_EqualToRoot()
        {
            Assert.IsFalse(Tree.Insert(new BinaryTreeNode(5)));
            Assert.IsNull(Tree.Root.Left);
        }

        [Test]
        public void InsertTest_InsertSingle_GreaterThanRoot()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(6, Tree.Root.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_GreaterAndLessThanRoot()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(6, Tree.Root.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_GreaterAndLessThanRoot_InReverseOrder()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(6, Tree.Root.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_GreaterAndLessThanRoot_LastIsDuplicate()
        {
            Assert.IsTrue(Tree.Insert(new BinaryTreeNode(4)));
            Assert.IsTrue(Tree.Insert(new BinaryTreeNode(6)));
            Assert.IsFalse(Tree.Insert(new BinaryTreeNode(6)));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(6, Tree.Root.Right.Key);
            Assert.IsNull(Tree.Root.Right.Right);
            Assert.IsNull(Tree.Root.Right.Left);

        }

        [Test]
        public void InsertTest_InsertTwo_GreaterAndLessThanRoot_InReverseOrder_LastIsDuplicate()
        {
            Assert.IsTrue(Tree.Insert(new BinaryTreeNode(6)));
            Assert.IsTrue(Tree.Insert(new BinaryTreeNode(4)));
            Assert.IsFalse(Tree.Insert(new BinaryTreeNode(4)));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(6, Tree.Root.Right.Key);
            Assert.IsNull(Tree.Root.Left.Left);
            Assert.IsNull(Tree.Root.Left.Right);
        }

        [Test]
        public void InsertTest_InsertTwo_BothLessThanRoot_SecondGreaterThanFirst()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(3, Tree.Root.Left.Key);
            Assert.AreEqual(4, Tree.Root.Left.Right.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_BothLessThanRoot_FirstGreaterThanSecond()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(3, Tree.Root.Left.Left.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_BothgreaterThanRoot_FirstGreaterThanSecond()
        {
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(7, Tree.Root.Right.Key);
            Assert.AreEqual(6, Tree.Root.Right.Left.Key);
        }

        [Test]
        public void InsertTest_InsertTwo_BothgreaterThanRoot_SecondGreaterThanFirst()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(6, Tree.Root.Right.Key);
            Assert.AreEqual(7, Tree.Root.Right.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftLeftLeft()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(2));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(3, Tree.Root.Left.Left.Key);
            Assert.AreEqual(2, Tree.Root.Left.Left.Left.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftLeftRight()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(2, Tree.Root.Left.Left.Key);
            Assert.AreEqual(3, Tree.Root.Left.Left.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftRightLeft()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(2, Tree.Root.Left.Key);
            Assert.AreEqual(4, Tree.Root.Left.Right.Key);
            Assert.AreEqual(3, Tree.Root.Left.Right.Left.Key);
        }

        [Test]
        public void InsertTest_InsertThree_LeftRightRight()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(2, Tree.Root.Left.Key);
            Assert.AreEqual(3, Tree.Root.Left.Right.Key);
            Assert.AreEqual(4, Tree.Root.Left.Right.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightRightRight()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Assert.AreEqual(6, Tree.Root.Right.Key);
            Assert.AreEqual(7, Tree.Root.Right.Right.Key);
            Assert.AreEqual(8, Tree.Root.Right.Right.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightRightLeft()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(6, Tree.Root.Right.Key);
            Assert.AreEqual(8, Tree.Root.Right.Right.Key);
            Assert.AreEqual(7, Tree.Root.Right.Right.Left.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightLeftRight()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(8, Tree.Root.Right.Key);
            Assert.AreEqual(6, Tree.Root.Right.Left.Key);
            Assert.AreEqual(7, Tree.Root.Right.Left.Right.Key);
        }

        [Test]
        public void InsertTest_InsertThree_RightLeftLeft()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(8, Tree.Root.Right.Key);
            Assert.AreEqual(7, Tree.Root.Right.Left.Key);
            Assert.AreEqual(6, Tree.Root.Right.Left.Left.Key);
        }

        #endregion

        #region Count

        [Test]
        public void CountTest_InsertThree_LeftLeftLeft()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(2));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_LeftLeftRight()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_LeftRightLeft()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_LeftRightRight()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightRightRight()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightRightLeft()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightLeftRight()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_InsertThree_RightLeftLeft()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(3, Tree.Count());
        }

        [Test]
        public void CountTest_Is5_5Inserts()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(5, Tree.Count());
        }

        [Test]
        public void CountTest_Is6_6Inserts()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Assert.AreEqual(6, Tree.Count());
        }

        [Test]
        public void CountTest_Is7_RightHeavy()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(9));
            Tree.Insert(new BinaryTreeNode(10));
            Assert.AreEqual(7, Tree.Count());
        }

        [Test]
        public void CountTest_Is6_RightLeftWings()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(1));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(9));
            Assert.AreEqual(6, Tree.Count());
        }

        [Test]
        public void CountTest_Is8_LeftInnerWing()
        {
            Tree.Insert(new BinaryTreeNode(0));
            Tree.Insert(new BinaryTreeNode(-11));
            Tree.Insert(new BinaryTreeNode(-12));
            Tree.Insert(new BinaryTreeNode(-10));
            Tree.Insert(new BinaryTreeNode(-9));
            Tree.Insert(new BinaryTreeNode(-8));
            Tree.Insert(new BinaryTreeNode(-7));
            Tree.Insert(new BinaryTreeNode(-6));
            Assert.AreEqual(8, Tree.Count());
        }

        [Test]
        public void CountTest_Is8_SpreadEagle()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(1));
            Tree.Insert(new BinaryTreeNode(9));
            Assert.AreEqual(8, Tree.Count());
        }

        [Test]
        public void CountTest_Is10_LongAndLanky()
        {
            Tree.Insert(new BinaryTreeNode(-20));
            Tree.Insert(new BinaryTreeNode(20));
            Tree.Insert(new BinaryTreeNode(-15));
            Tree.Insert(new BinaryTreeNode(10));
            Tree.Insert(new BinaryTreeNode(-10));
            Tree.Insert(new BinaryTreeNode(15));
            Tree.Insert(new BinaryTreeNode(-12));
            Tree.Insert(new BinaryTreeNode(12));
            Tree.Insert(new BinaryTreeNode(-11));
            Tree.Insert(new BinaryTreeNode(13));
            Assert.AreEqual(10, Tree.Count());
        }

#endregion

        #region Find

        [Test]
        public void FindTest_InsertNone_IsNull()
        {
            Assert.IsNull(Tree.Find(4));
        }

        [Test]
        public void FindTest_InsertNone_IsNotNull()
        {
            Assert.IsNotNull(Tree.Find(5));
        }

        #region Last Node Not Null

        [Test]
        public void FindTest_InsertThree_LeftLeftLeft_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(2));
            Assert.IsNotNull(Tree.Find(2));
        }

        [Test]
        public void FindTest_InsertThree_LeftLeftRight_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.IsNotNull(Tree.Find(3));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightLeft_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.IsNotNull(Tree.Find(3));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightRight_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.IsNotNull(Tree.Find(4));
        }

        [Test]
        public void FindTest_InsertThree_RightRightRight_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Assert.IsNotNull(Tree.Find(8));
        }

        [Test]
        public void FindTest_InsertThree_RightRightLeft_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.IsNotNull(Tree.Find(7));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftRight_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.IsNotNull(Tree.Find(7));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftLeft_IsNotNull()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.IsNotNull(Tree.Find(6));
        }

        #endregion

        #region Middle Node Not Null

        [Test]
        public void FindTest_InsertThree_LeftLeftLeft_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(2));
            Assert.IsNotNull(Tree.Find(3));
        }

        [Test]
        public void FindTest_InsertThree_LeftLeftRight_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.IsNotNull(Tree.Find(2));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightLeft_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.IsNotNull(Tree.Find(4));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightRight_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.IsNotNull(Tree.Find(3));
        }

        [Test]
        public void FindTest_InsertThree_RightRightRight_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Assert.IsNotNull(Tree.Find(7));
        }

        [Test]
        public void FindTest_InsertThree_RightRightLeft_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.IsNotNull(Tree.Find(8));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftRight_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.IsNotNull(Tree.Find(6));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftLeft_IsNotNull_MiddleNode()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.IsNotNull(Tree.Find(7));
        }

        #endregion

        #region End Node Is Null

        [Test]
        public void FindTest_InsertThree_LeftLeftRight_IsNull()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.IsNull(Tree.Find(99));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightLeft_IsNull()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.IsNull(Tree.Find(99));
        }

        [Test]
        public void FindTest_InsertThree_LeftRightRight_IsNull()
        {
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.IsNull(Tree.Find(99));
        }

        [Test]
        public void FindTest_InsertThree_RightRightRight_IsNull()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Assert.IsNull(Tree.Find(99));
        }

        [Test]
        public void FindTest_InsertThree_RightRightLeft_IsNull()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.IsNull(Tree.Find(99));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftRight_IsNull()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.IsNull(Tree.Find(99));
        }

        [Test]
        public void FindTest_InsertThree_RightLeftLeft_IsNull()
        {
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.IsNull(Tree.Find(99));
        }

        #endregion

        #endregion

        #region Depth

        [Test]
        public void DepthTest_Is0_0Inserts()
        {
            Assert.AreEqual(0, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is1_1Insert()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(1, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is1_2Inserts()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(1, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is2_2Inserts()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(2, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is2_3Inserts()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(2, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is2_4Inserts()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(2, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is2_5Inserts()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(2, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is2_6Inserts()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Assert.AreEqual(2, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is5_RightHeavy()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(9));
            Tree.Insert(new BinaryTreeNode(10));
            Assert.AreEqual(5, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is5_RightLeftWings()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(1));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(9));
            Assert.AreEqual(3, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is5_LeftInnerWing()
        {
            Tree.Insert(new BinaryTreeNode(0));
            Tree.Insert(new BinaryTreeNode(-11));
            Tree.Insert(new BinaryTreeNode(-12));
            Tree.Insert(new BinaryTreeNode(-10));
            Tree.Insert(new BinaryTreeNode(-9));
            Tree.Insert(new BinaryTreeNode(-8));
            Tree.Insert(new BinaryTreeNode(-7));
            Tree.Insert(new BinaryTreeNode(-6));
            Assert.AreEqual(7, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is4_SpreadEagle()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(8));
            Tree.Insert(new BinaryTreeNode(1));
            Tree.Insert(new BinaryTreeNode(9));
            Assert.AreEqual(4, Tree.Depth());
        }

        [Test]
        public void DepthTest_Is5_LongAndLanky()
        {
            Tree.Insert(new BinaryTreeNode(-20));
            Tree.Insert(new BinaryTreeNode(20));
            Tree.Insert(new BinaryTreeNode(-15));
            Tree.Insert(new BinaryTreeNode(10));
            Tree.Insert(new BinaryTreeNode(-10));
            Tree.Insert(new BinaryTreeNode(15));
            Tree.Insert(new BinaryTreeNode(-12));
            Tree.Insert(new BinaryTreeNode(12));
            Tree.Insert(new BinaryTreeNode(-11));
            Tree.Insert(new BinaryTreeNode(13));
            Assert.AreEqual(5, Tree.Depth());
        }

        #endregion

        #region Delete

        [Test]
        public void DeleteTest()
        {
            Assert.Catch<Exception>(()=>Tree.Delete(5));
            Assert.AreEqual(5, Tree.Root.Key);
        }

        [Test]
        public void DeleteTest_RootLeft()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.True(Tree.Delete(4));
            Assert.IsNull(Tree.Root.Left);
        }

        [Test]
        public void DeleteTest_RootRight()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Assert.AreEqual(6, Tree.Root.Right.Key);
            Assert.True(Tree.Delete(6));
            Assert.IsNull(Tree.Root.Right);
        }

        [Test]
        public void DeleteTest_RootLeftLeft()
        {
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(3));
            Assert.AreEqual(4, Tree.Root.Left.Key);
            Assert.AreEqual(3, Tree.Root.Left.Left.Key);
            Assert.True(Tree.Delete(4));
            Assert.IsNull(Tree.Root.Left.Left);
            Assert.AreEqual(3, Tree.Root.Left.Key);
        }

        [Test]
        public void DeleteTest_RootRightRight()
        {
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(7));
            Assert.AreEqual(6, Tree.Root.Right.Key);
            Assert.AreEqual(7, Tree.Root.Right.Right.Key);
            Assert.True(Tree.Delete(6));
            Assert.IsNull(Tree.Root.Right.Right);
            Assert.AreEqual(7, Tree.Root.Right.Key);
        }

        #endregion

        #region Print

        [Test]
        [Ignore]
        public void PrintTest()
        {
            Tree.Insert(new BinaryTreeNode(-20));
            Tree.Insert(new BinaryTreeNode(20));
            Tree.Insert(new BinaryTreeNode(-15));
            Tree.Insert(new BinaryTreeNode(10));
            Tree.Insert(new BinaryTreeNode(-10));
            Tree.Insert(new BinaryTreeNode(15));
            Tree.Insert(new BinaryTreeNode(-12));
            Tree.Insert(new BinaryTreeNode(12));
            Tree.Insert(new BinaryTreeNode(-11));
            Tree.Insert(new BinaryTreeNode(13));
            Console.WriteLine(Tree.Print());
        }

        [Test]
        public void PrintTest2()
        {
            Tree.Insert(new BinaryTreeNode(3));
            Tree.Insert(new BinaryTreeNode(7));
            Tree.Insert(new BinaryTreeNode(2));
            Tree.Insert(new BinaryTreeNode(4));
            Tree.Insert(new BinaryTreeNode(6));
            Tree.Insert(new BinaryTreeNode(8));
            Console.WriteLine(Tree.Print());
        }

        [Test]
        public void MergeTest()
        {
            Dictionary<int, Queue<BinaryTreeNode>> d1 = new Dictionary<int, Queue<BinaryTreeNode>>();
            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(new BinaryTreeNode(1));
            queue.Enqueue(new BinaryTreeNode(2));
            queue.Enqueue(new BinaryTreeNode(3));
            d1.Add(0, queue);

            Dictionary<int, Queue<BinaryTreeNode>> d2 = new Dictionary<int, Queue<BinaryTreeNode>>();
            var queue2 = new Queue<BinaryTreeNode>();
            queue2.Enqueue(new BinaryTreeNode(-1));
            queue2.Enqueue(new BinaryTreeNode(-2));
            queue2.Enqueue(new BinaryTreeNode(-3));
            d2.Add(0, queue2);

            var d3 = d1.Merge(d2);
            Console.WriteLine(d3.Pretty());

            Assert.AreEqual(1, d3[0].Dequeue().Key);
            Assert.AreEqual(2, d3[0].Dequeue().Key);
            Assert.AreEqual(3, d3[0].Dequeue().Key);
            Assert.AreEqual(-1, d3[0].Dequeue().Key);
            Assert.AreEqual(-2, d3[0].Dequeue().Key);
            Assert.AreEqual(-3, d3[0].Dequeue().Key);
        }

        #endregion
    }
}
