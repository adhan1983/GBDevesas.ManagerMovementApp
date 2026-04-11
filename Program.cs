using GBDevesas.ManagerMovementApp.Components;
using GBDevesas.ManagerMovementApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



builder.Services.AddControllers(); // <-- você já tinha, certo

var baseUrl = builder.Configuration["BaseUrl"] ?? "http://localhost:8080";

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();