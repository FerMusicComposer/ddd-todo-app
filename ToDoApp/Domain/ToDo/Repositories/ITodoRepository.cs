using Domain.ToDo.Entities;

namespace Domain.ToDo.Repositories
{
	public interface ITodoRepository
	{
		Task<Todo?> GetTodoByIdAsync(int id);
		Task<IEnumerable<Todo>> GetAllTodosAsync();
		Task<Todo> AddTodoAsync(Todo todo);
		Task UpdateTodoAsync(int id);
		Task DeleteTodoAsync(int id);
	}
}
