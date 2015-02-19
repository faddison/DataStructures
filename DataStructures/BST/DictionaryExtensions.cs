// // --------------------------------------------------------------------------------------------------------------------
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

    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> d1, Dictionary<TKey, TValue> d2)
        {
            List<Dictionary<TKey, TValue>> list = new List<Dictionary<TKey, TValue>>();
            list.Add(d1);
            list.Add(d2);
            //return list.SelectMany(x => x).ToDictionary(x => x.Key, y => y.Value);
            return list.SelectMany(dict => dict)
                         .ToLookup(pair => pair.Key, pair => pair.Value)
                         .ToDictionary(group => group.Key, group => group.First());
        }


    }
}