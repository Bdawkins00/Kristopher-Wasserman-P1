global using Serilog;

using LakeJacksonCyclingBL;
using LakeJacksonCyclingDL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

Log.Logger = new LoggerConfiguration().WriteTo.File("./logs/user.txt").CreateLogger();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IRepository>(repo => new SqlRepository(builder.Configuration.GetConnectionString("Reference2DB")));
/*uilder.Services.AddDbContext<LJCApiIdentityDbContext>(options =>
    options.UseSqlServer("Reference2DB"));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LJCApiIdentityDbContext>();builder.Services.AddScoped<ILakeJacksonBL, LakeJacksonBL>();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
