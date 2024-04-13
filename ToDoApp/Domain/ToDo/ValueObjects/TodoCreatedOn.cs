namespace Domain.ToDo.ValueObjects
{
	public class TodoCreatedOn(DateOnly createdOn)
	{
		public DateOnly CreationDate {  get; private set; } = createdOn;

	}
}
