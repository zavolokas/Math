using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zavolokas.Math.Combinatorics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class BinsPacker<T>
    {
        /// <summary>
        /// Packs the specified elements in a minimal number of bins based on the cost of an element.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <param name="getElementCost">The element cost function.</param>
        /// <param name="maxBinSize">Maximum size of a bin.</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Pack(IEnumerable<T> elements, Func<T, double> getElementCost, double maxBinSize)
        {
            var orderedElements = elements.OrderByDescending(getElementCost);
            var bins = new List<Bin>();

            foreach (var element in orderedElements)
            {
                //try to place into existing bins & find min bin
                Bin properBin = null;
                double minSum = double.MaxValue;
                var ecost = getElementCost(element);

                foreach (var bin in bins)
                {
                    if (bin.Sum + ecost <= maxBinSize && maxBinSize - bin.Sum - ecost < minSum)
                    {
                        properBin = bin;
                        minSum = bin.Sum;
                    }
                }

                if (properBin == null)
                {
                    // if there are no appropriate bins - create a new one
                    properBin = new Bin();
                    bins.Add(properBin);
                }

                properBin.Put(element, getElementCost);
            }

            return bins;
        }

        private class Bin : IEnumerable<T>
        {
            public double Sum;
            private readonly List<T> _elements = new List<T>();

            public void Put(T element, Func<T, double> getCost)
            {
                _elements.Add(element);
                Sum += getCost(element);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _elements.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _elements.GetEnumerator();
            }
        }
    }
}
