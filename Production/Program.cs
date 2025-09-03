using Production;
using Production.Components;
using Services;
using Microsoft.AspNetCore.StaticFiles;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<Service>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    return new Service(httpClient);
});
builder.Services.AddSingleton<IBIZ, BIZ>();


builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options =>
    {
        options.DetailedErrors = true;
    });

builder.Services.AddSignalR(options =>
{
    // Increase maximum message size limit to 10 MB (for example)
    options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10 MB
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/localimage/{filename}", (string filename) =>
{
    var filePath = Path.Combine($@"{Environment.GetEnvironmentVariable("OneDrive")}\PolyLoopImg", filename);

    if (!System.IO.File.Exists(filePath))
        return Results.NotFound();

    var provider = new FileExtensionContentTypeProvider();
    if (!provider.TryGetContentType(filePath, out var contentType))
    {
        contentType = "application/octet-stream"; // fallback
    }

    return Results.File(filePath, contentType);
});


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
