using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gruppÖvning_TODO;

// Todo CRUD
// Create funktion
// Read funktion
// Update funktion
// Delete funktion

// Behöver en lista där vi sparar todos

// Id
// title
// description
// completed (bool)
// (timestamp)

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<TodoDbContext>(options =>
        {
            options.UseNpgsql(
                "Host=localhost;Database=tododatabase;Username=postgres;Password=NewPassword"
            );
        });
        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(
                "create_todo",
                policy =>
                {
                    policy.RequireAuthenticatedUser();
                }
            );
        });

        builder
            .Services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<TodoDbContext>()
            .AddApiEndpoints();

        builder.Services.AddControllers(); //behövs för att hantera controllers

        //för att kunna spara information måste man använda addSingleton.
        builder.Services.AddScoped<TodoService, TodoService>();
        var app = builder.Build();

        app.MapIdentityApi<User>();
        app.MapControllers(); // här mappar vi ut alla controllers
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHttpsRedirection();

        app.Run();
    }
}
