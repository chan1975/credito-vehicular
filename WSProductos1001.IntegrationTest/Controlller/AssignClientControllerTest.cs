using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.IntegrationTest.Controlller;

public class AssignClientControllerTest
{
    [Test]
    public async Task CreateAssignClient_ReturnOk()
    {
        await using var app = new WSProductsApiApplication();
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using(var context = provider.GetRequiredService<CreditContext>())
            {
                await context.Database.EnsureCreatedAsync();
                await context.Clients.AddAsync(ClientMother.Sandy());
                await context.Patios.AddAsync(PatioMother.Patio1ToCreate());
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<EAssignClient>("/api/v1/patios/asignarcliente", AssignClientMother.SandyPatio1());
        var result = await response.Content.ReadAsStringAsync();
        var assignClient = await response.Content.ReadFromJsonAsync<EAssignClient>();
        var responseFindAssign = await client.GetFromJsonAsync<EAssignClient>($"/api/v1/patios/asignarcliente/{assignClient.Id}");
        Assert.IsTrue(responseFindAssign.Id == assignClient.Id);
    }
    
    [Test]
    public async Task UpdateAssignClient_ReturnOk()
    {
        await using var app = new WSProductsApiApplication();
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using(var context = provider.GetRequiredService<CreditContext>())
            {
                await context.Database.EnsureCreatedAsync();
                await context.Clients.AddAsync(ClientMother.Sandy());
                await context.Patios.AddAsync(PatioMother.Patio1ToCreate());
                await context.AssignClients.AddAsync(AssignClientMother.SandyPatio1());
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
        var assignClientToCreate = AssignClientMother.SandyPatio1();
        var updateDate = new DateTime(2022, 1, 10);
        assignClientToCreate.AssignDate = updateDate;
        var response = await client.PutAsJsonAsync<EAssignClient>($"/api/v1/patios/asignarcliente/1", assignClientToCreate);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        
        var responseFindAssign = await client.GetFromJsonAsync<EAssignClient>($"/api/v1/patios/asignarcliente/1");
        Assert.IsTrue(responseFindAssign.AssignDate.Date == updateDate.Date);
    }
    
    [Test]
    public async Task DeleteAssignClient_ReturnOk()
    {
        await using var app = new WSProductsApiApplication();
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using(var context = provider.GetRequiredService<CreditContext>())
            {
                await context.Database.EnsureCreatedAsync();
                await context.AssignClients.AddAsync(AssignClientMother.SandyPatio1());
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
        
        var response = await client.DeleteAsync($"/api/v1/patios/asignarcliente/1");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        
        var responseFindAssign = await client.GetAsync($"/api/v1/patios/asignarcliente/1");
        result = await responseFindAssign.Content.ReadAsStringAsync();
        Assert.IsTrue(responseFindAssign.StatusCode == HttpStatusCode.NotFound);
    }
}