using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Graphs.BST;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode root = new BinaryTreeNode(2);
            OrderedBinarySearchTree tree = new OrderedBinarySearchTree(root);

            tree.Insert(new BinaryTreeNode(1));
            tree.Insert(new BinaryTreeNode(2));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(1));
            tree.Insert(new BinaryTreeNode(3));
            tree.Insert(new BinaryTreeNode(2));

            BinaryTreeFormatter<int> formatter = new BinaryTreeFormatter<int>();
            Console.WriteLine("Depth: " + formatter.GetMaxDepth(tree));
            Console.WriteLine("Nodes: " + formatter.GetNumberOfNodes(tree));
            Console.ReadLine();
        }
    }
}
