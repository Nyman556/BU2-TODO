namespace gruppÖvning_TODO;

public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public User User { get; set; }

    public Todo() { }

    public Todo(string title, string description, User user)
    {
        this.Title = title;
        this.Description = description;
        this.Completed = false;
        this.User = user;
    }
}
