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

		public async Task<Todo?> GetTaskByIdAsync(int id)
		{
			return await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == id);
		}

		public Task<IEnumerable<Todo>> GetAllTasksAsync()
		{
			throw new NotImplementedException();
		}

		public Task AddTaskAsync(Todo task)
		{
			throw new NotImplementedException();
		}

		public Task UpdateTaskAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteTaskAsync(int id)
		{
			throw new NotImplementedException();
		}

	}
}
