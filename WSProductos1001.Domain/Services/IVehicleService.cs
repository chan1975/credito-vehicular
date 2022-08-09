using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<EVehicle>> GetAllAsync();
    }
}
