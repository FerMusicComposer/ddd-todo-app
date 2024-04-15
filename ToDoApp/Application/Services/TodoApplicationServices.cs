using Application.DTOs;
using AutoMapper;
using Domain.Abstractions;
using Domain.ToDo.Entities;
using Domain.ToDo.Services;

namespace Application.Services
{
	public class TodoApplicationServices
	{
		private readonly TodoService _todoService;
		private readonly IMapper _mapper;

		public TodoApplicationServices(TodoService todoService, IMapper mapper)
		{
			_todoService = todoService;
			_mapper = mapper;
		}

		public async Task<ResultOf<TodoDTO>> GetTodoByIDAsync(int id)
		{
			try
			{
				var result = await _todoService.GetTodoByIDAsync(id);

				if (result == null)
				{
					return ResultOf<TodoDTO>.Failure(new Error("AppServices.GetTodoByID", "TodoService GetTodoByIDAsync returned null"));
				}

				if (!result.IsSuccess)
				{
					return ResultOf<TodoDTO>.Failure(result.Error);
				}

				var retrievedTodo = _mapper.Map<TodoDTO>(result.Value);

				return ResultOf<TodoDTO>.Success(retrievedTodo);
			}
			catch (Exception ex)
			{
				return ResultOf<TodoDTO>.Failure(new Error("An error occurred while retrieving the todo.", ex));
			}
		}

		public async Task<ResultOfCollection<TodoDTO>> GetAllTodosAsync()
		{
			try
			{
				var result = await _todoService.GetAllTodosAsync();

				if (result == null)
				{
					return ResultOfCollection<TodoDTO>.Failure(new Error("AppServices.GetAllTodos", "TodoService GetAllTodosAsync returned null"));
				}

				if (!result.IsSuccess)
				{
					return ResultOfCollection<TodoDTO>.Failure(result.Error);
				}

				var todoList = _mapper.Map<List<TodoDTO>>(result.Values);

				return ResultOfCollection<TodoDTO>.Success(todoList);
			}
			catch (Exception ex)
			{
				return ResultOfCollection<TodoDTO>.Failure(new Error("An error occurred while retrieving the todo list.", ex));
			}
		}

		public async Task<ResultOf<TodoDTO>> AddTodoAsync(TodoCreateDTO newTodo)
		{
			try
			{
				var todo = _mapper.Map<Todo>(newTodo);
				var result = await _todoService.AddTodoAsync(todo);

				if (result == null)
				{
					return ResultOf<TodoDTO>.Failure(new Error("AppServices.AddTodo","TodoService AddTodoAsync returned null"));
				}

				if (!result.IsSuccess)
				{
					return ResultOf<TodoDTO>.Failure(result.Error);
				}

				var createdTodo = _mapper.Map<TodoDTO>(result.Value);

				return ResultOf<TodoDTO>.Success(createdTodo);
				
			}
			catch (Exception ex)
			{
				return ResultOf<TodoDTO>.Failure(new Error("An error occurred while adding the todo.", ex));
			}

		}

		public async Task<ResultOf<TodoDTO>> UpdateTodoAsync(TodoUpdateDTO modifiedTodo)
		{
			try
			{
				var todo = _mapper.Map<Todo>(modifiedTodo);
				var result = await _todoService.UpdateTodoAsync(todo);

				if (result == null)
				{
					return ResultOf<TodoDTO>.Failure(new Error("AppServices.UpdateTodo", "TodoService UpdateTodoAsync returned null"));
				}

				if (!result.IsSuccess)
				{
					return ResultOf<TodoDTO>.Failure(result.Error);
				}

				var updatedTodo = _mapper.Map<TodoDTO>(result.Value);

				return ResultOf<TodoDTO>.Success(updatedTodo);

			}
			catch (Exception ex)
			{
				return ResultOf<TodoDTO>.Failure(new Error("An error occurred while updating the todo.", ex));
			}

		}

		public async Task<Result> DeleteTodoAsync(TodoDTO todoToremove)
		{
			try
			{
				var todo = _mapper.Map<Todo>(todoToremove);
				var result = await _todoService.DeleteTodoAsync(todo);

				if (result == null)
				{
					return Result.Failure(new Error("AppServices.DeleteTodo", "TodoService DeleteTodoAsync returned null"));
				}

				if (!result.IsSuccess)
				{
					return Result.Failure(result.Error);
				}

				return Result.Success();

			}
			catch (Exception ex)
			{
				return Result.Failure(new Error("An error occurred while deleting the todo.", ex));
			}

		}

	}
}
