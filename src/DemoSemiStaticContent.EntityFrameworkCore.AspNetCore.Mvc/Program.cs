using Microsoft.EntityFrameworkCore;
using Olbrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc.Data.EntityFrameworkCore;
using Olbrasoft.SemiStaticContent;
using Olbrasoft.SemiStaticContent.EntityFrameworkCore;
using Olbrasoft.SemiStaticContent.Markdown;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<DemoSemiStaticContentContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoSemiStaticContent"));
});

// Add SemiStaticContent
builder.Services.AddStaticContent()
    .UseMarkdownFormatter() // Use Markdown formatter
    .UseDbStaticContentStore<DemoSemiStaticContentContext>(); // Use DbStaticContentStore


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
