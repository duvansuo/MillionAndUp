using MillionAndUp.Domain.Enum;

namespace MillionAndUp.Api.Application.Models
{
    public class PropertyEditModel
    {
        public int IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double? Price { get; set; }
        public string? CodeInternal { get; set; }
        public short? Year { get; set; }
        public TypeProperty? TypeProperty { get; set; }
        public int IdOwner { get; set; }
    }
}
