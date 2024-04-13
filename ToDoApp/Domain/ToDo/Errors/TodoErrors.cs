using Domain.Abstractions;

namespace Domain.ToDo.Errors
{
	public static class TodoErrors
	{
		public static readonly Error NotFound = new("Todo.NotFound", "Couldn't find the requested ToDo");
		public static readonly Error InvalidId = new("Todo.InvalidId",
			"The provided ID is either null, less or equal to 0, or of invalid type. Please provide a number for this parameter");

	}
}
