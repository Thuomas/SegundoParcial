using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SegundoParcial.Data;
using SegundoParcial.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EquipoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EquipoContext") ?? throw new InvalidOperationException("Connection string 'EquipoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IDepositoService, DepositoService>();
builder.Services.AddScoped<IEquipoService, EquipoService>();

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
