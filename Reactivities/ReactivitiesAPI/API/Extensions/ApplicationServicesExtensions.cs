using Persistence;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAppliationServices(this IServiceCollection services, 
            IConfiguration config)
        {
            throw new NotImplementedException();
            /*//DbContext by vip
            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddCors();

            builder.Services.AddMediatR(typeof(List.Handler).Assembly);

            builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context);
            }
            catch (Exception ex)
            {
                //throw;
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }*/

        }
    }
}
