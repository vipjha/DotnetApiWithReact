using API.Data;
using API.Middleware;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddExceptionHandler<ExceptionMiddleware>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add by Vipin
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();


var app = builder.Build();

//app.UseMiddleware<ExceptionMiddleware>();

//var scope = app.Services.CreateScope();
//var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
//var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;


try
{
    var context = services.GetRequiredService<StoreContext>();
    context.Database.Migrate();
   // context.Database.Migrate();
    DbInitializer.Initalizer(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
