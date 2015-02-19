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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class OrderedBinarySearchTree : IBinarySearchTree
    {
        public BinaryTreeNode Root { get; private set; }

        public OrderedBinarySearchTree(BinaryTreeNode node)
        {
            Root = node;
        }

        public bool Insert(BinaryTreeNode node)
        {
            return InsertHelper(Root, node);
        }

        private bool InsertHelper(BinaryTreeNode parent, BinaryTreeNode node)
        {
            if (node.Key < parent.Key)
            {
                if (!parent.HasLeft)
                {
                    parent.Left = node;
                    return true;
                }
                return InsertHelper(parent.Left, node);
            }
            if (node.Key > parent.Key)
            {
                if (!parent.HasRight)
                {
                    parent.Right = node;
                    return true;
                }
                return InsertHelper(parent.Right, node);
            }
            return false;
        }

        public bool Delete(int key)
        {
            if (Root.Key == key)
                throw new Exception("Cannot delete root node");
            return DeleteHelper(key, Root);
        }

        public bool DeleteHelper(int key, BinaryTreeNode node)
        {
            if (node.HasLeft && node.Left.Key == key)
            {
                if (!node.Left.HasChildren)
                {
                    node.Left = null;
                    return true;
                }
                if (node.Left.HasLeft && !node.Left.Left.HasChildren)
                {
                    node.Left = node.Left.Left;
                    return true;
                }
                if (node.Left.HasRight && !node.Left.Right.HasChildren)
                {
                    node.Left = node.Left.Right;
                    return true;
                }

                return false;
            }

            if (node.HasRight && node.Right.Key == key)
            {
                if (!node.Right.HasChildren)
                {
                    node.Right = null;
                    return true;
                }
                if (node.Right.HasLeft && !node.Right.Left.HasChildren)
                {
                    node.Right = node.Right.Left;
                    return true;
                }
                if (node.Right.HasRight && !node.Right.Right.HasChildren)
                {
                    node.Right = node.Right.Right;
                    return true;
                }
                return false;
            }

            if (!node.HasLeft)
                if (!node.HasRight)
                    return false;
                else
                    return DeleteHelper(key, node.Right);
            return DeleteHelper(key, node.Left);
        }

        public BinaryTreeNode Find(int key)
        {
            return FindHelper(key, Root);
        }

        private BinaryTreeNode FindHelper(int key, BinaryTreeNode node)
        {
            if (node.Key == key) 
                return node;
            if (!node.HasLeft)
                if (!node.HasRight)
                    return null;
                else
                    return FindHelper(key, node.Right);
            return FindHelper(key, node.Left);
        }

        public int Count()
        {
            return CountHelper(Root);
        }

        private int CountHelper(BinaryTreeNode node)
        {
            if (node.HasLeft && node.HasRight)
            {
                int leftCount = CountHelper(node.Left) + 1;
                int rightCount = CountHelper(node.Right) + 1;
                return leftCount + rightCount;
            }

            if (!node.HasLeft)
                if (!node.HasRight)
                    return 0;
                else
                    return CountHelper(node.Right) + 1;
            return CountHelper(node.Left) + 1;
        }

        public int Depth()
        {
            return DepthHelper(Root);
        }

        private int DepthHelper(BinaryTreeNode node)
        {
            if (node.HasLeft && node.HasRight)
            {
                int leftCount = DepthHelper(node.Left) + 1;
                int rightCount = DepthHelper(node.Right) + 1;
                return leftCount > rightCount ? leftCount : rightCount;
            }

            if (!node.HasLeft)
                if (!node.HasRight)
                    return 0;
                else
                    return DepthHelper(node.Right) + 1;
            return DepthHelper(node.Left) + 1;
        }

        public String Print()
        {
            Dictionary<int, Queue<BinaryTreeNode>> nodes = new Dictionary<int, Queue<BinaryTreeNode>>();
            nodes = PrintHelper(nodes, 0, Root);
            StringBuilder stringbuilder = new StringBuilder();
            foreach (int depth in nodes.Keys)
            {
                stringbuilder.Append("{" + depth + ",[");
                for (int i = 0; i < nodes[depth].Count; i++)
                {
                    stringbuilder.Append(nodes[depth].Dequeue().Key+",");
                }
                stringbuilder.Append("]}");
            }
            return stringbuilder.ToString();
        }

        private Dictionary<int, Queue<BinaryTreeNode>> PrintHelper(Dictionary<int, Queue<BinaryTreeNode>> nodes, int depth, BinaryTreeNode node)
        {
            var queue = new Queue<BinaryTreeNode>();
            if (nodes.ContainsKey(depth))
            {
                queue = nodes[depth];
                queue.Enqueue(node);
                nodes[depth] = queue;
            }
            else
            {
                nodes.Add(depth, queue);
            }

            if (node.HasLeft && node.HasRight)
            {
                return PrintHelper(nodes, depth + 1, node.Left).Merge(PrintHelper(nodes, depth + 1, node.Right));
            }

            if (!node.HasLeft)
                if (!node.HasRight)
                {
                    return nodes;
                }
                else
                    return PrintHelper(nodes, depth + 1, node.Right);
            return PrintHelper(nodes, depth + 1, node.Left);
        }

        
    }
}