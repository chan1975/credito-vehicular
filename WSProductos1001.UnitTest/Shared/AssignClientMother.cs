using WSProductos1001.Entities;

namespace WSProductos1001.UnitTest.Shared;

public static class AssignClientMother
{
    public static EAssignClient CesarPatio1()
    {
        return new EAssignClient()
        {
            ClientId = 1,
            PatioId = 1,
            AssignDate = DateTime.Now
        };
    } 
    public static EAssignClient CesarPatio1Created()
    {
        return new EAssignClient()
        {
            Id = 1,
            ClientId = 1,
            PatioId = 1,
            AssignDate = DateTime.Now
        };
    } 
    public static EAssignClient CesarPatio1Updated()
    {
        return new EAssignClient()
        {
            Id = 1,
            ClientId = 2,
            PatioId = 1,
            AssignDate = DateTime.Now
        };
    } 
}