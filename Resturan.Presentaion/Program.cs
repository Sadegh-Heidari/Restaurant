using Microsoft.EntityFrameworkCore;
using Resturan.Infrastructure.EFCORE6.Context;
using Resturan.Infrastructure.Service;
using Resturan.Presentation.Filters;
using Resturan.Presentation.Middelware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(op =>
{
    op.AddPolicy("my", x =>
    {
        x.AllowAnyOrigin();
    });
});
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
//app.UseCors("my");
app.UseErrorNotFound();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();
app.MapControllers();
app.Run();
