using Application.Interfaces;
using Domain.ToDo.Services;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
	public class ApiEndpoints
	{
		public static void MapTodoEndpoints(IEndpointRouteBuilder app)
		{
			app.MapGet("/todo/{id}", async (int id, ITodoApplicationServices todoService) =>
			{
				var todo = await todoService.GetTodoByIDAsync(id);

				if (!todo.IsSuccess)
				{
					return Results.BadRequest(todo.Error);
				}

				return Results.Ok(todo.Value);
			})
			.WithName("GetTodoByID")
			.WithOpenApi(x => new OpenApiOperation(x)
			{
				Summary = "Get Todo by ID",
				Description = "Returns the Todo that matches the ID passed as parameter",
			});
		}
	}
}
