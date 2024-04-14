using AutoMapper;
using Domain.ToDo.Entities;

namespace Application.DTOs
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile() 
		{ 
			CreateMap<Todo, TodoDTO>()
				.ForMember(dto => dto.CreatedOn, conf => conf.MapFrom(entity => entity.CreatedOn));

			CreateMap<TodoCreateDTO, Todo>()
				.ForCtorParam("title", options => options.MapFrom(dto => dto.Title))
				.ForCtorParam("description", options => options.MapFrom(dto => dto.Description));

			CreateMap<TodoUpdateDTO, Todo>()
				.ForMember(entity => entity.Title, conf => conf.MapFrom(dto => dto.Title))
				.ForMember(entity => entity.Description, conf => conf.MapFrom(dto => dto.Description))
				.ForMember(entity => entity.IsCompleted, conf => conf.MapFrom(dto => dto.IsCompleted))
				.IgnoreAllPropertiesWithAnInaccessibleSetter();
		}
	}
}
