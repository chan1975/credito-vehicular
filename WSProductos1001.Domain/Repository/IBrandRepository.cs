using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository
{
    public interface IBrandRepository
    {
        Task<EBrand> GetByIdAsync(int id);
        Task<EBrand> CreateAsync(EBrand brand);
    }
}
