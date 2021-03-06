﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="TreeNode.cs" company="Homewood Human Solutions">
// // This file is subject to the terms and conditions defined in file 'LICENSE.txt', 
// // which is part of this source code package.
// // </copyright>
// // <author>Fraser Addison</author>
// // <created>16-02-2015</created>
// //
// // <summary>
// // The TreeNode.cs
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Graphs.BST
{
    public class BinaryTreeNode
    {
        public int Key { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int key)
        {
            Key = key;
        }

        public bool HasLeft
        {
            get
            {
                return Left != null;
            }
        }

        public bool HasRight
        {
            get
            {
                return Right != null;
            }
        }

        public bool HasGrandchildren
        {
            get
            {
                return ((HasRight && (Right.HasLeft || Right.HasLeft)) || (HasLeft && (Left.HasLeft || Left.HasRight)));
            }
        }

        public bool HasChildren
        {
            get
            {
                return (HasRight || HasLeft);
            }
        }
    }
}