using FluentValidation;
using Moq;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Features.AssignClient;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.Service;

public class AssignClientServiceTest
{
    private AssignClientService _assignClientService;
    private Mock<IAssignClientRepository> _assignClientRepository;
    private Mock<IClientRepository> _clientRepository;
    private Mock<IPatioRepository> _patioRepository;
    private IValidator<AssignClient> _validator;

    [SetUp]
    public void Setup()
    {
        _assignClientRepository = new Mock<IAssignClientRepository>();
        _clientRepository = new Mock<IClientRepository>();
        _patioRepository = new Mock<IPatioRepository>();
        _validator = new ClientPatioValidator();
        _assignClientService = new AssignClientService(_assignClientRepository.Object, _clientRepository.Object, _patioRepository.Object, _validator);
    }
    
    [Test]
    public async Task AssignClientService_AssignClient_ReturnTrue()
    {
        //Arrange
        var assignClient = AssignClientMother.CesarPatio1();
        _assignClientRepository
            .Setup(x => x.CreateAsync(assignClient))
            .Returns(Task.FromResult<AssignClient>(AssignClientMother.CesarPatio1Created()));
        _clientRepository
            .Setup(x => x.GetByIdAsync(assignClient.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _patioRepository
            .Setup(x => x.GetByIdAsync(assignClient.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        //Act
        var result = await _assignClientService.CreateAsync(assignClient);
        //Assert
        Assert.IsTrue(result.Id > 0);
    }
    [Test]
    public async Task AssignClientService_InvalidCliendId_ReturnBadRequest()
    {
        var assignClient = AssignClientMother.CesarPatio1();
        _assignClientRepository
            .Setup(x => x.CreateAsync(assignClient))
            .Returns(Task.FromResult<AssignClient>(AssignClientMother.CesarPatio1Created()));
        _clientRepository
            .Setup(x => x.GetByIdAsync(assignClient.ClientId))
            .Returns(Task.FromResult<EClient>(null));
        _patioRepository
            .Setup(x => x.GetByIdAsync(assignClient.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));

        //Assert
        Assert.ThrowsAsync<BadRequestException>((async () =>await _assignClientService.CreateAsync(assignClient)));
    }
    [Test]
    public async Task AssignClientService_InvalidPatioId_ReturnBadRequest()
    {
        var assignClient = AssignClientMother.CesarPatio1();
        _assignClientRepository
            .Setup(x => x.CreateAsync(assignClient))
            .Returns(Task.FromResult<AssignClient>(AssignClientMother.CesarPatio1Created()));
        _clientRepository
            .Setup(x => x.GetByIdAsync(assignClient.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _patioRepository
            .Setup(x => x.GetByIdAsync(assignClient.PatioId))
            .Returns(Task.FromResult<EPatio>(null));

        //Assert
        Assert.ThrowsAsync<BadRequestException>((async () =>await _assignClientService.CreateAsync(assignClient)));
    }

    [Test]
    public async Task UpdateAssignClient_ValidAssingModel_ReturnVoid()
    {
        var idAssignClient = 1;
        var assignClient = AssignClientMother.CesarPatio1Updated();
        _assignClientRepository
            .Setup(x => x.UpdateAsync(assignClient))
            .Returns(Task.FromResult<AssignClient>(AssignClientMother.CesarPatio1Updated()));
        _assignClientRepository
            .Setup(x => x.GetByIdAsync(idAssignClient))
            .Returns(Task.FromResult<AssignClient>(AssignClientMother.CesarPatio1Created()));
        _clientRepository
            .Setup(x => x.GetByIdAsync(assignClient.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.SandyCreated()));
        _patioRepository
            .Setup(x => x.GetByIdAsync(assignClient.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        Assert.DoesNotThrowAsync(async() => await _assignClientService.UpdateAsync(idAssignClient,assignClient));
    }
    [Test]
    public async Task UpdateAssignClient_InvalidAssignId_ReturnNotFound()
    {
        var idAssignClient = 1;
        var assignClient = AssignClientMother.CesarPatio1Updated();
        _assignClientRepository
            .Setup(x => x.UpdateAsync(assignClient))
            .Returns(Task.FromResult<AssignClient>(AssignClientMother.CesarPatio1Updated()));
        _assignClientRepository
            .Setup(x => x.GetByIdAsync(idAssignClient))
            .Returns(Task.FromResult<AssignClient>(null));
        _clientRepository
            .Setup(x => x.GetByIdAsync(assignClient.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.SandyCreated()));
        _patioRepository
            .Setup(x => x.GetByIdAsync(assignClient.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        Assert.ThrowsAsync<NotFoundException>(async() => await _assignClientService.UpdateAsync(idAssignClient,assignClient));
    }
    
}