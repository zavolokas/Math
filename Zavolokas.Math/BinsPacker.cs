using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zavolokas.Math
{
    public static class BinsPacker<T>
    {
        public static IEnumerable<IEnumerable<T>> Pack(IEnumerable<T> elements, Func<T, int> getElementCost, int maxBinSize)
        {
            var orderedElements = elements.OrderByDescending(getElementCost);
            var bins = new List<Bin>();

            foreach (var element in orderedElements)
            {
                //try to place into existing bins & find min bin
                Bin properBin = null;
                int minSum = int.MaxValue;
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
            public int Sum;
            private readonly List<T> _elements = new List<T>();

            public void Put(T element, Func<T, int> getCost)
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
