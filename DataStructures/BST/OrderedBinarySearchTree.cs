// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="OrderedBinarySearchTree.cs" company="Homewood Human Solutions">
// // This file is subject to the terms and conditions defined in file 'LICENSE.txt', 
// // which is part of this source code package.
// // </copyright>
// // <author>Fraser Addison</author>
// // <created>16-02-2015</created>
// //
// // <summary>
// // The BalancedBinarySearchTree.cs
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Graphs.BST
{
    public class OrderedBinarySearchTree : IBinarySearchTree
    {
        public BinaryTreeNode Root { get; private set; }

        public OrderedBinarySearchTree(BinaryTreeNode node)
        {
            Root = node;
        }

        public void Insert(BinaryTreeNode node)
        {
            if (node.Key <= Root.Key)
            {
                if (Root.Left == null)
                    Root.Left = node;
                else
                    Insert(Root.Left, node);
            }
            else
            {
                if (Root.Right == null)
                    Root.Right = node;
                else
                    Insert(Root.Right, node);
            }
        }

        private void Insert(BinaryTreeNode parent, BinaryTreeNode node)
        {
            if (node.Key <= parent.Key)
            {
                if (parent.Left == null)
                    parent.Left = node;
                else
                    Insert(parent.Left, node);
            }
            else
            {
                if (parent.Right == null)
                    parent.Right = node;
                else
                    Insert(parent.Right, node);
            }
        }

        public void Delete(BinaryTreeNode node)
        {
            throw new System.NotImplementedException();
        }

        public BinaryTreeNode Find(BinaryTreeNode node)
        {
            throw new System.NotImplementedException();
        }
    }
}