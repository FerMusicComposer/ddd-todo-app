﻿using Domain.Abstractions;

namespace Domain.ToDo.Errors
{
	public static class TodoErrors
	{
		#region GetTodoByID
		
		public static readonly Error NotFound = new("Todo.NotFound", "Couldn't find the requested Todo");
		public static readonly Error InvalidId = new("Todo.InvalidId","The provided ID is invalid.");

		#endregion

		#region GetAllTodos

		public static readonly Error NotFoundAny = new("Todo.NotFoundAny", "Couldn't find any Todo.");

		#endregion

	}
}
