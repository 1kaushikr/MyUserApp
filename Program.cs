using MyUserApp.Models;
using MyUserApp.Services;
using MyUserApp.Interface;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<UserDatabaseSetting>(
    builder.Configuration.GetSection("UserDatabase"));

builder.Services.AddSingleton<UserService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<UserListInterface, UserList>();

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
