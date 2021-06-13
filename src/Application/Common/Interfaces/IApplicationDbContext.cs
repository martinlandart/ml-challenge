using mercadolibre_challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<DnaSequence> DnaSequences { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
