using WSProductos1001.Entities;

namespace WSProductos1001.UnitTest.Shared;

public static class AssignClientMother
{
    public static AssignClient CesarPatio1()
    {
        return new AssignClient()
        {
            ClientId = 1,
            PatioId = 1,
            AssignDate = DateTime.Now
        };
    } 
    public static AssignClient CesarPatio1Created()
    {
        return new AssignClient()
        {
            Id = 1,
            ClientId = 1,
            PatioId = 1,
            AssignDate = DateTime.Now
        };
    } 
    public static AssignClient CesarPatio1Updated()
    {
        return new AssignClient()
        {
            Id = 1,
            ClientId = 2,
            PatioId = 1,
            AssignDate = DateTime.Now
        };
    } 
}