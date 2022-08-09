using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository
{
    internal class BrandRepository : IBrandRepository
    {
        private readonly CreditContext _context;
        public BrandRepository(CreditContext context)
        {
            _context = context;
        }
        public async Task<EBrand> CreateAsync(EBrand brand)
        {
            var newBrand = await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return newBrand.Entity;
        }

        public async Task<EBrand> GetByIdAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            return brand;
        }
    }
}
