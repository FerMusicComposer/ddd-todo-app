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
			_dbContext.SaveChanges();

			var latestTodoId = await _dbContext.Todos.Select(t => t.Id).LastAsync();
			var addedTodo = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == latestTodoId);

			return addedTodo;
		}

		public Task UpdateTodoAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteTodoAsync(int id)
		{
			throw new NotImplementedException();
		}

	}
}
