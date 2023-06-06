using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain
{
    public class FiltersModel
    {
        public int? Year { get; set; }
        public int? PriceMin { get; set; }
        public int? PriceMax { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
