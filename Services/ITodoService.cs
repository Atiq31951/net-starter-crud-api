using net_basic_todo.Models;

namespace net_basic_todo.Services;

public interface ITodoService
{
    List<TodoItem> GetAll();
}
