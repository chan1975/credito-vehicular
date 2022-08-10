using Microsoft.EntityFrameworkCore;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities.Catalogs;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository;

public class CatalogRepository : ICatalogRepository
{
    private readonly CreditContext _context;
    public CatalogRepository(CreditContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MaritalStatus>> GetAllMaritalStatus()
    {
        var maritalStatus = await _context.MaritalStatuses.ToListAsync();
        return maritalStatus;
    }

    public async Task<IEnumerable<SubjectCredit>> GetAllSubjectCredit()
    {
        var subjectCredit = await _context.SubjectCredits.ToListAsync();
        return subjectCredit;
    }
}