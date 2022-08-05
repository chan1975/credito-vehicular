using Microsoft.AspNetCore.Mvc;
using Moq;
using WSProductos1001.API.Controllers;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

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
            .Setup(x => x.GetAll())
            .Returns(Task.FromResult<IEnumerable<EPatio>>(mockPatioList));
        
        var listPatios =await controller.GetAll001();
        var result = listPatios.Result as OkObjectResult;
        var data = result.Value as List<EPatio>;
        Assert.IsInstanceOf<IEnumerable<EPatio>>(data);
        Assert.IsTrue(data.Count() == 2);
    }
}


