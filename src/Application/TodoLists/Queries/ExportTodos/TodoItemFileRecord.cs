using mercadolibre_challenge.Application.Common.Mappings;
using mercadolibre_challenge.Domain.Entities;

namespace mercadolibre_challenge.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
