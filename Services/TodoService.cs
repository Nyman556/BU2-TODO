namespace gruppÖvning_TODO;

public class TodoService
{
    private TodoDbContext context;

    public TodoService(TodoDbContext context)
    {
        this.context = context;
    }

    public Todo? CreateTodo(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("input must not be null or empty");
        }

        Todo? todo = new Todo(title, description);
        context.Todos.Add(todo);
        context.SaveChanges();
        return todo;
    }

    public Todo? RemoveTodo(Guid id)
    {
        Todo? todo = context.Todos.Find(id);
        if (todo == null)
        {
            return null;
        }
        context.Todos.Remove(todo);
        context.SaveChanges();
        return todo;
    }

    public Todo? UpdateTodo(Guid id, bool completed)
    {
        Todo? todo = context.Todos.Find(id);
        if (todo == null)
        {
            return null;
        }
        todo.Completed = completed;
        context.SaveChanges();
        return todo;
    }

    //updateTodo
    public List<Todo> ReadTodo()
    {
        return context.Todos.ToList();
    }
}
