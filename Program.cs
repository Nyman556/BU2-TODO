using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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
                "Host=localhost;Database=tododatabase;Username=postgres;Password=newPassword"
            );
        });

        builder.Services.AddControllers(); //behövs för att hantera controllers

        //för att kunna spara information måste man använda addSingleton.
        builder.Services.AddScoped<TodoService, TodoService>();
        var app = builder.Build();

        app.MapControllers(); // här mappar vi ut alla controllers
        app.UseHttpsRedirection();

        app.Run();
    }
}
