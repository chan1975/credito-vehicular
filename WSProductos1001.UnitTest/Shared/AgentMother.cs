using WSProductos1001.Entities;

namespace WSProductos1001.UnitTest.Shared;

public static class AgentMother
{
    public static EAgent Cesar()
    {
        return new EAgent()
        {
            Id = 1,
            Address = "Colon y America",
            Age = 30,
            Identification = "0803287911",
            Names = "Cesar Abraham",
            Phone = "023336699",
            CellPhone = "0987465423",
            LastNames = "Saavedra Drouet",
            PatioId = 1
        };
    }
}