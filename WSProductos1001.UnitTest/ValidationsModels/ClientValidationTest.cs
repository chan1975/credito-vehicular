using WSProductos1001.Domain.Features.Client;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.ValidationsModels;

public class ClientValidationTest
{
    private ClientValidator _clientValidator;
    [SetUp]
    public void Setup()
    {
        _clientValidator = new ClientValidator();
    }

    [Test]
    public void Client_Validation_ShouldBeOk()
    {
        var client = ClientMother.Sandy();
        var result = _clientValidator.Validate(client);
        Assert.IsTrue(result.IsValid);
    }
    [Test]
    public void Client_Validation_ShouldBeFail()
    {
        var client = ClientMother.Sandy();
        client.Identification = null;
        var result = _clientValidator.Validate(client);
        Assert.IsFalse(result.IsValid);
    }
}