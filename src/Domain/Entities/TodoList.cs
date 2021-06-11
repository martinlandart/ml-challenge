using mercadolibre_challenge.Domain.Common;
using mercadolibre_challenge.Domain.ValueObjects;
using System.Collections.Generic;

namespace mercadolibre_challenge.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
