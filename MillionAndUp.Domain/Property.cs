using MillionAndUp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain
{
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double? Price { get; set; }
        public string? CodeInternal { get; set; }
        public short? Year { get; set; }
        public TypeProperty? TypeProperty { get; set; }
        public int IdOwner { get; set; }

        public Owner? Owner { get; set; }
        public ICollection<PropertyImage> PropertyImages { get; set; }
        public ICollection<PropertyTrace> PropertyTraces { get; set; }

    }
}
