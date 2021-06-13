using FluentAssertions;
using mercadolibre_challenge.Domain.ValueObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace mercadolibre_challenge.Domain.UnitTests.ValueObjects
{
    public class FlatSequenceTests
    {
        [Test]
        public void ShouldReturnCorrectFlattenedSequence()
        {
            var dnaRows = new List<string>()
            {
                "ATGCGA",
                "CCGTCA",
                "TTATGA",
                "AGAAGA",
                "CGTCTC",
                "TCACTG"
            };

            var sequence = FlatSequence.From(dnaRows);

            sequence.Sequence.Should().Be("ATGCGACCGTCATTATGAAGAAGACGTCTCTCACTG");
        }

        [Test]
        public void ShouldPerformImplicitConversion()
        {
            var dnaRows = new List<string>()
            {
                "ATGCGA",
                "CCGTCA",
                "TTATGA",
                "AGAAGA",
                "CGTCTC",
                "TCACTG"
            };

            string sequence = FlatSequence.From(dnaRows);

            sequence.Should().Be("ATGCGACCGTCATTATGAAGAAGACGTCTCTCACTG");
        }

        [Test]
        public void ShouldPerformExplicitConversion()
        {
            var dnaRows = new List<string>()
            {
                "ATGCGA",
                "CCGTCA",
                "TTATGA",
                "AGAAGA",
                "CGTCTC",
                "TCACTG"
            };

            var sequence = (FlatSequence)dnaRows;

            sequence.Should().Be(FlatSequence.From(dnaRows));
        }

        [Test]
        public void ToStringReturnsSequence()
        {
            var dnaRows = new List<string>()
            {
                "ATGCGA",
                "CCGTCA",
                "TTATGA",
                "AGAAGA",
                "CGTCTC",
                "TCACTG"
            };

            var sequence = FlatSequence.From(dnaRows);

            sequence.ToString().Should().Be(sequence.Sequence);
        }
    }
}
