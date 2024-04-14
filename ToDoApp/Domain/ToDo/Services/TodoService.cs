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

	public async Task<ResultOf<Todo>> GetTodoByIDAsync(int id)
	{
		if (id <= 0)
		{
			return ResultOf<Todo>.Failure(TodoErrors.InvalidId);
		}

		var todo = await _todoRepository.GetTodoByIdAsync(id);

		if (todo == null)
		{
			return ResultOf<Todo>.Failure(TodoErrors.NotFound);
		}

		return ResultOf<Todo>.Success(todo);
	}

	public async Task<ResultOfCollection<Todo>> GetAllTodosAsync()
	{
		var todos = await _todoRepository.GetAllTodosAsync();

		if (todos == null || !todos.Any())
		{
			return ResultOfCollection<Todo>.Failure(TodoErrors.NotFoundAny);
		}

		return ResultOfCollection<Todo>.Success(todos);
	}

	public async Task<ResultOf<Todo>> AddTodoAsync(Todo todo)
	{
		if (todo == null)
		{
			return ResultOf<Todo>.Failure(TodoErrors.NotAdded);
		}

		if (string.IsNullOrEmpty(todo.Title))
		{
			return ResultOf<Todo>.Failure(TodoErrors.EmptyTitle);
		}

		var addedTodo = await _todoRepository.AddTodoAsync(todo);

		if (addedTodo == null)
		{
			return ResultOf<Todo>.Failure(TodoErrors.NotAdded);
		}

		return ResultOf<Todo>.Success(addedTodo);
	}

	public async Task<ResultOf<Todo>> UpdateTodoAsync(Todo updatedTodo)
	{
		if (updatedTodo == null)
		{
			return ResultOf<Todo>.Failure(TodoErrors.IsNull);
		}

		var update = await _todoRepository.UpdateTodoAsync(updatedTodo);

		if (update == null)
		{
			return ResultOf<Todo>.Failure(TodoErrors.IsNull);
		}

		return ResultOf<Todo>.Success(update);
	}
}

