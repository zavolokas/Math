using System;
using System.Collections.Generic;
using System.Linq;

namespace Zavolokas.Math.Combinatorics
{
    public static class CollectionExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetAllCombinations<T>(this IEnumerable<T> items)
        {
            var result = new List<List<T>>();

            var itemsList = items.ToArray();
            var itemsCount = itemsList.Length;

            double combinationsCount = System.Math.Pow(2, itemsCount) - 1;

            for (int i = 1; i <= combinationsCount; i++)
            {
                var combination = new List<T>();
                string positions = Convert.ToString(i, 2).PadLeft(itemsCount, '0');
                for (int j = 0; j < positions.Length; j++)
                {
                    if (positions[j] == '1')
                    {
                        combination.Add(itemsList[j]);
                    }
                }
                result.Add(combination);
            }
            return result;
        }
    }
}
