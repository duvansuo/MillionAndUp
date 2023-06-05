using MillionAndUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Infraestructure.Interfaces
{
    public interface IServiceBase<TEntity, TEntityId>
        : IAdd<TEntity>, IUpdate<TEntity>, IGet<TEntity, TEntityId>
    {
      
    }
}
