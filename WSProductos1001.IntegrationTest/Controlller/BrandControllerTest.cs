using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSProductos1001.IntegrationTest.Controlller
{
    public class BrandControllerTest
    {
        private string _currentPath;
        [SetUp]
        public void SetUp()
        {
            _currentPath = Directory.GetCurrentDirectory();
        }
        [Test]
        public async Task UploadInitialBrands_ReturnOk()
        {

            string brandFilePath = @"..\..\..\InitialData\initial_data_brand.csv";
            string sFile = Path.Combine(_currentPath, brandFilePath);
            string filePath = Path.GetFullPath(sFile);

            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            using MultipartFormDataContent multipartFormContent = new MultipartFormDataContent();
            multipartFormContent.Add(fileStreamContent, name: "brands", fileName: "initial_data_brand.csv");
            

            await using var app = new WSProductsApiApplication();
            var client = app.CreateClient();
            var response = await client.PostAsync("/api/v1/marcas/carga", multipartFormContent);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
        [Test]
        public async Task UploadInitialBrands_ReturnBadRequest()
        {

            string brandFilePath = @"..\..\..\InitialData\initial_duplicate_brand.csv";
            string sFile = Path.Combine(_currentPath, brandFilePath);
            string filePath = Path.GetFullPath(sFile);

            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            using MultipartFormDataContent multipartFormContent = new MultipartFormDataContent();
            multipartFormContent.Add(fileStreamContent, name: "brands", fileName: "initial_data_brand.csv");


            await using var app = new WSProductsApiApplication();
            var client = app.CreateClient();
            var response = await client.PostAsync("/api/v1/marcas/carga", multipartFormContent);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }
    }
}
