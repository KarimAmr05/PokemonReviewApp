namespace PokemonReviewApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Registers Swashbuckle generator
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
        }
    }
}