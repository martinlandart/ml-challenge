using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using mercadolibre_challenge.Domain.Entities;
using mercadolibre_challenge.Domain.ValueObjects;
using System.Collections.Generic;

namespace PerformanceTestConsoleApp
{
    public class DnaSequenceBenchmark
    {
        private readonly List<string> mutantSequenceRows = new()
        {
            "ATGCGA",
            "CAGTGC",
            "TTATGT",
            "AGAAGG",
            "CCCCTA",
            "TCACTG"
        };

        private readonly string dnaSequence;

        public DnaSequenceBenchmark()
        {
            dnaSequence = FlatSequence.From(mutantSequenceRows);
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
