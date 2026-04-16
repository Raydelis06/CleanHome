using CleanHome.Auth;
using CleanHome.Components;
using CleanHome.DAL;
using CleanHome.Models;
using CleanHome.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//inyecta contexto
builder.Services.AddDbContextFactory<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr")));

//servicios identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.SignIn.RequireConfirmedEmail = true;
})
.AddEntityFrameworkStores<Contexto>()
.AddRoles<IdentityRole>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

builder.Services.AddScoped<IEmailSender, EmailSender>();

// Asegúrate que Identity requiera email confirmado
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
});

//inyecta servicios del sistema
builder.Services.AddScoped<OrdenCompraService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<ProveedorService>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<ServicioService>();
builder.Services.AddScoped<PropiedadService>();
builder.Services.AddScoped<TiposPropiedadService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<SolicitudService>();

//Inyecta bootstrap
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();  

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/", (HttpContext context) =>
{
    if (!context.User.Identity?.IsAuthenticated ?? true)
    {
        return Results.Redirect("/Account/Login");
    }
    return Results.Redirect("/Dashboard"); 
});

app.Run();

app.Run();
