using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain
{
    public class Owner
    {
        [Key]
        public int IdOwner{ get; set; }
        public string? Name{ get; set; }
        public string? Address { get; set; }
        public string? Photo{ get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birhday{ get; set; }

        public ICollection<Property>? Properties{ get; set; }
    }
}
