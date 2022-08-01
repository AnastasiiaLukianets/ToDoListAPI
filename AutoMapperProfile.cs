using AutoMapper;
using ToDoListAPI.Models;

namespace ToDoListAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskToDoDTO, TaskToDoResponse>()
                .ForMember(
                    dest => dest.DescriptionText,
                    opt => opt.MapFrom(src => $"{src.DescriptionText} (Due Date: {src.DueDate.ToShortDateString()})"));
        }
    }
}
