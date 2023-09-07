using Baltazar.Data;
using Baltazar.Data.Contracts;
using Baltazar.Data.Repositories;
using Baltazar.Domain.Contracts;
using Baltazar.Domain.Services;
using Baltazar.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BaltazarDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<DataProtectionTokenProviderOptions>(options => {
    options.TokenLifespan = TimeSpan.FromHours(1);
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = true;
})
    .AddEntityFrameworkStores<BaltazarDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppUserManagerRepository, AppUserManagerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

