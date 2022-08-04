using WSProductos1001.Entities;

namespace WSProductos1001.Test.Patio;

public class PatioUnitTest
{
    [Test]
    public void Create_Patio_Return_NewPatio()
    {
        EPatio patio = new EPatio()
        {
            Id = 1,
            Name = "Patio 1",
            Address = "Calle 1",
            Phone = "123456789",
            NumberSalePoint = 1
        };
        IPatioRepository patioRepository = new PatioRepository();
        
    }
}