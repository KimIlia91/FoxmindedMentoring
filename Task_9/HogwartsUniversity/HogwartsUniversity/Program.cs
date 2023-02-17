using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HogwartsUniversity.Data;
using HogwartsUniversity.Serviñes.ServiceInterfaces;
using HogwartsUniversity.Serviñes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityContext") 
    ?? throw new InvalidOperationException("Connection string 'UniversityContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
