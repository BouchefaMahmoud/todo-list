using Application.Services.UseCases.AddTodoList;
using AutoMapper;
using Domain.Entities;


namespace Application.Services.Mappers
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<AddTodoListCommand, Todo>().ReverseMap();
        }
    }
}
