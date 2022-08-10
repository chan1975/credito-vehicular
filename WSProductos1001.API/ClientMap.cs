using CsvHelper.Configuration;
using WSProductos1001.Entities;

namespace WSProductos1001.API;

public class ClientMap: ClassMap<EClient>
{
    public ClientMap()
    {
        Map(x => x.Identification).Name("identificacion");
        Map(x => x.Names).Name("nombres");
        Map(x => x.BirthDay).Name("fecha_nacimiento");
        Map(x => x.LastNames).Name("apellidos");
        Map(x => x.Address).Name("direccion");
        Map(x => x.Phone).Name("telefono");
        Map(x => x.MaritalStatus).Name("estado_civil");
        Map(x => x.SpouseIdentification).Name("identificacion_conyuge");
        Map(x => x.SpouseName).Name("nombre_conyuge");
        Map(x => x.SubjectCredit).Name("sujeto_credito");
    }
}