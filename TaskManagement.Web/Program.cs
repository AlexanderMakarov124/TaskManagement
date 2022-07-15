using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.DataAccess;
using TaskManagement.UseCases.Issues.GetIssues;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddTransient<IApplicationContext, ApplicationContext>();

builder.Services.AddMediatR(typeof(GetIssuesQuery).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Issue}/{action=Index}/{id?}");

app.Run();
