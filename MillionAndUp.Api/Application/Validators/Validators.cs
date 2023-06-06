using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain;

namespace MillionAndUp.Api.Application.Validators
{
    public class Validators
    {
        public FiltersModel ValidateFilter(int? year, string? priceRange, int page, int size)
        {
            try
            {
                FiltersModel filters = new()
                {
                    Year = year,
                    Page = page,
                    Size = size
                };
                if (!string.IsNullOrEmpty(priceRange))
                {
                    var price = priceRange.Split('-');
                    filters.PriceMin =Convert.ToInt16(price[0]);
                    filters.PriceMax =Convert.ToInt16(price[1]);
                }
             
                return filters;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
