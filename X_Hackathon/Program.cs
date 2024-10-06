using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using X_Hackathon.Components;
using X_Hackathon.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connString = Environment.GetEnvironmentVariable("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(connString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
