// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BalancedBinarySearchTree.cs" company="Homewood Human Solutions">
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
    public class BalancedBinarySearchTree<T> : IBinarySearchTree
    {
        public BinaryTreeNode Root { get; private set; }

        public BalancedBinarySearchTree(BinaryTreeNode node)
        {
            Root = node;
        }

        public void Insert(BinaryTreeNode node)
        {
            if (Root.Left == null) 
                Root.Left = node;
            else if (Root.Right == null)
                Root.Right = node;
            else
            {
                InsertAt(Root.Left, node);
                InsertAt(Root.Right, node);
            }
        }

        private void InsertAt(BinaryTreeNode root, BinaryTreeNode node)
        {
            if (root.Left == null)
            {
                root.Left = node;
                return;
            }
            if (root.Right == null)
            {
                root.Right = node;
                return;
            }
            InsertAt(root.Left, node);
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