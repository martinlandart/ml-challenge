using mercadolibre_challenge.Domain.Common;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
