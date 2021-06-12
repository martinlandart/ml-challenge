using FluentAssertions;
using mercadolibre_challenge.Domain.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace mercadolibre_challenge.Domain.UnitTests.Entities
{
    public class DnaSequenceTests
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

        private readonly List<string> largerMutantSequenceRows = new()
        {
            "ATGCGAT",
            "CAGTGCA",
            "TTATGTG",
            "AGAAGGC",
            "CCCCTAG",
            "TCACTGA",
            "TCACTGA"
        };

        private readonly List<string> humanSequenceRows = new()
        {
            "ATGCGA",
            "CCGTCA",
            "TTATGA",
            "AGAAGA",
            "CGTCTC",
            "TCACTG"
        };

        private readonly List<string> tinyHumanSequence = new()
        {
            "ATG",
            "CCG",
            "TTA"
        };

        [Test]
        public void ShouldBeHuman()
        {
            var sequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(humanSequenceRows)
            };

            sequence.IsMutant().Should().BeFalse();
        }

        [Test]
        public void ShouldBeMutant()
        {
            var sequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(mutantSequenceRows)
            };

            sequence.IsMutant().Should().BeTrue();
        }

        [Test]
        public void ShouldHandleTinyMatrix()
        {
            var sequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(tinyHumanSequence)
            };

            sequence.IsMutant().Should().BeFalse();
        }

        [Test]
        public void ShouldHandleNbyNMatrix()
        {
            var sequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(largerMutantSequenceRows)
            };

            sequence.IsMutant().Should().BeTrue();
        }

        [Test]
        public void ShouldFillArray()
        {
            var sequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(largerMutantSequenceRows)
            };

            sequence.Sequence.Length.Should().Be(7 * 7);
        }

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
}
