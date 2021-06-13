using MediatR;
using mercadolibre_challenge.Application.Common.Interfaces;
using mercadolibre_challenge.Application.Common.Models;
using mercadolibre_challenge.Domain.Events;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Mutants.EventHandlers
{
    public class DnaSequenceCreatedEventHandler : INotificationHandler<DomainEventNotification<DnaSequenceCreatedEvent>>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IApplicationDbContext _context;

        public DnaSequenceCreatedEventHandler(IDistributedCache distributedCache, IApplicationDbContext context)
        {
            _distributedCache = distributedCache;
            _context = context;
        }

        public async Task Handle(DomainEventNotification<DnaSequenceCreatedEvent> notification, CancellationToken cancellationToken)
        {
            // Unused since this executes as part of the Creation command handler
            // In a real project, I'd set up the infrastructure to test Event handlers properly

            //var sequences = await _context.DnaSequences.Select(d => new { d.IsMutant }).ToListAsync();

            //var mutantCount = sequences.Count(d => d.IsMutant);
            //var humanCount = sequences.Count - mutantCount;

            //double ratio = (double)mutantCount / humanCount;
            //if (double.IsInfinity(ratio))
            //    ratio = 1;

            //var stats = new MutantStatsVm
            //{
            //    CountMutantDna = mutantCount,
            //    CountHumanDna = sequences.Count - mutantCount,
            //    Ratio = ratio
            //};

            //await _distributedCache.SetAsync("stats", JsonSerializer.SerializeToUtf8Bytes(stats), cancellationToken);
        }
    }
}
