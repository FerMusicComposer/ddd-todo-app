using Domain.Abstractions;

namespace Domain.ToDo.Errors
{
	public static class TodoErrors
	{
		#region GetTodoByID
		
		public static readonly Error NotFound = new("Todo.NotFound", "Couldn't find the requested Todo");
		public static readonly Error InvalidId = new("Todo.InvalidId","The provided ID is invalid");

		#endregion

		#region GetAllTodos

		public static readonly Error NotFoundAny = new("Todo.NotFoundAny", "Couldn't find any Todo");

		#endregion

		#region AddTodo

		public static readonly Error EmptyTitle = new("Todo.EmptyTitle", "Todo title cannot be empty");
		public static readonly Error NotAdded = new("Todo.NotAdded", "Couldn't add Todo. Either there was a problem with the values passed or Todo was null. Try again");

		#endregion

		#region UpdateTodo

		public static readonly Error IsNull = new("Todo.IsNull", "Todo cannot be null");
		public static readonly Error NotUpdated = new("Todo.NotUpdated", "Couldn't update Todo. Try again");

		#endregion

	}
}
