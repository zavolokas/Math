using System;
using System.Linq;
using System.Reactive.Linq;
using Zavolokas.Math.Combinatorics;

namespace AllCombinations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("All possible combinations of strings: ");
            GetAndPrintCombinations(new[] { "red", "green", "blue" });
            Console.WriteLine();

            Console.WriteLine("All possible combinations of numbers: ");
            GetAndPrintCombinations(new[] { 1, 2, 3, 4 });
        }

        public static void GetAndPrintCombinations<T>(T[] items)
        {
            items.GetAllCombinations()
                .OrderBy(c => c.Count())
                .ToObservable()
                .Subscribe(combination =>
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
