using WSProductos1001.Domain.Features.Agent;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.ValidationsModels;

public class AgentValidationTest
{
    private AgentValidator _agentValidator;
    [SetUp]
    public void SetUp()
    {
        _agentValidator = new AgentValidator();
    }
    [Test]
    public void Agent_Validation_ShouldBeOk()
    {
        var agent = AgentMother.Cesar();
        var result = _agentValidator.Validate(agent);
        Assert.IsTrue(result.IsValid);
    }
    [Test]
    public void Agent_Missing_Name_ShouldBeNotOk()
    {
        var agent = AgentMother.Cesar();
        agent.Names = null;
        var result = _agentValidator.Validate(agent);
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual(1, result.Errors.Count);
    }
}