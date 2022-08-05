using System.Net.Http.Json;
using WSProductos1001.Entities;

namespace WSProductos1001.IntegrationTest.Controlller;

public class PatioControllerTest
{

    [Test]
    public async Task GetAl_ReturnListPatios()
    {
        await using var app = new WSProductsApiApplication();
        var client = app.CreateClient();
        var patios = await client.GetFromJsonAsync<IEnumerable<EPatio>>("/api/v1/patios");
        Assert.IsTrue(patios.Count() > 0);
    }
}