using AutoMapper;
using MillionAndUp.Api.Application.Models;
using MillionAndUp.Domain;

namespace MillionAndUp.Api.Application.Mapper
{
    public class PropertyImageProfile : Profile
    {

        public PropertyImageProfile()
        {
            CreateMap<PropertyImageModel, PropertyImage>().ReverseMap();
            CreateMap<PropertyImageCreateModel, PropertyImage>();
        }
    }
}
