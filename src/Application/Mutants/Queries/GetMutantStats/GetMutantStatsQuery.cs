using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Mutants.Queries.GetMutantStats
{
    public class GetMutantStatsQuery : IRequest<MutantStatsVm>
    {
    }

    public class GetMutantStatsQueryHandler : IRequestHandler<GetMutantStatsQuery, MutantStatsVm>
    {
        private readonly IDistributedCache _distributedCache;

        public GetMutantStatsQueryHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<MutantStatsVm> Handle(GetMutantStatsQuery request, CancellationToken cancellationToken)
        {
            var cache = await _distributedCache.GetAsync("stats", cancellationToken);

            if (cache is null)
            {
                return new MutantStatsVm
                {
                    CountHumanDna = 0,
                    CountMutantDna = 0,
                    Ratio = 0
                };
            }

            return JsonSerializer.Deserialize<MutantStatsVm>(cache);
        }
    }

}
