using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp;
using PokemonReviewApp.Repository;
using PokemonReviewApp.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
// Registers Swashbuckle generator
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline. (Swagger Middleware)
if (app.Environment.IsDevelopment())
{
    // Generates /swagger/v1/swagger.json
    app.UseSwagger();

    // Renders the Swagger UI web page using Swashbuckle's generated JSON
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

