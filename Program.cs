using SimpleCRUD_MVC.Data;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_MVC.MapperProfiles;
using SimpleCRUD_MVC.Configurations;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("KeyDatabaseMySQL");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configuration();

builder.Services.AddAutoMapper(
    cfg => cfg.AddProfile<Profiles>());

builder.Services.AddDbContext<SimpleCRUD_MVCContext>(options =>
        options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString)
        )
    );

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
    pattern: "/{controller=Order}/{action=Index}/{id?}");

app.Run();
