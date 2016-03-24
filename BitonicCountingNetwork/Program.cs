using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace BitonicCountingNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            const int width = 4;
            var bitonic = new Bitonic(width);
            var dict = new ConcurrentDictionary<int, int>();

            Parallel.For(0, 567, (i) =>
            {
                dict.TryAdd(i, bitonic.Traverse(i % width));
            });

            foreach (var kk in dict.Select(p => p)
                .GroupBy(p => p.Value)
                .Select(group => new { output = group.Key, count = group.Count()})
                .OrderBy(group => group.output))
            {
                Console.WriteLine($"Output: {kk.output} Count: {kk.count}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
