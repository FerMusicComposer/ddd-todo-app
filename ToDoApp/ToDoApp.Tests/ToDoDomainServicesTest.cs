using Domain.ToDo.Entities;
using Domain.ToDo.Errors;
using Domain.ToDo.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Tests;

public class ToDoDomainServicesTest
{
	private ToDoAppDbContext CreateDbContext(string databaseName)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ToDoAppDbContext>()
			.UseInMemoryDatabase(databaseName);

		return new ToDoAppDbContext(optionsBuilder.Options);
	}

	[Fact]
	public async Task GetTodoByIdAsync_ReturnsTodo_WhenTodoExists()
	{
		var dbContext = CreateDbContext("GetTodoByIdAsync_ReturnsTodo");
		var todo = new Todo(1, "Test Title", "This Todo is a test");
		dbContext.Todos.Add(todo);
		dbContext.SaveChanges();

		var repository = new TodoRepository(dbContext);
		var service = new TodoService(repository);

		var result = await service.GetTodoByIDAsync(todo.Id);

		Assert.NotNull(result.Value);
		Assert.Equal(todo.Id, result.Value.Id);
	}

	[Fact]
	public async Task GetTodoByIdAsync_ReturnsNotFound_WhenTodoDoesNotExist()
	{
		// Arrange
		var dbContext = CreateDbContext("GetTodoByIdAsync_ReturnsNotFound");
		var todoRepository = new TodoRepository(dbContext);
		var service = new TodoService(todoRepository);

		// Act
		var result = await service.GetTodoByIDAsync(-1);

		// Assert
		Assert.False(result.IsSuccess);
		Assert.Equal(TodoErrors.InvalidId, result.Error);
	}
}
