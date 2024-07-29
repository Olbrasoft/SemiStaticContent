using DemoSemiStaticContent.AspNetCore.Mvc.Data;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.SemiStaticContent;
using Olbrasoft.SemiStaticContent.Markdown;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DemoDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("StaticContent"));
});

builder.Services.AddStaticContent()
    .UseMarkdownFormatter()
    .UseFileStaticContentStore("./App_Data/Content");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
