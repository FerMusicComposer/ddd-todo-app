using Domain.Abstractions;
using Domain.ToDo.Entities;
using Domain.ToDo.Errors;
using Domain.ToDo.Repositories;

namespace Domain.ToDo.Services;

public sealed class TodoService
{
	private readonly ITodoRepository _todoRepository;

	public TodoService(ITodoRepository todoRepository)
	{
		_todoRepository = todoRepository;
	}

	public async Task<Result<Todo>> GetTodoByIDAsync(int id)
	{
		if (id <= 0) 
		{
			return Result<Todo>.Failure(TodoErrors.InvalidId);
		}

		var todo = await _todoRepository.GetTodoByIdAsync(id);

		if (todo == null)
		{
			return Result<Todo>.Failure(TodoErrors.NotFound);
		}

		return Result<Todo>.Success(todo);
	}
}

