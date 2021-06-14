using MediatR;
using mercadolibre_challenge.Application.Common.Interfaces;
using mercadolibre_challenge.Application.Mutants.Queries.GetMutantStats;
using mercadolibre_challenge.Domain.Entities;
using mercadolibre_challenge.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;

namespace mercadolibre_challenge.Application.Mutants.Commands.CreateMutant
{
    public class CreateDnaSequenceCommand : IRequest<bool>
    {
        public string Dna { get; set; }
    }

    public class CreateDnaSequenceCommandHandler : IRequestHandler<CreateDnaSequenceCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _distributedCache;

        public CreateDnaSequenceCommandHandler(IApplicationDbContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
        }

        public async Task<bool> Handle(CreateDnaSequenceCommand request, CancellationToken cancellationToken)
        {
            var dnaSequence = new DnaSequence(request.Dna);

            dnaSequence.DomainEvents.Add(new DnaSequenceCreatedEvent(dnaSequence));

            var item = await _context.DnaSequences.FindAsync(dnaSequence.Sequence);

            if (item is null)
            {
                _context.DnaSequences.Add(dnaSequence);
                await _context.SaveChangesAsync(cancellationToken);
            }

            // In a real project, I would execute this in the handler for the Domain event sent in line 35,
            // since this behavior belongs to a different business requirement.
            // Due to time constraints for this exam, I'll leave this logic here
            await SetStatsCache(cancellationToken);

            return dnaSequence.IsMutant;
        }

        private async Task SetStatsCache(CancellationToken cancellationToken)
        {
            var sequences = await _context.DnaSequences.Select(d => new { d.IsMutant }).ToListAsync();

            var mutantCount = sequences.Count(d => d.IsMutant);
            var humanCount = sequences.Count - mutantCount;

            double ratio = (double)mutantCount / humanCount;
            if (double.IsInfinity(ratio))
                ratio = 1;

            var stats = new MutantStatsVm
            {
                CountMutantDna = mutantCount,
                CountHumanDna = sequences.Count - mutantCount,
                Ratio = ratio
            };

            await _distributedCache.SetAsync("stats", JsonSerializer.SerializeToUtf8Bytes(stats), cancellationToken);
        }
    }
}
