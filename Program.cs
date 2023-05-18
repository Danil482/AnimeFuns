using Microsoft.EntityFrameworkCore;
using AnimeFuns.Models;
using AnimeFuns;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

var adminRole = new IdentityRole("admin");
var userRole = new IdentityRole("user");

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AnimeFunsContextConnection") ?? throw new InvalidOperationException("Connection string 'AnimeFunsContextConnection' not found.");

builder.Services.AddDbContext<AnimeDBContext>(options => 
options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AnimeDBContext>();


//builder.Services.AddIdentity<User,IdentityRole>()
//    .AddEntityFrameworkStores<AnimeDBContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddTransient<IEmailSender>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
