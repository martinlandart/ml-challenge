using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using mercadolibre_challenge.Domain.Entities;
using System.IO;

namespace PerformanceTestConsoleApp
{
    public class DnaSequenceBenchmark
    {
        private readonly string dnaSequence;

        public DnaSequenceBenchmark()
        {
            using var sr = new StreamReader("hugesequence.txt");
            dnaSequence = sr.ReadToEnd();
        }

        [Benchmark]
        public DnaSequence IsMutant() => new(dnaSequence);
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DnaSequenceBenchmark>();
        }
    }
}
