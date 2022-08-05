using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Patio;

public class PatioService: IPatioService
{
    public async Task<IEnumerable<EPatio>> GetAll()
    {
        var patioList = new List<EPatio>()
        {
            new EPatio() { Id = 1, Name = "Patio 1", Address = "Calle1", Phone = "123456789", NumberSalePoint = 1 },
        };
        return patioList;
    }
}