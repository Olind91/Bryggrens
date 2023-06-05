using Bryggrens.Contexts;
using Bryggrens.Helpers.Repositories;
using Bryggrens.Helpers.Services;
using Bryggrens.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();





builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));


//Services
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<BeerService>();
builder.Services.AddScoped<BeerCategoryService>();



//Repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<BeerCategoriesRepo>();
builder.Services.AddScoped<BeerRepo>();
builder.Services.AddScoped<CategoryRepo>();

//Konfigurerar hur login ska fungera
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/"; ;
    x.AccessDeniedPath = "/AccessDenied";

});



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Error/NotFoundView");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
app.MapFallbackToController("Index", "Error");
