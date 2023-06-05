using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.Interfaces.Repository
{
    public interface IReposityImage<TEntity> : IAdd<TEntity>, ITransaction where TEntity :  class 
    {
        Task AddRangeAsync(List<TEntity> entity);
    }
}
