namespace Domain.ToDo.ValueObjects
{
	public class TodoCreatedOn(DateOnly createdOn)
	{
		public DateOnly CreatedOn {  get; private set; } = createdOn;

	}
}
