using FluentAssertions;
using mercadolibre_challenge.Application.Mutants.Commands.CreateMutant;
using mercadolibre_challenge.Domain.Entities;
using mercadolibre_challenge.Domain.ValueObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.IntegrationTests.Mutants.Commands
{
    using static Testing;

    public class CreateDnaSequenceTests : TestBase
    {
        [Test]
        public async Task ShouldPersistDnaSequence()
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(new List<string>{
                    "ATGCGA",
                    "CAGTGC",
                    "TTATGT",
                    "AGAAGG",
                    "CCCCTA",
                    "TCACTG"
                })
            };

            await SendAsync(command);

            var result = await FindAsync<DnaSequence>("ATGCGACAGTGCTTATGTAGAAGGCCCCTATCACTG");

            result.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldPersistMutantStatus()
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(new List<string>{
                    "ATGCGA",
                    "CAGTGC",
                    "TTATGT",
                    "AGAAGG",
                    "CCCCTA",
                    "TCACTG"
                })
            };

            await SendAsync(command);

            var result = await FindAsync<DnaSequence>("ATGCGACAGTGCTTATGTAGAAGGCCCCTATCACTG");

            result.IsMutant.Should().BeTrue();
        }

        [Test]
        public async Task ShouldReturnTrueIfDnaIsMutant()
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(new List<string>{
                    "ATGCGA",
                    "CAGTGC",
                    "TTATGT",
                    "AGAAGG",
                    "CCCCTA",
                    "TCACTG"
                })
            };

            var isMutant = await SendAsync(command);

            isMutant.Should().BeTrue();
        }

        [Test]
        public async Task ShouldReturnFalseIfDnaIsHuman()
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(new List<string>{
                    "ATGCGA",
                    "CCGTCA",
                    "TTATGA",
                    "AGAAGA",
                    "CGTCTC",
                    "TCACTG"
                })
            };

            var isMutant = await SendAsync(command);

            isMutant.Should().BeFalse();
        }
    }
}
