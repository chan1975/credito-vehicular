using WSProductos1001.Domain.Features.AssignClient;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.ValidationsModels;

public class ClientPatioValidationTest
{
    private ClientPatioValidator _clientPatioValidator;
    [SetUp]
    public void SetUp()
    {
        _clientPatioValidator = new ClientPatioValidator();
    }

    [Test]
    public void ClientPatio_Valid_ShouldBeTrue()
    {
        var clientPatio = AssignClientMother.CesarPatio1();
        var result = _clientPatioValidator.Validate(clientPatio);
        Assert.True(result.IsValid);
    }

    [Test]
    public void ClientPatio_Null_ShouldCountTwoErrors()
    {
        var clientAssign = AssignClientMother.CesarPatio1();
        clientAssign.ClientId = -1;
        clientAssign.PatioId = -1;
        var result = _clientPatioValidator.Validate(clientAssign);
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual(2, result.Errors.Count);
    }
}