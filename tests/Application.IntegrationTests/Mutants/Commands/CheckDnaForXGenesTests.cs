using FluentAssertions;
using mercadolibre_challenge.Application.Mutants.Commands.CreateMutant;
using NUnit.Framework;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.IntegrationTests.Mutants.Commands
{
    using static Testing;

    public class CheckDnaForXGenesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnTrueIfMutant()
        {
            var command = new CheckDnaForXGenesCommand
            {
                Dna = new()
                {
                    "ATGCGA",
                    "CAGTGC",
                    "TTATGT",
                    "AGAAGG",
                    "CCCCTA",
                    "TCACTG"
                }
            };

            var isMutant = await SendAsync(command);

            isMutant.Should().BeTrue();
        }

        [Test]
        public async Task ShouldReturnFalseIfNotMutant()
        {
            var command = new CheckDnaForXGenesCommand
            {
                Dna = new()
                {
                    "ATGCGA",
                    "CCGTCA",
                    "TTATGA",
                    "AGAAGA",
                    "CGTCTC",
                    "TCACTG"
                }
            };

            var isMutant = await SendAsync(command);

            isMutant.Should().BeFalse();
        }
    }
}
