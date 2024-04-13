using Domain.TasksDomain.ValueObjects;

namespace Domain.TasksDomain.Entities
{
	public class Task(int id, string title, string description)
	{
		public int Id { get; set; } = id;
		public string Title { get; set; } = title;
		public string Description { get; set; } = description;
		public bool IsCompleted { get; set;}
		public TaskCreatedOn CreatedOn { get; private set; } = new TaskCreatedOn(DateOnly.FromDateTime(DateTime.UtcNow));

		public void CompleteTask()
		{
			IsCompleted = true;
		}
	}
}
