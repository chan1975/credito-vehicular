using FluentValidation;
using Moq;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Features.Patio;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.Service;

public class PatioServiceTest
{
    private PatioService _patioService;
    private Mock<IPatioRepository> _mockPatioRepository;
    private Mock<IAssignClientRepository> _mockAssignClientRepository;
    private IValidator<EPatio> _validator;
    
    [SetUp]
    public void SetUp()
    {
        _mockPatioRepository = new Mock<IPatioRepository>();
        _mockAssignClientRepository = new Mock<IAssignClientRepository>();
        _validator = new PatioValidator();
        _patioService = new PatioService(_mockPatioRepository.Object, _validator, _mockAssignClientRepository.Object);
    }

    [Test]
    public async Task DeletePatio_AssignClient_ReturnBadRequest()
    {
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        _mockAssignClientRepository
            .Setup(x => x.GetByPatioId(It.IsAny<int>()))
            .Returns(Task.FromResult<IEnumerable<EAssignClient>>(new List<EAssignClient>()
            { AssignClientMother.CesarPatio1Created() }));
        Assert.ThrowsAsync<BadRequestException>(async () => await _patioService.DeleteAsync(1));
    }
    
}