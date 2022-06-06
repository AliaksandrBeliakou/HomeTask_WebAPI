using Microsoft.EntityFrameworkCore;
using WebAPI.HomeTask.NorthwindService.Data;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("NorthwindDb");
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
