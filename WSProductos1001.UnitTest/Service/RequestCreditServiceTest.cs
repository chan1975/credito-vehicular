using FluentValidation;
using Moq;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Features.RequestCredit;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.UnitTest.Shared;
using ValidationException = WSProductos1001.Domain.Exceptions.ValidationException;

namespace WSProductos1001.UnitTest.Service;

public class RequestCreditServiceTest
{
    private RequestCreditService _requestCreditService;
    private Mock<IRequestCreditRepository> _mockRequestCreditRepository;
    private Mock<IClientRepository> _mockClientRepository;
    private Mock<IPatioRepository> _mockPatioRepository;
    private Mock<IVehicleRepository> _mockVehicleRepository;
    private Mock<IAgentRepository> _mockAgentRepository;
    private IValidator<ERequestCredit> _validator;
    private Mock<IAssignClientRepository> _mockAssignClientRepository;

    [SetUp]
    public void SetUp()
    {
        _mockRequestCreditRepository = new Mock<IRequestCreditRepository>();
        _mockClientRepository = new Mock<IClientRepository>();
        _mockPatioRepository = new Mock<IPatioRepository>();
        _mockVehicleRepository = new Mock<IVehicleRepository>();
        _mockAgentRepository = new Mock<IAgentRepository>();
        _validator = new RequestCreditValidator();
        _mockAssignClientRepository = new Mock<IAssignClientRepository>();
        _requestCreditService = new RequestCreditService(_mockRequestCreditRepository.Object, _mockClientRepository.Object, 
            _mockPatioRepository.Object, _mockVehicleRepository.Object, _mockAgentRepository.Object, _validator, _mockAssignClientRepository.Object);
    }

    [Test]
    public async Task CreateInvalidRequestCredit_ReturnBadRequest()
    {
        var invalidRequest = RequestCreditMother.InvalidRequestCredit();
        Assert.ThrowsAsync<ValidationException>(async() => await _requestCreditService.CreateAsync(invalidRequest));
    }

