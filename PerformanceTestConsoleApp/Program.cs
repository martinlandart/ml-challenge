using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using mercadolibre_challenge.Domain.Entities;
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

        private readonly DnaSequence testSequence;

        public DnaSequenceBenchmark()
        {
            testSequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(mutantSequenceRows)
            };
        }

        [Benchmark]
        public bool IsMutant() => testSequence.IsMutant();

        private static char[,] ConvertRowsToMultiDimensionalArray(List<string> rows)
        {
            var dnaSequenceSize = rows[0].Length;

            var array = new char[dnaSequenceSize, dnaSequenceSize];

            for (int i = 0; i < dnaSequenceSize; i++)
            {
                for (int j = 0; j < dnaSequenceSize; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return array;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DnaSequenceBenchmark>();
        }
    }
}
