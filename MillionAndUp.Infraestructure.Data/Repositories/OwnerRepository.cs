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
    public class OwnerRepository : IRepository<Owner, int>
    {
        private readonly Context context;
        public OwnerRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Owner> Add(Owner owner)
        {
            try
            {
                await context.AddAsync(owner);
                return owner;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Owner>> GetAll()
        {
            try
            {
                return await context.Owners.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Owner?> GetId(int id)
        {
            try
            {
                return await context.Owners.Where(x => x.IdOwner == id).FirstOrDefaultAsync();
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

        public async Task<bool> Update(Owner owner)
        {
            try
            {
                context.Entry(owner).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
