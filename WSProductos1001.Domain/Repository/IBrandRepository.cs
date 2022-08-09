using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository
{
    public interface IBrandRepository
    {
        Task<EBrand> GetByIdAsync(int id);
        Task<EBrand> CreateAsync(EBrand brand);
    }
}
