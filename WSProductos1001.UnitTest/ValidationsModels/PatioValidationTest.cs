using WSProductos1001.Domain.Features.Patio;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.ValidationsModels;

public class PatioValidationTest
{
    private PatioValidator _validator;
    [SetUp]
    public void Setup()
    {
        _validator = new PatioValidator();
    }
    [Test]
    public void PatioValid_ReturnTrue()
    {
        var result = _validator.Validate(PatioMother.Patio1Created());
        Assert.IsTrue(result.IsValid);
    }
    [Test]
    public void PatioValid_ReturnFalse()
    {
        var result = _validator.Validate(PatioMother.PatioMissingPhone());
        Assert.IsFalse(result.IsValid);
    }
}