using Domain.Abstractions;

namespace Domain.ToDo.Errors
{
	public static class TodoErrors
	{
		public static readonly Error NotFound = new("Todo.NotFound", "Couldn't find the requested ToDo");


	}
}
