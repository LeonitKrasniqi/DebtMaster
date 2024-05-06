using DebtMaster.Data;
using DebtMaster.Mappings;
using DebtMaster.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DebtDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DebtConnectionString")));

builder.Services.AddScoped<IDebtRepository, DebtRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
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
