using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Domain.Features.RequestCredit;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.IntegrationTest.Controlller;

public class RequestCreditControllerTest
{
    [Test]
    public async Task CreateRequestCredit_ReturnCreated()
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
                await context.Vehicles.AddAsync(VehicleMother.Creta2018());
                await context.Agents.AddAsync(AgentMother.Cesar());
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<ERequestCredit>("/api/v1/solicitudes", RequestCreditMother.CreditRequest1());
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        var requestCredit = await response.Content.ReadFromJsonAsync<ERequestCredit>();
        var responseFindAssign = await client.GetFromJsonAsync<ERequestCredit>($"/api/v1/solicitudes/{requestCredit.Id}");
        Assert.IsTrue(responseFindAssign.Id == requestCredit.Id);
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
                await context.Vehicles.AddAsync(VehicleMother.Creta2018());
                await context.Agents.AddAsync(AgentMother.Cesar());
                await context.RequestCredit.AddAsync(RequestCreditMother.CreditRequest1Registry());
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
       
        
        var response = await client.PutAsync($"/api/v1/solicitudes/despachar/1",null);
        var result = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        var responseFindRequest = await client.GetFromJsonAsync<ERequestCredit>($"/api/v1/solicitudes/1");
        Assert.IsTrue(responseFindRequest.CreditStatus == (int)CreditStatus.Dispached);
    }
    
    [Test]
    public async Task CreateTwoSameDay_ReturnBadRequest()
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
                await context.Patios.AddAsync(PatioMother.Patio2ToCreate());
                await context.Vehicles.AddAsync(VehicleMother.Creta2018());
                await context.Vehicles.AddAsync(VehicleMother.Tucson());
                await context.Agents.AddAsync(AgentMother.Cesar());
                await context.RequestCredit.AddAsync(RequestCreditMother.CreditRequest1Registry());
                await context.SaveChangesAsync();
            }
        }
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync<ERequestCredit>("/api/v1/solicitudes", RequestCreditMother.CreditRequest2SameDateCredit1());
        
        var result = await response.Content.ReadAsStringAsync();
        
        
        Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
    }
}