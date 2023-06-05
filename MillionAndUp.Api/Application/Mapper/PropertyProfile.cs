using AutoMapper;
using MillionAndUp.Api.Application.Models;
using MillionAndUp.Domain;

namespace MillionAndUp.Api.Application.Mapper
{
    public class PropertyProfile : Profile
    {

        public PropertyProfile()
        {
            //CreateMap<Property, PropertyModel>().ReverseMap()
            //    .ForMember(x => x.Owner, option => option.Ignore())
            //    .ForMember(x => x.propertyImages, option => option.Ignore())
            //    .ForMember(x => x.PropertyTraces, option => option.Ignore());
            CreateMap<PropertyModel, Property>().ReverseMap().ForPath(x => x.PropertyImages, or => or.MapFrom(it => it.PropertyImages.Select(it => it)));
            CreateMap<PropertyEditModel, Property>();

        }
    }
}
