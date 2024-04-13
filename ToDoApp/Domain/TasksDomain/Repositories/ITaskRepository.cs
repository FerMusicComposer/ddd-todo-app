namespace Domain.TasksDomain.Repositories
{
	public interface ITaskRepository
	{
		Task<Task> GetTaskAsync(int id);
		Task<IEnumerable<Task>> GetAllTasksAsync();
		Task AddTaskAsync(Task task);
		Task UpdateTaskAsync(int id);
		Task DeleteTaskAsync(int id);
	}
}
