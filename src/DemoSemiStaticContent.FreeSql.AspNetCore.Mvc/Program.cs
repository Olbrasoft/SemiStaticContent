using FreeSql;
using Olbrasoft.SemiStaticContent;
using Olbrasoft.SemiStaticContent.FreeSql;
using Olbrasoft.SemiStaticContent.Markdown;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add SemiStaticContent
builder.Services.AddStaticContent()
    .UseMarkdownFormatter() // Use Markdown formatter
   .UseSemiStaticContentStoreFreesql(fsb => fsb.UseConnectionString(DataType.SqlServer, builder.Configuration.GetConnectionString("DemoSemiStaticContent"))); // Use FreeSql


//.UseSemiStaticContentStoreFreesql(fsb => fsb.UseConnectionString(DataType.SqlServer, builder.Configuration.GetConnectionString("DemoSemiStaticContent")),
// fs => fs.CodeFirst.ConfigEntity<SemiStaticContentItem>(e => e.Name("SemiStaticContentItems"))); // Use configuration for FreeSql


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
