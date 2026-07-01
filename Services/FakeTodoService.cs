using net_basic_todo.Models;

namespace net_basic_todo.Services;

public class FakeTodoService : ITodoService
{
    private readonly List<TodoItem> _fakeTodos = new()
    {
        new TodoItem { Id = 99, Title = "Fake Todo from Experiment", IsDone = true }
    };

    public List<TodoItem> GetAll()
    {
        return _fakeTodos;
    }

    public TodoItem? GetById(int id)
    {
        return _fakeTodos.FirstOrDefault(t => t.Id == id);
    }

    public TodoItem Add(TodoItem item)
    {
        item.Id = 100;
        _fakeTodos.Add(item);
        return item;
    }
}
