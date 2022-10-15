using Acc.Bootstraper;
using Microsoft.EntityFrameworkCore;
using Resturan.Infrastructure.EFCORE6.Context;
using Resturan.Infrastructure.Service;
using Resturan.Presentation.Filters;
using Resturan.Presentation.Middelware;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages(op =>
{
    op.Conventions.AuthorizeAreaFolder("Admin", "/","AccessArea");
});
var ConnectionStrign = builder.Configuration["ConnectionString"];
builder.Services.AddService(ConnectionStrign);
builder.Services.AccService(ConnectionStrign, "/Reg/Login", "/Errors/AccessDenied/Access");
builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("AccessArea", x=>x.RequireRole("Admin"));
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
    context.Response.Redirect("/Customer");
});

app.UseErrorNotFound();
app.UseStaticFiles();
app.UseAuthentication();
app.UseCheckIpClient();
app.UseRouting();

app.UseAuthorization();

app.UseCsp(option =>
{
    option.ScriptSources(d => d.Self().CustomSources("https://cdn.tiny.cloud/")).ScriptSources(x => x.UnsafeInline());
});
app.MapRazorPages();
app.MapControllers();
app.Run();
