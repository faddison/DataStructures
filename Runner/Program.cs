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
        }
    }
}
