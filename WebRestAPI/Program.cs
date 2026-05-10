using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebRest.EF.Data;
using WebRestAPI.Code;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("WebRestOracleConnection");
builder.Services.AddDbContext<WebRestOracleContext>(options => 
    options.UseOracle(connectionString)
           .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
);

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddFilter("Microsoft", LogLevel.Warning)
           .AddFilter("System", LogLevel.Warning)
           .AddFilter("SampleApp.Program", LogLevel.Debug)
           .AddConsole();
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
}, loggerFactory);

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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