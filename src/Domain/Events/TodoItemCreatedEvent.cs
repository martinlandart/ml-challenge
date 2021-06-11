using mercadolibre_challenge.Domain.Common;
using mercadolibre_challenge.Domain.Entities;

namespace mercadolibre_challenge.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
