using Habit.Core.RepositoryContract;
using Habit.Core.ServiceContract;
using Habit.Repository.Data;
using Habit.Repository.Repository;
using Habit.Services;
using Habit.Services.ServiceContract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReHabit.Api.Helpers;
using ReHabit.Habit.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<twilio>(builder.Configuration.GetSection("Twillo"));
builder.Services.AddTransient<INotificationService, NotificationService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IHabitRepository, HabitRepository>();
builder.Services.AddScoped<ImageUpload>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddIdentity<User, IdentityRole>(op=>
{
    op.Password.RequireDigit = true;
    op.Password.RequireLowercase = true;
    op.Password.RequireNonAlphanumeric = false;
    op.Password.RequireUppercase = true;
    op.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
