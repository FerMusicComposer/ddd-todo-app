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
		try
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
		catch (Exception ex)
		{
			return ResultOf<Todo>.Failure(new Error("Todo.Exception", ex));
		}
	}

	public async Task<ResultOfCollection<Todo>> GetAllTodosAsync()
	{
		try
		{
			var todos = await _todoRepository.GetAllTodosAsync();

			if (todos == null || !todos.Any())
			{
				return ResultOfCollection<Todo>.Failure(TodoErrors.NotFoundAny);
			}

			return ResultOfCollection<Todo>.Success(todos);
		}
		catch (Exception ex)
		{
			return ResultOfCollection<Todo>.Failure(new Error("Todo.Exception", ex));
		}
	}

	public async Task<ResultOf<Todo>> AddTodoAsync(Todo todo)
	{
		try
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
		catch (Exception ex)
		{
			return ResultOf<Todo>.Failure(new Error("Todo.Exception", ex));
		}
	}

	public async Task<ResultOf<Todo>> UpdateTodoAsync(Todo updatedTodo)
	{
		try
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
		catch (Exception ex)
		{
			return ResultOf<Todo>.Failure(new Error("Todo.Exception", ex));
		}
	}

	public async Task<Result> DeleteTodoAsync(Todo todo)
	{
		try
		{
			var result = await _todoRepository.DeleteTodoAsync(todo);

			if (result == null || !result.IsSuccess)
			{
				return Result.Failure(TodoErrors.IsNull);
			}

			return Result.Success();
		}
		catch (Exception ex)
		{
			return Result.Failure(new Error("Todo.Exception", ex));
		}
	}
}

