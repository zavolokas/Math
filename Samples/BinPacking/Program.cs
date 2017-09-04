using System;
using System.Reactive.Linq;
using Zavolokas.Math.Combinatorics;

namespace BinPacking
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] { 0.2, 0.5, 0.4, 0.7, 0.1, 0.3, 0.8 };
            var maxBinSize = 1.7;

            var bins = BinsPacker<double>.Pack(items, d => d, maxBinSize);

            bins.ToObservable().Subscribe(combination =>
                {
                    foreach (var item in combination)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
            );
        }
    }
}
