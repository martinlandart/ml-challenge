using FluentAssertions;
using mercadolibre_challenge.Application.Mutants.Commands.CreateMutant;
using mercadolibre_challenge.Application.Mutants.Queries.GetMutantStats;
using mercadolibre_challenge.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Distributed;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.IntegrationTests.Mutants.Queries
{
    using static Testing;

    public class GetMutantStatsTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllZeroesIfDataIsEmpty()
        {
            var query = new GetMutantStatsQuery();

            var results = await SendAsync(query);

            results.CountHumanDna.Should().Be(0);
            results.CountMutantDna.Should().Be(0);
            results.Ratio.Should().Be(0);
        }

        [Test]
        public async Task ShouldReturnCorrectStatistics()
        {
            await AddMutant();
            await AddHuman();

            var query = new GetMutantStatsQuery();

            var results = await SendAsync(query);

            results.CountHumanDna.Should().Be(1);
            results.CountMutantDna.Should().Be(1);
            results.Ratio.Should().Be(1);
        }

        [Test]
        public async Task ShouldReturnRatio1()
        {
            await AddMutant();

            var query = new GetMutantStatsQuery();

            var results = await SendAsync(query);

            results.CountHumanDna.Should().Be(0);
            results.CountMutantDna.Should().Be(1);
            results.Ratio.Should().Be(1);
        }

        [Test]
        public async Task ShouldReturnRatio0()
        {
            await AddHuman();

            var query = new GetMutantStatsQuery();

            var results = await SendAsync(query);

            results.CountHumanDna.Should().Be(1);
            results.CountMutantDna.Should().Be(0);
            results.Ratio.Should().Be(0);
        }

        private static async Task AddHuman()
        {
            var addHumanCommand = new CreateDnaSequenceCommand
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

            await SendAsync(addHumanCommand);
        }

        private static async Task AddMutant()
        {
            var addMutantCommand = new CreateDnaSequenceCommand
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

            await SendAsync(addMutantCommand);
        }
    }
}
