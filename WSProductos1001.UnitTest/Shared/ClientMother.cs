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
}