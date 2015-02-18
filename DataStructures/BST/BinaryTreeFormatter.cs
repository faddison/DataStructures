// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BinaryTreeFormatter.cs" company="Homewood Human Solutions">
// // This file is subject to the terms and conditions defined in file 'LICENSE.txt', 
// // which is part of this source code package.
// // </copyright>
// // <author>Fraser Addison</author>
// // <created>16-02-2015</created>
// //
// // <summary>
// // The BinaryTreeFormatter.cs
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Graphs.BST
{
    public class BinaryTreeFormatter<T>
    {
        public string Format(IBinarySearchTree tree)
        {
            return FormatHelper(tree.Root);
        }

        private string FormatHelper(BinaryTreeNode node)
        {
            return null;
        }

        public int GetMaxDepth(IBinarySearchTree tree)
        {
            return GetMaxDepthHelper(tree.Root);
        }

        private int GetMaxDepthHelper(BinaryTreeNode node)
        {
            if (node.Left == null)
                if (node.Right == null)
                    return 0;
                else
                    return GetMaxDepthHelper(node.Right) + 1;
            else
                return GetMaxDepthHelper(node.Left) + 1;
        }

        public int GetNumberOfNodes(IBinarySearchTree tree)
        {
            return GetNumberOfNodesHelper(tree.Root);
        }

        private int GetNumberOfNodesHelper(BinaryTreeNode node)
        {
            if (node.Left == null)
                if (node.Right == null)
                    return 1;
                else
                    return GetNumberOfNodesHelper(node.Right) + 1;
            else
                return GetNumberOfNodesHelper(node.Left) + 1;
        }
    }
}