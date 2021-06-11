using mercadolibre_challenge.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace mercadolibre_challenge.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
