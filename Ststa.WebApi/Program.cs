using Ststa.Infrastructure;
using Ststa.Application;
using Ststa.Persistance;
using Ststa.WebApi;

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.ConfigureApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureInfrastructure();
builder.Services.ConfigureWebApi(builder.Configuration);
builder.Services.ConfigurePersistence(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
