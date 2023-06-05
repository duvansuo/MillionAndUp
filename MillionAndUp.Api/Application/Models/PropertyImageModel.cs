using System.ComponentModel.DataAnnotations;

namespace MillionAndUp.Api.Application.Models
{
    public class PropertyImageModel
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public string? File { get; set; }
        public bool? Enabled { get; set; }
    }
}