    [Test]
    public async Task CreateRequestCedit_InvalidClient_ReturnBadRequest()
    {
        var invalidRequest = RequestCreditMother.CreditRequest1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.ClientId))
            .Returns(Task.FromResult<EClient>(null));
        Assert.ThrowsAsync<BadRequestException>(async()=>await _requestCreditService.CreateAsync(invalidRequest));
    }

    [Test]
    public async Task CreateRequestCredit_InvalidPatio_ReturnBadResquest()
    {
        var invalidRequest = RequestCreditMother.CreditRequest1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.PatioId))
            .Returns(Task.FromResult<EPatio>(null));
        Assert.ThrowsAsync<BadRequestException>(async()=>await _requestCreditService.CreateAsync(invalidRequest));
    }
    [Test]
    public async Task CreateRequestCredit_InvalidVehicle_ReturnBadResquest()
    {
        var invalidRequest = RequestCreditMother.CreditRequest1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        _mockVehicleRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.VehicleId))
            .Returns(Task.FromResult<EVehicle>(null));
        Assert.ThrowsAsync<BadRequestException>(async()=>await _requestCreditService.CreateAsync(invalidRequest));
    }
    [Test]
    public async Task CreateRequestCredit_InvalidAgent_ReturnBadResquest()
    {
        var invalidRequest = RequestCreditMother.CreditRequest1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        _mockVehicleRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.VehicleId))
            .Returns(Task.FromResult<EVehicle>(VehicleMother.Creta2018()));
        _mockAgentRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.AgentId))
            .Returns(Task.FromResult<EAgent>(null));
        Assert.ThrowsAsync<BadRequestException>(async()=>await _requestCreditService.CreateAsync(invalidRequest));
    }
    [Test]
    public async Task CreateRequestCredit_SameDay_ReturnBadResquest()
    {
        var invalidRequest = RequestCreditMother.CreditRequest2SameDateCredit1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        _mockVehicleRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.VehicleId))
            .Returns(Task.FromResult<EVehicle>(VehicleMother.Creta2018()));
        _mockAgentRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.AgentId))
            .Returns(Task.FromResult<EAgent>(AgentMother.Cesar()));
        _mockRequestCreditRepository
            .Setup(x => x.GetRequestCreditByClientId(invalidRequest.ClientId))
            .Returns(Task.FromResult<IEnumerable<ERequestCredit>>(new List<ERequestCredit> { RequestCreditMother.CreditRequest1() }));
        
        Assert.ThrowsAsync<BadRequestException>(async()=>await _requestCreditService.CreateAsync(invalidRequest));
    }
    [Test]
    public async Task CreateRequestCredit_VahicleRegistry_ReturnBadResquest()
    {
        var invalidRequest = RequestCreditMother.CreditRequest2DiffDateCredit1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        _mockVehicleRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.VehicleId))
            .Returns(Task.FromResult<EVehicle>(VehicleMother.Creta2018()));
        _mockAgentRepository
            .Setup(x => x.GetByIdAsync(invalidRequest.AgentId))
            .Returns(Task.FromResult<EAgent>(AgentMother.Cesar()));
        _mockRequestCreditRepository
            .Setup(x => x.GetRequestCreditByClientId(invalidRequest.ClientId))
            .Returns(Task.FromResult<IEnumerable<ERequestCredit>>(new List<ERequestCredit> { RequestCreditMother.CreditRequest1() }));
        _mockRequestCreditRepository
            .Setup(x => x.GetRequestCreditByVehicleRegistry(invalidRequest.VehicleId, (int)CreditStatus.Registry))
            .Returns(Task.FromResult<ERequestCredit>(RequestCreditMother.CreditRequest2Created()));
        Assert.ThrowsAsync<BadRequestException>(async()=>await _requestCreditService.CreateAsync(invalidRequest));
    }
    [Test]
    public async Task CreateRequestCredit_DiffDay_ReturnOk()
    {
        var validRequest = RequestCreditMother.CreditRequest2DiffDateCredit1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(validRequest.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(validRequest.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        _mockVehicleRepository
            .Setup(x => x.GetByIdAsync(validRequest.VehicleId))
            .Returns(Task.FromResult<EVehicle>(VehicleMother.Creta2018()));
        _mockAgentRepository
            .Setup(x => x.GetByIdAsync(validRequest.AgentId))
            .Returns(Task.FromResult<EAgent>(AgentMother.Cesar()));
        _mockRequestCreditRepository
            .Setup(x => x.GetRequestCreditByClientId(validRequest.ClientId))
            .Returns(Task.FromResult<IEnumerable<ERequestCredit>>(new List<ERequestCredit> { RequestCreditMother.CreditRequest1() }));
        _mockRequestCreditRepository
            .Setup(x => x.CreateAsync(validRequest))
            .Returns(Task.FromResult<ERequestCredit>(RequestCreditMother.CreditRequest2Created()));
        var result = await _requestCreditService.CreateAsync(validRequest);
        Assert.IsTrue(result.Id == 2);
        Assert.IsTrue(result.CreditStatus == 1);
    }
    [Test]
    public async Task CreateRequestCredit_DiffDay_CreateAssignCalldOnce()
    {
        var validRequest = RequestCreditMother.CreditRequest2DiffDateCredit1();
        _mockClientRepository
            .Setup(x => x.GetByIdAsync(validRequest.ClientId))
            .Returns(Task.FromResult<EClient>(ClientMother.CesarCreated()));
        _mockPatioRepository
            .Setup(x => x.GetByIdAsync(validRequest.PatioId))
            .Returns(Task.FromResult<EPatio>(PatioMother.Patio1Created()));
        _mockVehicleRepository
            .Setup(x => x.GetByIdAsync(validRequest.VehicleId))
            .Returns(Task.FromResult<EVehicle>(VehicleMother.Creta2018()));
        _mockAgentRepository
            .Setup(x => x.GetByIdAsync(validRequest.AgentId))
            .Returns(Task.FromResult<EAgent>(AgentMother.Cesar()));
        _mockRequestCreditRepository
            .Setup(x => x.GetRequestCreditByClientId(validRequest.ClientId))
            .Returns(Task.FromResult<IEnumerable<ERequestCredit>>(new List<ERequestCredit> { RequestCreditMother.CreditRequest1() }));
        _mockRequestCreditRepository
            .Setup(x => x.CreateAsync(validRequest))
            .Returns(Task.FromResult<ERequestCredit>(RequestCreditMother.CreditRequest2Created()));
        _mockAssignClientRepository
            .Setup(x => x.CreateAsync(It.IsAny<EAssignClient>()))
            .Returns(Task.FromResult<EAssignClient>(AssignClientMother.CesarPatio1Created()));
        var result = await _requestCreditService.CreateAsync(validRequest);
        
        _mockAssignClientRepository.Verify(x => x.CreateAsync(It.IsAny<EAssignClient>()), Times.Once);
    }

    [Test]
    public async Task UpdateStatusRequestCredit_InvalidId_ReturnNotFound()
    {
        _mockRequestCreditRepository
            .Setup(x => x.GetByIdAndRegsitryAsync(It.IsAny<int>(), (int)CreditStatus.Registry))
            .Returns(Task.FromResult<ERequestCredit>(null));
        Assert.ThrowsAsync<NotFoundException>(async()=>await _requestCreditService.UpdateCreditStatusAsync(1,CreditStatus.Dispached));
    }

    [Test]
    public async Task UpdateStatusRequestCredit_UpdateRequestCalldOnce()
    {
        _mockRequestCreditRepository
            .Setup(x => x.GetByIdAndRegsitryAsync(It.IsAny<int>(),It.IsAny<int>() ))
            .Returns(Task.FromResult<ERequestCredit>(RequestCreditMother.CreditRequest2Created()));
        await _requestCreditService.UpdateCreditStatusAsync(2,CreditStatus.Dispached);
        _mockRequestCreditRepository.Verify(x => x.UpdateAsync(It.IsAny<ERequestCredit>()), Times.Once);
    }
}