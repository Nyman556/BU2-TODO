namespace gruppÖvning_TODO;

public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public Todo(string title, string description)
    {
        this.Title = title;
        this.Description = description;
        this.Completed = false;
    }
}
