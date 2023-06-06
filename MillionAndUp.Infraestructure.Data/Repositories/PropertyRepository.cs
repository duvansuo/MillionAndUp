using Microsoft.EntityFrameworkCore;
using MillionAndUp.Domain;
using MillionAndUp.Domain.Interfaces.Repository;

namespace MillionAndUp.Infraestructure.Data.Repositories
{
    public class PropertyRepository : IRepositoryProperty<Property>
    {
        private readonly Context context;
        public PropertyRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Property> Add(Property property)
        {
            try
            {
                await context.AddAsync(property);
                return property;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Property>> GetAll()
        {
            try
            {
                return await context.Properties.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Property?> GetId(int id)
        {
            try
            {
                return await context.Properties.Where(x => x.IdProperty == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Save()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Update(Property property)
        {
            try
            {
                context.Entry(property).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Property>> GetFilters(FiltersModel filtersModel)
        {
            try
            {
                var query = context.Properties.AsQueryable();
                query = Filters(query, filtersModel);        
                return await query.OrderBy(x => x.IdProperty).Skip((filtersModel.Page - 1) * filtersModel.Size).Take(filtersModel.Size).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static IQueryable<Property> Filters(IQueryable<Property> query, FiltersModel filtersModel)
        {
            if (filtersModel.Year.HasValue)
            {
                query = query.Where(x => x.Year == filtersModel.Year);
            }
            if (filtersModel.PriceMax.HasValue && filtersModel.PriceMin.HasValue)
            {
                query = query.Where(x => x.Price >= filtersModel.PriceMin && x.Price <= filtersModel.PriceMax);
            }
            return query;
        }
      
    }
}
