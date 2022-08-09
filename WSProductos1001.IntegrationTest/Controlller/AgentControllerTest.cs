using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.IntegrationTest.Controlller
{
    public class AgentControllerTest
    {
        private string _currentPath;
        [SetUp]
        public void SetUp()
        {
            _currentPath = Directory.GetCurrentDirectory();
        }
        [Test]
        public async Task GetAllAgent_ReturnNoContent()
        {
            await using var app = new WSProductsApiApplication();
            var client = app.CreateClient();
            var response = await client.GetAsync("api/v1/agentes");
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Test]
        public async Task GetAllAgent_ReturnOk()
        {
            await using var app = new WSProductsApiApplication();
            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var context = provider.GetRequiredService<CreditContext>())
                {
                    await context.Database.EnsureCreatedAsync();
                    await context.Agents.AddAsync(AgentMother.Cesar());
                    await context.SaveChangesAsync();
                }
            }
            var client = app.CreateClient();
            var response = await client.GetFromJsonAsync<IEnumerable<EAgent>>("api/v1/agentes");
            Assert.IsTrue(response.Count() == 1);
        }

        [Test]
        public async Task UploadInitialAgent_ReturnOk()
        {
            string brandFilePath = @"..\..\..\InitialData\initial_agent.csv";
            string sFile = Path.Combine(_currentPath, brandFilePath);
            string filePath = Path.GetFullPath(sFile);
            
            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            using MultipartFormDataContent multipartFormContent = new MultipartFormDataContent();
            multipartFormContent.Add(fileStreamContent, name: "agents", fileName: "initial_agent.csv");
            
            await using var app = new WSProductsApiApplication();
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
            var client = app.CreateClient();
            var response = await client.PostAsync("/api/v1/agentes/carga", multipartFormContent);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
