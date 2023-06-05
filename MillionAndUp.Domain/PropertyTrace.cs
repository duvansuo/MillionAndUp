using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain
{
    public class PropertyTrace
    {
        [Key] 
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string? Name { get; set; }
        public double? Value { get; set; }
        public decimal? Tax { get; set; }
        public int IdProperty { get; set; }

        public Property? Property { get; set; }
    }
}
