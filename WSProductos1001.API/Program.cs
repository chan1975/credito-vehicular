using WSProductos1001.API.Filters;
using WSProductos1001.Domain.Extensions.ServicesCollection;
using WSProductos1001.Infrastucture.Extensions.ServiceCollection;
using WSProductos1001.Repository.Extensions.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Domain Services
builder.Services.AddDependencyDomain();
//Repository Services
builder.Services.AddDependencyRepository();
//Infrastucture Contexts
builder.Services.AddDbContexts(builder.Configuration);


builder.Services
    .AddControllers(opt => opt.Filters.Add(new GlobalValidationFilterAttribute()))
    .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
//Insfrastucture Validators
builder.Services.AddValidations();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }