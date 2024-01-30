using Microsoft.EntityFrameworkCore;
using StockBytes.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnectionStrings = builder.Configuration.GetConnectionString("constr");
builder.Services.AddDbContext<DatabaseContext>(
    options =>
    {
        options.UseSqlServer(ConnectionStrings);
    }
    );

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
    pattern: "{controller=StockByte}/{action=homePage}/{id?}");

app.Run();
