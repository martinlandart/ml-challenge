using mercadolibre_challenge.Domain.Common;
using mercadolibre_challenge.Domain.Entities;

namespace mercadolibre_challenge.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
