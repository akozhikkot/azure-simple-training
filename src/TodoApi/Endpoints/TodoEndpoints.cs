using Microsoft.AspNetCore.Mvc;
using TodoApi.Entity;
using TodoApi.Services;

namespace TodoApi.Endpoints
{
    public static class TodoEndpoints
    {
        public static void UseTodoEndpoints(this WebApplication app)
        {
            app.MapGet("/todos", (TodoRepository repository) =>
            {
                return repository.GetAll();
            })
            .WithName("GetAllTodo")
            .WithOpenApi();

            app.MapGet("/todos/{id}", (TodoRepository repository, [FromRoute] string id) =>
            {
                return repository.GetById(id);
            })
            .WithName("GetTodoById")
            .WithOpenApi();

            app.MapPost("/todos", async (TodoRepository repository, [FromBody] TodoItem todo) =>
            {
                await repository.Add(todo);
            })
            .WithName("CreateTodo")
            .WithOpenApi();

            app.MapPost("/todos/{id}", async (TodoRepository repository, [FromBody] TodoItem todo, [FromRoute] string id) =>
            {
                todo.Id = id;
                await repository.Update(todo);
            })
            .WithName("UpdateTodo")
            .WithOpenApi();
        }
    }
}
