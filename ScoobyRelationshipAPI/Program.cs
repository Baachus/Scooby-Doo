using Microsoft.EntityFrameworkCore;
using ScoobyRelationship.Data;
using ScoobyRelationship.Repository;
using ScoobyRelationshipAPI.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Adds service controllers and sets up enum convertors to strings for JSON.
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ScoobRelationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SandboxConnection")));

builder.Services.AddTransient<IRelationshipRepository, RelationshipRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseItToSeedSqlServer();     //Custom extension method to seed the DB
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
