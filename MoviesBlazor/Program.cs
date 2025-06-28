using MoviesBlazor.Clients;
using MoviesBlazor.Components;

var builder = WebApplication.CreateBuilder(args); // Create a builder for the web application.

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var movieAppUrl = builder.Configuration["MovieApiUrl"] ?? throw new Exception ("error ya ngm");

builder.Services.AddHttpClient<MoviesClients>(client => client.BaseAddress = new Uri(movieAppUrl));
builder.Services.AddHttpClient<GenresClients>(client => client.BaseAddress = new Uri(movieAppUrl));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
