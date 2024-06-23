using ClassADO.Repository;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGeneralRepository<Customer>, GeneralRepository<Customer>>();

builder.Services.AddSingleton(new DatabaseOrm("Customers"));
builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseInMemoryDatabase("123");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
