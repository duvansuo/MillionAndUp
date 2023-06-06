using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.Interfaces.Repository
{
    public interface IRepositoryProperty<TEntity> :IRepositoryBase<Property, int> where TEntity : class
    {
        Task<List<Property>> GetFilters(FiltersModel filtersModel);
    }
}
