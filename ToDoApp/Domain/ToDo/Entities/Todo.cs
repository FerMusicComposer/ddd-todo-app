using Domain.ToDo.ValueObjects;

namespace Domain.ToDo.Entities
{
	public class Todo(string title, string description)
	{
		public int Id { get; set; }
		public string Title { get; set; } = title;
		public string Description { get; set; } = description;
		public bool IsCompleted { get; set;}
		public TodoCreatedOn CreatedOn { get; private set; } = new TodoCreatedOn(DateOnly.FromDateTime(DateTime.UtcNow));

		public void CompleteTask()
		{
			IsCompleted = true;
		}
	}
}
