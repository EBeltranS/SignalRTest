using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebServices.Hubs;

var builder = WebApplication.CreateBuilder(args);

//Allow CORS (Cross-Origin Resource Sharing) to use API from REACT

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://localhost:3000")
                          policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                      });
});



// Add services to the container.

builder.Services.AddControllers();

//Inyeccion de dependencias
builder.Services.AddDbContext<SignalRdemoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnectionString"));
});
builder.Services.AddScoped<DemoRepository, DemoRepository>();
builder.Services.AddScoped<SignalRdemoContext, SignalRdemoContext>();
builder.Configuration.GetConnectionString("DemoConnectionString");

//Agregando servicio de signalR
builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

//Agregando endpoint para conectarse SignalR
app.UseEndpoints(endpoints =>
    {
        endpoints.MapHub<MyHub>("/myhub");
    });

app.Run();
