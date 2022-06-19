using Microsoft.EntityFrameworkCore;
using WebAPI.HomeTask.NorthwindService.Data;
using WebAPI.HomeTask.NorthwindService.Services.Interfaces;
using WebAPI.HomeTaskMiddleWare;
using WebAPI.HomeTaskRopositories;
using WebAPI.HomeTaskRopositories.Interfaces;
using WebAPI.HomeTaskServices;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("NorthwindDb");
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connection));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var logger = app.Services.GetService<ILoggerFactory>()!.CreateLogger<GlobalErrorHandler>();

app.UseMiddleware<GlobalErrorHandler>(logger);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
