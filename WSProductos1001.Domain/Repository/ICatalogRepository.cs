using WSProductos1001.Entities.Catalogs;

namespace WSProductos1001.Domain.Repository;

public interface ICatalogRepository
{
    Task<IEnumerable<MaritalStatus>> GetAllMaritalStatus();
    Task<IEnumerable<SubjectCredit>> GetAllSubjectCredit();
}