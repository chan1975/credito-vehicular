using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Services;

public interface IAgentService
{
    Task<IEnumerable<EAgent>> GetAllAsync();
    Task UploadAgents(List<EAgent> listAgent);
}