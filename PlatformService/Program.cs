using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options=>
options.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<PlatformService.Data.IPlatformRepo ,PlatformService.Data.PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient,HttpCommandDataClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c=>
c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo {Title="PlatformService",Version="v1"}));

var app = builder.Build();

Console.WriteLine($"---> CommandService Endpoint {builder.Configuration["CommandService"]}");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","PlatformsService v1"));
    

   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);
app.Run();
