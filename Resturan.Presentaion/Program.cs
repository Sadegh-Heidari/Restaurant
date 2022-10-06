using Microsoft.EntityFrameworkCore;
using Resturan.Infrastructure.EFCORE6.Context;
using Resturan.Infrastructure.Service;
using Resturan.Presentation.Filters;
using Resturan.Presentation.Middelware;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddService(builder.Configuration.GetConnectionString("sql"));

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

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.UseCsp(option =>
{
    option.ScriptSources(d => d.Self().CustomSources("https://cdn.tiny.cloud/")).ScriptSources(x=>x.UnsafeInline());
});
app.MapRazorPages();
app.MapControllers();
app.Run();
