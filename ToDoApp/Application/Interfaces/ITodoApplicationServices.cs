using Application.DTOs;
using Domain.Abstractions;

namespace Application.Interfaces
{
	public interface ITodoApplicationServices
	{
		Task<ResultOf<TodoDTO>> GetTodoByIDAsync(int id);
		Task<ResultOfCollection<TodoDTO>> GetAllTodosAsync();
		Task<ResultOf<TodoDTO>> AddTodoAsync(TodoCreateDTO newTodo);
		Task<ResultOf<TodoDTO>> UpdateTodoAsync(TodoUpdateDTO modifiedTodo);

		Task<Result> DeleteTodoAsync(TodoDTO todoToRemove);

	}
}
