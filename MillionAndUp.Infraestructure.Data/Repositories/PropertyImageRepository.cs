using Microsoft.EntityFrameworkCore;
using MillionAndUp.Domain;
using MillionAndUp.Domain.Interfaces.Repository;

namespace MillionAndUp.Infraestructure.Data.Repositories
{
    public class PropertyImageRepository : IReposityImage<PropertyImage>
    {
        private readonly Context context;
        public PropertyImageRepository(Context context)
        {
            this.context = context;
        }

        public async Task<PropertyImage> Add(PropertyImage propertyImage)
        {
            try
            {
                await context.AddAsync(propertyImage);
                return propertyImage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddRangeAsync(List<PropertyImage> propertyImages)
        {
            try
            {
                await context.AddRangeAsync(propertyImages);              
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
    }
}
