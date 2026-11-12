
using Microsoft.EntityFrameworkCore;
using TransportIn.Components;
using TransportIn.Data;
using TransportIn.Services;

var builder = WebApplication.CreateBuilder(args);

// Підключення PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Реєстрація компонентів
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Реєстрація сервісів
builder.Services.AddScoped<TransportIn.Services.AuthService>();
builder.Services.AddSingleton<EmergencyService>();
builder.Services.AddSingleton<FleetService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IOrderService>(sp =>
    sp.GetRequiredService<OrderService>());
builder.Services.AddScoped<TransportIn.Services.ExpertRulesService>();
builder.Services.AddScoped<TransportIn.Services.EmployeeService>();

builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Налаштування HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
