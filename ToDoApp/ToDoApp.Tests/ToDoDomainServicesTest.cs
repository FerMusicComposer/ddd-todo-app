﻿using Domain.ToDo.Entities;
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

	#region GetTodoById

	[Fact]
	public async Task GetTodoByIdAsync_ReturnsTodo_WhenTodoExists()
	{
		var dbContext = CreateDbContext("GetTodoByIdAsync_ReturnsTodo");
		var todo = new Todo("Test Title", "This Todo is a test");
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

	#endregion

	#region GetAllTodos

	[Fact]
	public async Task GetAllTodosAsync_ReturnsTodosList_WhenTodosExist()
	{
		// Arrange
		var dbContext = CreateDbContext("GetAllTodosAsync_ReturnsTodosList");
		var todos = new List<Todo>
		{
			new("Test Todo 1", "Test description 1"),
			new("Test Todo 2", "Test description 2"),
			new("Test Todo 3", "Test description 3"),
			new("Test Todo 4", "Test description 4"),
			new("Test Todo 5", "Test description 5"),
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
		var dbContext = CreateDbContext("GetAllTodosAsync_ReturnsEmptyCollection");

		var todoRepository = new TodoRepository(dbContext);
		var service = new TodoService(todoRepository);

		// Act
		var result = await service.GetAllTodosAsync();

		// Assert
		Assert.False(result.IsSuccess);
		Assert.Empty(result.Values);
		Assert.Equal(TodoErrors.NotFoundAny, result.Error);
	}

	#endregion

	#region AddTodo

	[Fact]
	public async Task AddTodoAsync_AddsTodoToDb_WhenTitleIsNotEmpty()
	{
		var dbContext = CreateDbContext("AddTodoAsync_AddsTodoToDb");
		var todo = new Todo("Test Title", "This Todo is a test");

		var repository = new TodoRepository(dbContext);
		var service = new TodoService(repository);

		var result = await service.AddTodoAsync(todo);

		Assert.NotNull(result.Value);
		Assert.Equal(todo.Id, result.Value.Id);
	}

	[Fact]
	public async Task AddTodoAsync_DoesntAddTodoToDb_WhenTitleIsEmpty()
	{
		var dbContext = CreateDbContext("AddTodoAsync_DoesntAddTodoToDb");
		var todo = new Todo("", "This Todo is a test");

		var repository = new TodoRepository(dbContext);
		var service = new TodoService(repository);

		var result = await service.AddTodoAsync(todo);

		Assert.False(result.IsSuccess);
		Assert.Equal(TodoErrors.EmptyTitle, result.Error);
	}


	[Fact]
	public async Task AddTodoAsync_DoesntAddTodoToDb_WhenTodoIsNull()
	{
		var dbContext = CreateDbContext("AddTodoAsync_DoesntAddTodoToDb");
		Todo? todo = null;

		var repository = new TodoRepository(dbContext);
		var service = new TodoService(repository);

		var result = await service.AddTodoAsync(todo);

		Assert.False(result.IsSuccess);
		Assert.Equal(TodoErrors.NotAdded, result.Error);
	}

	#endregion

	#region UpdateTodo

	[Fact]
	public async Task UpdateTodoAsync_UpdatesTodo_WhenChangesWereMade()
	{
		var dbContext = CreateDbContext("UpdateTodoAsync_UpdatesTodo");
		var todo = new Todo("Test Title", "This Todo is a test");
		dbContext.Todos.Add(todo);
		await dbContext.SaveChangesAsync();

		var repository = new TodoRepository(dbContext);
		var service = new TodoService(repository);

		var originalTitle = todo.Title;
		var originalDescription = todo.Description;

		var updatedTodo = todo;
		updatedTodo.Title = "Updated title";
		updatedTodo.Description = "Updated description";

		var result = await service.UpdateTodoAsync(updatedTodo);

		Assert.NotNull(result.Value);
		Assert.NotEqual(originalTitle, updatedTodo.Title);
		Assert.NotEqual(originalDescription, updatedTodo.Description);
	}

	[Fact]
	public async Task UpdateTodoAsync_ReturnsNullError_WhenTodoIsNull()
	{
		var dbContext = CreateDbContext("UpdateTodoAsync_DoesntUpdateTodo");

		var repository = new TodoRepository(dbContext);
		var service = new TodoService(repository);

		var result = await service.UpdateTodoAsync(null) ;

		Assert.False(result.IsSuccess);
		Assert.Equal(TodoErrors.IsNull, result.Error);
	}

	#endregion

	#region DeleteTodo

	[Fact]
	public async Task DeleteTodoAsync_DeletesTodo_WhenTodoExists() { 
		var dbContext = CreateDbContext("DeleteTodoAsync_DeletesTodo");
		var todo = new Todo("Test Title", "This Todo is a test");
		dbContext.Todos.Add(todo);
		await dbContext.SaveChangesAsync();

		var repository = new TodoRepository(dbContext);
		var service = new TodoService(repository);

		var result = await service.DeleteTodoAsync(todo);

		Assert.True(result.IsSuccess);
	}

	#endregion
}

