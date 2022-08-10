using WSProductos1001.Entities;

namespace WSProductos1001.UnitTest.Shared;

public static class ClientMother
{
    public static EClient Sandy()
    {
        return new EClient()
        {
            Address = "Calle falsa 123",
            Identification = "123456789",
            Names = "Sandy",
            Phone = "123456789",
            BirthDay = DateTime.Now,
            LastNames = "Lopez",
            MaritalStatus = 1,
            SpouseIdentification = "123456789",
            SpouseName = "Juana",
            SubjectCredit = 2
        };
    }

    public static EClient CesarCreated()
    {
        return new EClient()
        {
            Id = 1,
            Address = "Calle falsa 123",
            Identification = "123456789",
            Names = "Cesar",
            Phone = "123456789",
            BirthDay = DateTime.Now,
            LastNames = "Lopez",
            MaritalStatus = 1,
            SpouseIdentification = "123456789",
            SpouseName = "Juana",
            SubjectCredit = 2
        };
    }
    public static EClient SandyCreated()
    {
        return new EClient()
        {
            Id = 2,
            Address = "Calle falsa 123",
            Identification = "123456789",
            Names = "Cesar",
            Phone = "123456789",
            BirthDay = DateTime.Now,
            LastNames = "Lopez",
            MaritalStatus = 1,
            SpouseIdentification = "123456789",
            SpouseName = "Juana",
            SubjectCredit = 2
        };
    }
}