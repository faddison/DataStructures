// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IBinarySearchTree.cs" company="Homewood Human Solutions">
// // This file is subject to the terms and conditions defined in file 'LICENSE.txt', 
// // which is part of this source code package.
// // </copyright>
// // <author>Fraser Addison</author>
// // <created>16-02-2015</created>
// //
// // <summary>
// // The IBinarySearchTree.cs
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Graphs.BST
{
    public interface IBinarySearchTree
    {
        BinaryTreeNode Root { get; }
        bool Insert(BinaryTreeNode node);
        bool Delete(int key);
        BinaryTreeNode Find(int key);

    }
}