using mercadolibre_challenge.Domain.Common;
using mercadolibre_challenge.Domain.Entities;

namespace mercadolibre_challenge.Domain.Events
{
    public class DnaSequenceCreatedEvent : DomainEvent
    {
        public DnaSequenceCreatedEvent(DnaSequence dnaSequence)
        {
            DnaSequence = dnaSequence;
        }

        public DnaSequence DnaSequence { get; }
    }
}
