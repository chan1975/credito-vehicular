using WSProductos1001.Entities;

namespace WSProductos1001.UnitTest.Shared;

public static class PatioMother
{
    public static EPatio Patio1()
    {
        return new EPatio
        {
            Id = 1,
            Name = "Patio 1",
            Address = "Patio 1",
            Phone = "123456789",
            NumberSalePoint = 1
        };
    }
    public static EPatio Patio2()
    {
        return new EPatio
        {
            Id = 2,
            Name = "Patio 2",
            Address = "Patio 2",
            Phone = "123456789",
            NumberSalePoint = 2
        };
    }
    
    public static EPatio PatioMissingPhone()
    {
        return new EPatio
        {
            Id = 3,
            Name = "Patio 1",
            Address = "Patio 1",
            NumberSalePoint = 1
        };
    }
    public static EPatio PatioNegativeNumberSalePoint()
    {
        return new EPatio
        {
            Id = 3,
            Name = "Patio 1",
            Address = "Patio 1",
            Phone = "123456789",
            NumberSalePoint = -1
        };
    }
    public static EPatio Patio1ToCreate()
    {
        return new EPatio
        {
            Name = "Patio 1",
            Address = "Patio 1",
            Phone = "123456789",
            NumberSalePoint = 1
        };
    }
}