using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;

namespace WSProductos1001.Domain.Features.Brand
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task UploadBrands(List<string> brands)
        {
            if(brands.Count() != brands.Distinct().Count())
                throw new BadRequestException("Existen elementos duplicados en la lista");

            foreach (var brand in brands)
            {
                await _brandRepository.CreateAsync(new() { Name = brand });
            }
        }
    }
}
