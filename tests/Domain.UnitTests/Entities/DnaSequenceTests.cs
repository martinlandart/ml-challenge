using FluentAssertions;
using mercadolibre_challenge.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Domain.UnitTests.Entities
{
    public class DnaSequenceTests
    {
        private readonly string[] mutantSequenceRows = new string[6] {
            "ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"
        };

        private static char[,] ConvertRowsToMultiDimensionalArray(string[] rows)
        {
            var array = new char[6, 6];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; i < 6; i++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return array;
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
        public void ShouldFillArray()
        {
            var sequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(mutantSequenceRows)
            };

            sequence.Sequence.Length.Should().Be(6 * 6);
        }
    }
}
