using Domain.ToDo.Entities;

namespace Domain.ToDo.Repositories
{
	public interface ITodoRepository
	{
		Task<Todo?> GetTaskByIdAsync(int id);
		Task<IEnumerable<Todo>> GetAllTasksAsync();
		Task AddTaskAsync(Todo todo);
		Task UpdateTaskAsync(int id);
		Task DeleteTaskAsync(int id);
	}
}
