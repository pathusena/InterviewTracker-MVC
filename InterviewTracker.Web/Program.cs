using Microsoft.EntityFrameworkCore;
using InterviewTracker.DataAccess;
using InterviewTracker.DataAccess.Interface;
using InterviewTracker.DataAccess.Data;
using InterviewTracker.BusinessLogic;
using InterviewTracker.BusinessLogic.Interface;
using InterviewTracker.BusinessLogic.Facades;
using InterviewTracker.BusinessLogic.Interfaces;
using Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
    option.LoginPath = builder.Configuration["Login:Path"];
    option.ExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToDouble(builder.Configuration["Login:ExpireTimeSpan"]));
});

builder.Services.AddDbContext<InterviewTrackerDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

// Register the services/business logics
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyBusinessLogic, CompanyBusinessLogic>();
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<IInterviewBusinessLogic, InterviewBusinessLogic>();
builder.Services.AddScoped<ICompanyInterviewFacade, CompanyInterviewFacade>();

// Register Logger for error/message logging
builder.Services.AddSingleton<ILoggerBusinessLogic, LoggerBusinesssLogic>();

// Register the facades
builder.Services.AddScoped<CompanyInterviewFacade>();

var errorLogFilePath = builder.Configuration["Logging:File:ErrorPath"];
var messageLogFilePath = builder.Configuration["Logging:File:MessagePath"];

var logger = new LoggerConfiguration()
    .WriteTo.Logger(lc => lc
        .WriteTo.File(errorLogFilePath)
        .MinimumLevel.Error())
    .WriteTo.Logger(lc => lc
        .WriteTo.File(messageLogFilePath)
        .MinimumLevel.Information())
    .CreateLogger();

builder.Logging.AddSerilog(logger);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Index}/{id?}");

app.Run();
