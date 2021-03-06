﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DictionaryExtensions.cs" company="Homewood Human Solutions">
// // This file is subject to the terms and conditions defined in file 'LICENSE.txt', 
// // which is part of this source code package.
// // </copyright>
// // <author>Fraser Addison</author>
// // <created>18-02-2015</created>
// //
// // <summary>
// // The DictionaryExtensions.cs
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Graphs.BST
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class DictionaryExtensions
    {
        public static Dictionary<int, Queue<BinaryTreeNode>> Merge(this Dictionary<int, Queue<BinaryTreeNode>> d1, Dictionary<int, Queue<BinaryTreeNode>> d2)
        {
            //List<Dictionary<TKey, TValue>> list = new List<Dictionary<TKey, TValue>>();
            //list.Add(d1);
            //list.Add(d2);
            ////return list.SelectMany(x => x).ToDictionary(x => x.Key, y => y.Value);
            //return list.SelectMany(dict => dict)
            //             .ToLookup(pair => pair.Key, pair => pair.Value)
            //             .ToDictionary(group => group.Key, group => group.First());
            foreach (int key in d2.Keys.ToList())
            {
                var d1Queue = d1.ContainsKey(key) ? d1[key] : new Queue<BinaryTreeNode>();
                foreach (var n in d2[key].ToList())
                {
                    d1Queue.Enqueue(d2[key].Dequeue());
                }
                d1[key] = d1Queue;
            }
            return d1;
        }

        public static string Pretty(this Dictionary<int, Queue<BinaryTreeNode>> dict)
        {
            StringBuilder stringbuilder = new StringBuilder();
            foreach (int depth in dict.Keys)
            {
                stringbuilder.Append("{" + depth + ",[");
                foreach (var n in dict[depth].ToList())
                {
                    stringbuilder.Append(dict[depth].Dequeue().Key + ",");
                }
                stringbuilder.Append("]}");
            }
            return stringbuilder.ToString();
        }
    }
}