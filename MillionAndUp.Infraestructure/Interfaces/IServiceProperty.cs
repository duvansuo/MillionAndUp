using MillionAndUp.Domain;

namespace MillionAndUp.Infraestructure.Interfaces
{
    public interface IServiceProperty<TEntity> : IServiceBase<Property, int>
    {
        Task<bool> ChangePrice(int id, double Price);
        Task<List<Property>> GetFilters(FiltersModel filtersModel);
    }
}
