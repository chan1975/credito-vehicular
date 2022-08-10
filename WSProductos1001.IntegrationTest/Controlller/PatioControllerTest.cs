using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;
using WSProductos1001.UnitTest.Shared;

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
                await context.Patios.AddAsync(PatioMother.Patio1Created());
                await context.Patios.AddAsync(PatioMother.Patio2());
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
        var response = await client.PostAsJsonAsync<EPatio>("/api/v1/patios",PatioMother.PatioMissingPhone());
        Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
    }
    [Test]
    public async Task CreatePatioInvalidModel_ReturnBadRequest()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<EPatio>("/api/v1/patios", PatioMother.PatioNegativeNumberSalePoint());
        Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
    }
    [Test]
    public async Task CreatePatio_FindPatioById_ReturnPatio()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<EPatio>("/api/v1/patios", PatioMother.Patio1ToCreate());
        var jsonPatio = response.Content.ReadAsStringAsync();
        var responsePatio = JsonConvert.DeserializeObject<EPatio>(jsonPatio.Result);
        var responseGet = await client.GetFromJsonAsync<EPatio>($"/api/v1/patios/{responsePatio.Id}");
        Assert.IsTrue(responseGet.Id == responsePatio.Id);
    }
    [Test]
    public async Task UpdatePatio_ReturnNoContent()
    {
        await using var app = new WSProductsApiApplication();
        var patioBody = PatioMother.Patio1ToCreate();
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using (var context = provider.GetRequiredService<CreditContext>())
            {
                await context.Database.EnsureCreatedAsync();
                await context.Patios.AddAsync(patioBody);
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
        patioBody.Phone = "09888888";
        var responseUpdate = await client.PutAsJsonAsync<EPatio>($"/api/v1/patios/1", patioBody);
        
        Assert.IsTrue(responseUpdate.StatusCode == HttpStatusCode.NoContent);
    }
    [Test]
    public async Task UpdatePatio_ReturnNotFound()
    {
        await using var app = new WSProductsApiApplication();
        var patioBody = PatioMother.Patio1ToCreate();
       
        var client = app.CreateClient();
        patioBody.Phone = "09888888";
        var responseUpdate = await client.PutAsJsonAsync<EPatio>($"/api/v1/patios/1", patioBody);

        Assert.IsTrue(responseUpdate.StatusCode == HttpStatusCode.NotFound);
    }
    [Test]
    public async Task DeletePation_ReturnNotFound()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var response = await client.DeleteAsync($"/api/v1/patios/1");
        Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
    }
    [Test]
    public async Task DeletePatio_ReturnNoContent()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using (var context = provider.GetRequiredService<CreditContext>())
            {
                await context.Database.EnsureCreatedAsync();
                await context.Patios.AddAsync(PatioMother.Patio1ToCreate());
                await context.SaveChangesAsync();
            }
        }
        var response = await client.DeleteAsync($"/api/v1/patios/1");
        Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
    }
}