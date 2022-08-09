using CsvHelper.Configuration;
using WSProductos1001.Entities;

namespace WSProductos1001.API;

public class AgentMap : ClassMap<EAgent>
{
    public AgentMap()
    {
        Map(m => m.Address).Name("direccion");
        Map(m => m.Names).Name("nombres");
        Map(m => m.LastNames).Name("apellidos");
        Map(m => m.Age).Name("edad");
        Map(m => m.Identification).Name("identificacion");
        Map(m => m.Phone).Name("telefono");
        Map(m => m.CellPhone).Name("celular");
        Map(m => m.PatioId).Name("patio");

    }
}