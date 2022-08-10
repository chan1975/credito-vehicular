using FluentValidation;
using Moq;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Features.Vehicle;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.Service;

public class VehicleServiceTest
{
    private VehicleService _vehicleService;
    private  Mock<IVehicleRepository> _mockVehicleRepository;
    private  Mock<IBrandRepository> _mockBrandRepository;
    private Mock<IRequestCreditRepository> _mockRequestCreditRepository;
    private  IValidator<EVehicle> _validator;
    
    [SetUp]
    public void SetUp()
    {
        _mockVehicleRepository = new Mock<IVehicleRepository>();
        _mockBrandRepository = new Mock<IBrandRepository>();
        _mockRequestCreditRepository = new Mock<IRequestCreditRepository>();
        _validator = new VehicleValidator();
        _vehicleService = new VehicleService(_mockVehicleRepository.Object, _validator, _mockBrandRepository.Object, _mockRequestCreditRepository.Object);
    }
    
    [Test]
    public async Task DeleteVehicle_RequestCreditReserved_ReturnBadRequest()
    {
        _mockVehicleRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .Returns(Task.FromResult<EVehicle>(VehicleMother.Creta2018()));
        _mockRequestCreditRepository
            .Setup(x => x.GetRequestCreditByVehicleRegistry(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(Task.FromResult<ERequestCredit>(RequestCreditMother.CreditRequest2Created()));
        Assert.ThrowsAsync<BadRequestException>(async () => await _vehicleService.DeleteAsync(1));
    }
}