using WSProductos1001.Entities;

namespace WSProductos1001.UnitTest.Shared;

public static class RequestCreditMother
{
    public static ERequestCredit InvalidRequestCredit()
    {
        return new ERequestCredit()
        {
            BuildDate = DateTime.Now,
            ClientId = 1,
            PatioId = 1,
            VehicleId = 1,
            TermMonth = 1,
            //Fee = 1,
            Entry = 1,
            AgentId = 1,
            Observation = "Observation",
        };
    }

    public static ERequestCredit CreditRequest1()
    {
        return new()
        {
            BuildDate = new DateTime(2022,1,1),
            ClientId = 1,
            PatioId = 1,
            VehicleId = 1,
            TermMonth = 1,
            Fee = 1,
            Entry = 1,
            AgentId = 1,
            Observation = "Observation"
        };
    }
    public static ERequestCredit CreditRequest1Registry()
    {
        return new()
        {
            BuildDate = new DateTime(2022,1,1),
            ClientId = 1,
            PatioId = 1,
            VehicleId = 1,
            TermMonth = 1,
            Fee = 1,
            Entry = 1,
            AgentId = 1,
            Observation = "Observation",
            CreditStatus = 1
        };
    }
    public static ERequestCredit CreditRequest2SameDateCredit1()
    {
        return new()
        {
            BuildDate = new DateTime(2022,1,1),
            ClientId = 1,
            PatioId = 2,
            VehicleId = 2,
            TermMonth = 2,
            Fee = 2,
            Entry = 2,
            AgentId = 2,
        };
    }
    public static ERequestCredit CreditRequest2DiffDateCredit1()
    {
        return new()
        {
            BuildDate = new DateTime(2022,1,2),
            ClientId = 1,
            PatioId = 2,
            VehicleId = 2,
            TermMonth = 2,
            Fee = 2,
            Entry = 2,
            AgentId = 2,
        };
    }

    public static ERequestCredit CreditRequest2Created()
    {
        return new()
        {
            Id = 2,
            BuildDate = new DateTime(2022,1,2),
            ClientId = 1,
            PatioId = 2,
            VehicleId = 2,
            TermMonth = 2,
            Fee = 2,
            Entry = 2,
            AgentId = 2,
            CreditStatus = 1
        };
    }
}