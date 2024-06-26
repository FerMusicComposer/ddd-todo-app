﻿using Domain.Abstractions;
using Domain.ToDo.Entities;
using Domain.ToDo.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class TodoRepository : ITodoRepository
	{
		private readonly ToDoAppDbContext _dbContext;

		public TodoRepository(ToDoAppDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
		}

		public async Task<Todo?> GetTodoByIdAsync(int id)
		{
			return await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == id);
		}

		public async Task<IEnumerable<Todo>> GetAllTodosAsync()
		{
			return await _dbContext.Todos.ToListAsync();
		}

		public async Task<Todo> AddTodoAsync(Todo todo)
		{
			_dbContext.Todos.Add(todo);
			await _dbContext.SaveChangesAsync();

			var addedTodo = await _dbContext.Todos.FindAsync(todo.Id);

			return addedTodo;
		}

		public async Task<Todo> UpdateTodoAsync(Todo updatedTodo)
		{
			await _dbContext.SaveChangesAsync();

			return updatedTodo;
		}

		public async Task<Result> DeleteTodoAsync(Todo todo)
		{
			_dbContext.Todos.Remove(todo);
			await _dbContext.SaveChangesAsync();

			return Result.Success();
			
		}
	}
}
