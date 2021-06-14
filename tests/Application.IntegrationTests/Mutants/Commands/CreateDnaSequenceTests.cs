using FluentAssertions;
using mercadolibre_challenge.Application.Common.Exceptions;
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
        public void ShouldThrowValidationErrorIfMatrixIsNotSquare()
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(new List<string>{
                    "ATGCGAAAA",
                    "CAGTGC",
                    "TTATGT",
                    "AGAAGG",
                    "CCCCTA",
                    "TCACTG"
                })
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public void ShouldThrowValidationErrorIfEmpty()
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(new List<string>())
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public void ShouldThrowValidationErrorIfContainsInvalidLetters()
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(new List<string>{
                    "ATGCGZ",
                    "CAGTGC",
                    "TTATGT",
                    "AGAAGG",
                    "CCCCTA",
                    "TCACTG"
                })
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<ValidationException>();
        }

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
        public async Task ShouldUpsertIfCreatingSameDnaTwice()
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
