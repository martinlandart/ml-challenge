using mercadolibre_challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<DnaSequence> DnaSequences { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
