using net_basic_todo.Models;

namespace net_basic_todo.Services;

public class TodoService : ITodoService
{
    private readonly List<TodoItem> _todos = new()
    {
        new TodoItem { Id = 1, Title = "Learn C# and .NET", IsDone = true },
        new TodoItem { Id = 2, Title = "Build Todo API", IsDone = false },
        new TodoItem { Id = 3, Title = "Master ASP.NET Core", IsDone = false }
    };

    private int _nextId = 4;

    public List<TodoItem> GetAll()
    {
        return _todos;
    }

    public TodoItem? GetById(int id)
    {
        return _todos.FirstOrDefault(t => t.Id == id);
    }

    public TodoItem Add(TodoItem item)
    {
        item.Id = _nextId++;
        _todos.Add(item);
        return item;
    }

    public bool Update(int id, TodoItem updated)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            return false;
        }

        existing.Title = updated.Title;
        existing.IsDone = updated.IsDone;
        return true;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            return false;
        }

        _todos.Remove(existing);
        return true;
    }
}
