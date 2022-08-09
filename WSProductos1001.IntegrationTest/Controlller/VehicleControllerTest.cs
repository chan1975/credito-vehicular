using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.IntegrationTest.Controlller
{
    internal class VehicleControllerTest
    {
        [Test]
        public async Task GetAllVehicle_ReturnTwo()
        {
            await using var app = new WSProductsApiApplication();
            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var context = provider.GetRequiredService<CreditContext>())
                {
                    await context.Database.EnsureCreatedAsync();
                    await context.Vehicles.AddAsync(VehicleMother.Creta2018());
                    await context.Vehicles.AddAsync(VehicleMother.Sandero2022());
                    await context.SaveChangesAsync();
                }
            }
            var client = app.CreateClient();
            var response = await client.GetFromJsonAsync<IEnumerable<EVehicle>>("/api/v1/vehiculos");
            Assert.IsTrue(response.Count() == 2);
        }
        
    }
}
