using AutoMapper;
using ToDoListAPI.Models;

namespace ToDoListAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskToDo, TaskToDoResponse>()
                .ForMember(dest => dest.TaskToDoResponseId, 
                            opt => opt.MapFrom(src => src.TaskToDoId))
                .ForMember(dest => dest.DescriptionText, 
                            opt => opt.MapFrom(src => $"{src.DescriptionText} (Due Date: {src.DueDate.ToShortDateString()})"));

            CreateMap<User, UserResponse>();
        }
    }
}

