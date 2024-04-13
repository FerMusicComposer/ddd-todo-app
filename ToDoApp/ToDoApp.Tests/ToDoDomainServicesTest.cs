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
		var result = await service.GetTodoByIDAsync(100);

		// Assert
		Assert.False(result.IsSuccess);
		Assert.Equal(TodoErrors.NotFound, result.Error);
	}

	[Fact]
	public async Task GetTodoByIdAsync_ReturnsInvalidID_WhenInvalidIDIsPassed()
	{
		// Arrange
		var dbContext = CreateDbContext("GetTodoByIdAsync_ReturnsInvalidID");
		var todoRepository = new TodoRepository(dbContext);
		var service = new TodoService(todoRepository);

		// Act
		var result = await service.GetTodoByIDAsync(-1);

		// Assert
		Assert.False(result.IsSuccess);
		Assert.Equal(TodoErrors.InvalidId, result.Error);
	}

	[Fact]
	public async Task GetAllTodosAsync_ReturnsTodosList_WhenTodosExist()
	{
		// Arrange
		var dbContext = CreateDbContext("GetTodoByIdAsync_ReturnsTodos");
		var todos = new List<Todo>
		{
			new(1, "Test Todo 1", "Test description 1"),
			new(2, "Test Todo 2", "Test description 2"),
			new(3, "Test Todo 3", "Test description 3"),
			new(4, "Test Todo 4", "Test description 4"),
			new(5, "Test Todo 5", "Test description 5"),
		};
		dbContext.Todos.AddRange(todos);
		dbContext.SaveChanges();

		var todoRepository = new TodoRepository(dbContext);
		var service = new TodoService(todoRepository);

		// Act
		var result = await service.GetAllTodosAsync();

		// Assert
		Assert.NotNull(result.Values);
	}


	[Fact]
	public async Task GetAllTodosAsync_ReturnsEmptyCollection_WhenTodosDontExist()
	{
		// Arrange
		var dbContext = CreateDbContext("GetTodoByIdAsync_ReturnsEmptyCollection");

		var todoRepository = new TodoRepository(dbContext);
		var service = new TodoService(todoRepository);

		// Act
		var result = await service.GetAllTodosAsync();

		// Assert
		Assert.False(result.IsSuccess);
		Assert.Empty(result.Values);
	}
}

