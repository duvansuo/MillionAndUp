using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.Interfaces
{
    public interface IGet<TEntity, TEntityId>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetId(TEntityId id);

    }
}
