using FluentAssertions;
using mercadolibre_challenge.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
            DnaSequence sequence = BuildSequenceFromDnaRows(humanSequenceRows);

            sequence.IsMutant.Should().BeFalse();
        }

        [Test]
        public void ShouldBeMutant()
        {
            DnaSequence sequence = BuildSequenceFromDnaRows(mutantSequenceRows);

            sequence.IsMutant.Should().BeTrue();
        }

        [Test]
        public void ShouldHandleTinyMatrix()
        {
            DnaSequence sequence = BuildSequenceFromDnaRows(tinyHumanSequence);

            sequence.IsMutant.Should().BeFalse();
        }

        [Test]
        public void ShouldHandleNbyNMatrix()
        {
            DnaSequence sequence = BuildSequenceFromDnaRows(largerMutantSequenceRows);

            sequence.IsMutant.Should().BeTrue();
        }

        private static DnaSequence BuildSequenceFromDnaRows(List<string> rows)
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                sb.Append(row);
            }

            return new DnaSequence(sb.ToString());
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
