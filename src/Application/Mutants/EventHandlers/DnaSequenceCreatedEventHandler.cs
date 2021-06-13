using MediatR;
using mercadolibre_challenge.Application.Common.Models;
using mercadolibre_challenge.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Mutants.EventHandlers
{
    public class DnaSequenceCreatedEventHandler : INotificationHandler<DomainEventNotification<DnaSequenceCreatedEvent>>
    {
        public Task Handle(DomainEventNotification<DnaSequenceCreatedEvent> notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
