using Microsoft.EntityFrameworkCore;
using Progress.Interfaces;
using Progress.Services;
using Progress.Services.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext,DBContext>();
builder.Services.AddScoped(typeof(IRepository<,>),typeof(Repository<,>));
builder.Services.AddScoped<IMBKDictionary, MBKRepository>();
builder.Services.AddScoped(typeof(IExport<>),typeof(ExportXmlService<>));
builder.Services.AddScoped<PatientManagementService>();
builder.Services.AddScoped<VisitManagementService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/patients/error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Index}/{id?}");

app.Run();
