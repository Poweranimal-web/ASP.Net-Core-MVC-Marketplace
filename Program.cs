using Microsoft.Extensions.FileProviders;
using Marketplace.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options=>{
    options.LoginPath = "/Home/SignUp";
});
var app = builder.Build();
// using (MarketPlaceDbContext context = new  MarketPlaceDbContext()){        
//     context.CreateRole();
//     context.CreateInitial();
//     Console.WriteLine("Created data");           
// }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

}
app.UseStaticFiles(new StaticFileOptions
 {
     FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "static")),
     RequestPath = "/StaticFiles"
 });

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
