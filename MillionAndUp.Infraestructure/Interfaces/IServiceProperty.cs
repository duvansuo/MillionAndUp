using MillionAndUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Infraestructure.Interfaces
{
    public interface IServiceProperty : IServiceBase<Property, int>
    {
        Task<bool> ChangePrice(int id, double Price);
    }
}
