using Microsoft.EntityFrameworkCore;
using MillionAndUp.Domain;
using MillionAndUp.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Infraestructure.Data.Repositories
{
    public class PropertyRepository : IRepository<Property, int>
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
    }
}
