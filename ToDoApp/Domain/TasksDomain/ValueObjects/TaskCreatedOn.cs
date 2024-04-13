namespace Domain.TasksDomain.ValueObjects
{
	public class TaskCreatedOn(DateOnly createdOn)
	{
		public DateOnly CreationDate {  get; private set; } = createdOn;

	}
}
