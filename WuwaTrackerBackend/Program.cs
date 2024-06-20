using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WuwaTrackerBackend.Containers;
using WuwaTrackerBackend.Models;
using WuwaTrackerBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WuwaContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("WuwaContext")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

RegisterRepos(builder);
RegisterLogics(builder);

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

static void RegisterRepos(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IFlowerRepository, FlowerRepository>();
    builder.Services.AddScoped<ITacetCoreRepository, TacetCoreRepository>();
    builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
    builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
}

static void RegisterLogics(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IFlowerContainer, FlowerContainer>();
    builder.Services.AddScoped<ITacetCoreContainer, TacetCoreContainer>();
    builder.Services.AddScoped<IMaterialContainer, MaterialContainer>();
    builder.Services.AddScoped<ICharacterContainer, CharacterContainer>();
}

//TODO: Add all different things here when making it
