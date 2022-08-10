using Microsoft.AspNetCore.Mvc;
using Moq;
using WSProductos1001.API.Controllers;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.Controller;

public class PatioControllerTest
{
    private Mock<IPatioService> patioServiceMock;
    private PatioController controller;
    
    [SetUp]
    public void Setup()
    {
        patioServiceMock = new Mock<IPatioService>();
        controller = new PatioController(patioServiceMock.Object);
    }
    [Test]
    public async Task GetAll_ReturnListPatios()
    {
        var mockPatioList = new List<EPatio>
        {
            new() { Id = 1, Name = "Patio 1", Address = "Calle 1", Phone = "123456789", NumberSalePoint = 1 },
            new() { Id = 2, Name = "Patio 2", Address = "Calle 2", Phone = "987654321", NumberSalePoint = 2 },
        };
        patioServiceMock
            .Setup(x => x.GetAllAsync())
            .Returns(Task.FromResult<IEnumerable<EPatio>>(mockPatioList));
        
        var listPatios =await controller.GetAll001();
        var result = listPatios.Result as OkObjectResult;
        var data = result.Value as List<EPatio>;
        Assert.IsInstanceOf<IEnumerable<EPatio>>(data);
        Assert.IsTrue(data.Count() == 2);
    }
    [Test]
    public async Task GetById_ReturnPatio()
    {
        int id = 1;
        patioServiceMock
            .Setup(x => x.GetByIdAsync(id))
            .Returns(Task.FromResult(PatioMother.Patio1Created()));
        
        var patio =await controller.GetById002(id);
        var result = patio.Result as OkObjectResult;
        var data = result.Value as EPatio;
        Assert.IsInstanceOf<EPatio>(data);
        Assert.IsTrue(data.Id == 1);
    }

    [Test]
    public async Task GetById_ReturnNotFound()
    {
        int id = 1;
        patioServiceMock
            .Setup(x => x.GetByIdAsync(id))
            .Returns(Task.FromResult<EPatio?>(null));
        
        var patio =await controller.GetById002(id);
        var result = patio.Result as NotFoundResult;
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
    [Test]
    public async Task Create_ReturnPatio()
    {
        var mockPatio = PatioMother.Patio1Created();
        patioServiceMock
            .Setup(x => x.CreateAsync(mockPatio))
            .Returns(Task.FromResult(mockPatio));
        
        var patio =await controller.Create203(mockPatio);
        var result = patio.Result as CreatedAtActionResult;
        var data = result.Value as EPatio;
        Assert.IsInstanceOf<EPatio>(data);
        Assert.IsTrue(data.Id == 1);
    }

   
}


