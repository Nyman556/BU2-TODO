using Microsoft.AspNetCore.Mvc;

namespace gruppÖvning_TODO;

public class CreateTodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public CreateTodoDto(string title, string description)
    {
        this.Title = title;
        this.Description = description;
    }
}

[ApiController]
[Route("todo")]
public class CreateTodoController : ControllerBase
{
    private TodoService todoService;

    public CreateTodoController(TodoService todoService)
    {
        this.todoService = todoService;
    }

    [HttpPost("add")]
    public IActionResult CreateTodo([FromBody] CreateTodoDto dto)
    {
        Todo? todo = todoService.CreateTodo(dto.Title, dto.Description);

        if (dto == null)
        {
            return BadRequest();
        }
        return Ok(todo);
    }

    [HttpGet("alltodos")]
    public List<Todo> ReadTodo()
    {
        List<Todo> todo = todoService.ReadTodo();

        return todo;
    }

    //Flyttade Remove hit tror vi måste ha alla controllers i samma class.  url blir /todo/remove/id
    [HttpDelete("remove/{id}")]
    public IActionResult RemoveTodo(Guid id)
    {
        Todo? todo = todoService.RemoveTodo(id);

        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    // Update
    [HttpPut("update/{id}")]
    public IActionResult UpdateTodo(Guid id, [FromQuery] bool completed)
    {
        Todo? todo = todoService.UpdateTodo(id, completed);

        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }
}
