using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.IntegrationTest.Controlller;

public class PatioControllerTest
{

    [Test]
    public async Task GetAll_ReturnNoContent()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var responseNoContent = await client.GetAsync("/api/v1/patios");
        
        Assert.IsTrue(responseNoContent.StatusCode == HttpStatusCode.NoContent);
    }

    [Test]
    public async Task GetAll_ReturnListPatio()
    {
        await using var app = new WSProductsApiApplication();
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using(var context = provider.GetRequiredService<CreditContext>())
            {
                await context.Database.EnsureCreatedAsync();
                await context.Patios.AddAsync(new() { Id = 1, Name = "Patio 1", Address = "Calle 1", Phone = "123456789", NumberSalePoint = 1 });
                await context.Patios.AddAsync(new() { Id = 2, Name = "Patio 2", Address = "Calle 2", Phone = "987654321", NumberSalePoint = 2 });
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
        var response = await client.GetFromJsonAsync<IEnumerable<EPatio>>("/api/v1/patios");
        Assert.IsTrue(response.Count() == 2);
    }
    [Test]
    public async Task CreatePatioNull_ReturnBadRequest()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<EPatio>("/api/v1/patios", null);
        Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
    }
    [Test]
    public async Task CreatePatioMissionPhone_ReturnBadRequest()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<EPatio>("/api/v1/patios", new() { Name = "Patio 1", Address = "Calle 1", NumberSalePoint = 1 });
        Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
    }
    [Test]
    public async Task CreatePatioInvalidModel_ReturnBadRequest()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<EPatio>("/api/v1/patios", new() { Name = "Patio 1", Address = "Calle 1", Phone = "123456789", NumberSalePoint = 1 });
        Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
    }
}