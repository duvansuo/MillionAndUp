using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity, TEntityId>
        : IAdd<TEntity>, IUpdate<TEntity>, IGet<TEntity, TEntityId>, ITransaction
    {
    }
}
