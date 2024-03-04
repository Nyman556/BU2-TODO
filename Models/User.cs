using Microsoft.AspNetCore.Identity;

namespace gruppÖvning_TODO;

public class User : IdentityUser
{
    public List<Todo> Todos { get; set; }

    public User() { }
}
