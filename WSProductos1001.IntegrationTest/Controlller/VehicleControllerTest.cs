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
        [Test]
        public async Task CreateVehicle_ReturnVehicle()
        {
            await using var app = new WSProductsApiApplication();
            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var context = provider.GetRequiredService<CreditContext>())
                {
                    await context.Database.EnsureCreatedAsync();
                    await context.Brands.AddAsync(new EBrand { Name = "Hyndai" });
                    await context.SaveChangesAsync();
                }
            }
            var client = app.CreateClient();
            var response = await client.PostAsJsonAsync<EVehicle>("/api/v1/vehiculos", VehicleMother.Creta2018());
            var vehicle = await response.Content.ReadFromJsonAsync<EVehicle>();
            var responseFindVehicle = await client.GetFromJsonAsync<EVehicle>($"/api/v1/vehiculos/{vehicle.Id}");
            Assert.IsTrue(responseFindVehicle.Id == vehicle.Id);
        }
        [Test]
        public async Task CreateVehicle_NoExistsBrand_ReturnBadRequest()
        {
            await using var app = new WSProductsApiApplication();
            var client = app.CreateClient();
            var response = await client.PostAsJsonAsync<EVehicle>("/api/v1/vehiculos", VehicleMother.Creta2018());
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }
        [Test]
        public async Task GetById_ReturnNoContent()
        {
            await using var app = new WSProductsApiApplication();
           
            var client = app.CreateClient();
            var response = await client.GetAsync($"/api/v1/vehiculos/1");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
        
        [Test]
        public async Task UpdateVehicle_ReturnNoContent()
        {
            await using var app = new WSProductsApiApplication();
            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var context = provider.GetRequiredService<CreditContext>())
                {
                    await context.Database.EnsureCreatedAsync();
                    await context.Brands.AddAsync(new EBrand { Name = "Hyndai" });
                    await context.Vehicles.AddAsync(VehicleMother.Creta2018());
                    await context.SaveChangesAsync();
                }
            }
            var client = app.CreateClient();
            var cretaUptate = VehicleMother.Creta2018();
            cretaUptate.Year = 2020;
            var response = await client.PutAsJsonAsync<EVehicle>("/api/v1/vehiculos/1", cretaUptate);
            
            var responseFindVehicle = await client.GetFromJsonAsync<EVehicle>($"/api/v1/vehiculos/1");
            Assert.IsTrue(cretaUptate.Year == responseFindVehicle.Year);
        }

    }
}
