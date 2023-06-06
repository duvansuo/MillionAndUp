using MillionAndUp.Api.Application.Models;
using MillionAndUp.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MillionAndUp.Api.Application.Models
{
    public class PropertyModel
    {
        public int IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double? Price { get; set; }
        public string? CodeInternal { get; set; }
        public short? Year { get; set; }
        public TypeProperty? TypeProperty { get; set; }
        public int IdOwner { get; set; }
        public List<PropertyImageCreateModel>? PropertyImages { get; set; }
    }
}
