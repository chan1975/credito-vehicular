using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Services;

public interface IClientService
{
    Task UploadClients(List<EClient> listClient);
}