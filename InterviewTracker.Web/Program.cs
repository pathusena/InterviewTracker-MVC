using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InterviewTracker.DataAccess;
using InterviewTracker.DataAccess.Interface;
using InterviewTracker.DataAccess.Data;
using InterviewTracker.BusinessLogic;
using InterviewTracker.BusinessLogic.Interface;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<InterviewTrackerDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

// Register the services/business logics
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyBusinessLogic, CompanyBusinessLogic>();
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<IInterviewBusinessLogic, InterviewBusinessLogic>();

// Register the facades
builder.Services.AddScoped<CompanyInterviewFacade>();


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
