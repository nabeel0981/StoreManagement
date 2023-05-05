using Microsoft.EntityFrameworkCore;
using SM.Business.DataServices;
using SM.Business.Interfaces;
using SM.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreManagementDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("connString")));

// Add services to the container.
builder.Services.AddControllersWithViews();


//Adding Custom Configuration
builder.Services.AddScoped<IProductService , ProductService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
