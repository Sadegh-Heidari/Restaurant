using Acc.Bootstraper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resturan.Infrastructure.EFCORE6.Context;
using Resturan.Infrastructure.Service;
using Resturan.Infrastructure.Tools.Tools;
using Resturan.Presentation.Filters;
using Resturan.Presentation.Middelware;
using Resturan.Presentation.Tools;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
var ConnectionStrign = builder.Configuration["ConnectionString"];
StripPayment.SecretKey = builder.Configuration.GetSection("Strip:SecretKey").Get<string>();
StripPayment.PublishableKey = builder.Configuration.GetSection("Strip:PublishKey").Get<string>();
builder.Services.Configure<StripPayment>(builder.Configuration.GetSection("Strip"));
builder.Services.AddService(ConnectionStrign);
builder.Services.AccService(ConnectionStrign, "/Reg/Login", "/Errors/AccessDenied/Access");
builder.Services.AddScoped<CartShopCount>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//builder.Services.AddAccountServices(builder.Configuration.GetConnectionString("sql"));
var app = builder.Build();
app.Services.CreatDataBase();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.MapGet("/", async (context) =>
{
    context.Response.Redirect("/Customer/Home");
});
app.UseStaticFiles();

app.UseErrorNotFound();
app.UseAuthentication();
app.UseCheckIpClient();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.UseCsp(option =>
{
    option.ScriptSources(x =>
        x.Self().CustomSources(
            "cdn.tiny.cloud", "cdn.jsdelivr.net", "polyfill.io", "js.stripe.com"));
    
});

app.MapRazorPages();
app.MapControllers();

app.Run();
