using MoodDiaryFierce.Components;
using MoodDiaryFierce.Database;
using MoodDiaryFierce.Services;
using MoodDiaryFierce;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(Constants.AuthScheme)
    .AddCookie(Constants.AuthScheme, options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/access-denied";

        options.Cookie.Name = Constants.AuthToken;
        options.Cookie.MaxAge = Constants.AuthTokenMaxAge;
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Data Source=database.db"));
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<FormAuthenticationService>(); 
builder.Services.AddScoped<UserManagerService>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.MapPost("/signout", async context =>
{
    await context.SignOutAsync(Constants.AuthScheme);
    context.Response.Redirect("/");
});

app.UseHttpsRedirection();
app.UseRouting();
// app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
