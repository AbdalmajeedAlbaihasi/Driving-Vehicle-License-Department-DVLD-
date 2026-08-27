using Microsoft.EntityFrameworkCore;
using DVLDDataAccess.Entities;
using DVLDDataAccess;
using DVLDBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DVLDContext
builder.Services.AddDbContext<DVLDContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Data Access
builder.Services.AddScoped<clsPeopleDataAccess>();

// Register Business
builder.Services.AddScoped<clsPeopleBusiness>();

builder.Services.AddScoped<clsApplicationsTypeDataAccess>();
builder.Services.AddScoped<clsApplicationsTypeBusiness>();

builder.Services.AddScoped<clsUsersDataAccess>();
builder.Services.AddScoped<clsUsersBusiness>();

builder.Services.AddScoped<clsTestTypeDataAccess>();
builder.Services.AddScoped<clsTestTypeBusiness>();

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