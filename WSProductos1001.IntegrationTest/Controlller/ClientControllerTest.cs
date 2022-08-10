using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Infrastucture.Context;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.IntegrationTest.Controlller;

public class ClientControllerTest
{
    private string _currentPath;
    [SetUp]
    public void SetUp()
    {
        _currentPath = Directory.GetCurrentDirectory();
    }
    //test crud client
    
    [Test]
    public async Task UploadIntialClient_ReturnOk()
    {
        string brandFilePath = @"..\..\..\InitialData\initial_client.csv";
        string sFile = Path.Combine(_currentPath, brandFilePath);
        string filePath = Path.GetFullPath(sFile);
            
        var fileStreamContent = new StreamContent(File.OpenRead(filePath));
        using MultipartFormDataContent multipartFormContent = new MultipartFormDataContent();
        multipartFormContent.Add(fileStreamContent, name: "clients", fileName: "initial_client.csv");
            
        await using var app = new WSProductsApiApplication();
        await AddCatalogContext(app);
        var client = app.CreateClient();
        var response = await client.PostAsync("/api/v1/clientes/carga", multipartFormContent);
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    private async Task AddCatalogContext(WSProductsApiApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using (var context = provider.GetRequiredService<CreditContext>())
            {
                await context.Database.EnsureCreatedAsync();
                await context.MaritalStatuses.AddAsync(new (){Description = "Soltero"});
                await context.MaritalStatuses.AddAsync(new (){Description = "Casado"});
                await context.MaritalStatuses.AddAsync(new (){Description = "Viudo"});
                await context.MaritalStatuses.AddAsync(new (){Description = "Divorciado"});
                await context.MaritalStatuses.AddAsync(new (){Description = "Union Libre"});
                
                await context.SubjectCredits.AddAsync(new (){Description = "No Sujeto de Credito"});
                await context.SubjectCredits.AddAsync(new (){Description = "Sujeto de Credito"});
                await context.SaveChangesAsync();
            }
        }
    }
}