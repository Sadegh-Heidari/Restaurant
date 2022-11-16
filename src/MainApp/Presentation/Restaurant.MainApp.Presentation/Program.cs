using Restaurant.MainApp.Infrastructure.Tools.Tools;
using Restaurant.MainApp.Presentation.Middelware;
using Restaurant.MainApp.Presentation.Tools;
using Restaurant.UsersApp.Infrastructure.Services;
using Resturan.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<StripPayment>(builder.Configuration.GetSection("StripPayment"));
builder.Services.AddService(builder.Configuration["ConnectionString"]);
builder.Services.AccService(builder.Configuration["ConnectionString"], "/Reg/Login", "/Errors/AccessDenied/Access");
builder.Services.AddScoped<CartShopCount>();

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
app.UseCsp(option =>
{
    option.ScriptSources(x =>
        x.Self().CustomSources(
            "cdn.tiny.cloud", "cdn.jsdelivr.net", "polyfill.io", "js.stripe.com"));
    
});

app.MapRazorPages();
app.MapControllers();

app.Run();
