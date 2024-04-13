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

		public Task<IEnumerable<Todo>> GetAllTodosAsync()
		{
			throw new NotImplementedException();
		}

		public Task AddTodoAsync(Todo task)
		{
			throw new NotImplementedException();
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
