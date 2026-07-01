using Microsoft.AspNetCore.Mvc;
using net_basic_todo.Models;

namespace net_basic_todo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<TodoItem>> GetAll()
    {
        var todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Learn C# and .NET", IsDone = true },
            new TodoItem { Id = 2, Title = "Build Todo API", IsDone = false },
            new TodoItem { Id = 3, Title = "Master ASP.NET Core", IsDone = false }
        };

        return Ok(todos);
    }
}
