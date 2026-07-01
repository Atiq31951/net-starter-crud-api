using Microsoft.AspNetCore.Mvc;
using net_basic_todo.Models;
using net_basic_todo.Services;

namespace net_basic_todo.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<List<TodoItem>> GetAll()
    {
        var todos = _todoService.GetAll();
        return Ok(todos);
    }

    [HttpGet("{id:int}")]
    public ActionResult<TodoItem> GetById(int id)
    {
        var todo = _todoService.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpPost]
    public ActionResult<TodoItem> Create(TodoItem item)
    {
        var createdTodo = _todoService.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = createdTodo.Id }, createdTodo);
    }
}
