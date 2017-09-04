using BenchmarkDotNet.Attributes;

namespace RandomNumbers
{
    public class RandomComparison
    {
        [Params(10,100,1000)]
        public int Count { get; set; }

        [Benchmark]
        public void StandardRandom()
        {
            var rnd = new System.Random();
            for (int i = 0; i < Count; i++)
            {
                var number = rnd.NextDouble();
            }
        }

        [Benchmark]
        public void FastRandom()
        {
            var rnd = new Zavolokas.Math.Random.FastRandom();
            for (int i = 0; i < Count; i++)
            {
                var number = rnd.NextDouble();
            }
        }
    }
}