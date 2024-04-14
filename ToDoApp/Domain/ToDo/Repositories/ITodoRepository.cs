using Domain.Abstractions;
using Domain.ToDo.Entities;

namespace Domain.ToDo.Repositories
{
	public interface ITodoRepository
	{
		Task<Todo?> GetTodoByIdAsync(int id);
		Task<IEnumerable<Todo>> GetAllTodosAsync();
		Task<Todo> AddTodoAsync(Todo todo);
		Task<Todo> UpdateTodoAsync(Todo updatedTodo);
		Task<Result> DeleteTodoAsync(Todo todo);
	}
}
