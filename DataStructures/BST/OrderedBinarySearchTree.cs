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
                if (!Root.HasLeft)
                    Root.Left = node;
                else
                    Insert(Root.Left, node);
            }
            else
            {
                if (!Root.HasRight)
                    Root.Right = node;
                else
                    Insert(Root.Right, node);
            }
        }

        private void Insert(BinaryTreeNode parent, BinaryTreeNode node)
        {
            if (node.Key <= parent.Key)
            {
                if (!parent.HasLeft)
                    parent.Left = node;
                else
                    Insert(parent.Left, node);
            }
            else
            {
                if (!parent.HasRight)
                    parent.Right = node;
                else
                    Insert(parent.Right, node);
            }
        }

        public void Delete(BinaryTreeNode node)
        {
            throw new System.NotImplementedException();
        }

        public BinaryTreeNode Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            return CountHelper(Root);
        }

        private int CountHelper(BinaryTreeNode node)
        {
            if (!node.HasLeft)
                if (!node.HasRight)
                    return 0;
                else
                    return CountHelper(node.Right) + 1;
            else
                return CountHelper(node.Left) + 1;
        }
    }
}