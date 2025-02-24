using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CareCenterApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Load MongoDB configuration
var mongoSettings = builder.Configuration.GetSection("MongoDB");
var mongoConnectionString = mongoSettings["ConnectionString"];
var databaseName = mongoSettings["DatabaseName"];

// Configure MongoDB
var mongoClient = new MongoClient(mongoConnectionString);
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton<IMongoDatabase>(mongoClient.GetDatabase(databaseName));

// Register services
builder.Services.AddSingleton<ICareCenterService, CareCenterService>();
builder.Services.AddSingleton<ILogin, Login>();



// Register controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();