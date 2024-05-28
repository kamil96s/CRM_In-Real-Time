using CRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using CRM.Infrastructure.Extensions;
using CRM.Infrastructure.Repositories;
using CRM.Infrastructure.Seeders;
using CRM.Application.Extensions;
using MediatR;
using System.Reflection;
using CRM.Application.Services;
using CRM.Domain.Interfaces;
using System.Net.Mail;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ICRMRepository, CRMRepository>();
builder.Services.AddScoped<EmailCampaignService>();

var smtpHost = builder.Configuration["Smtp:Host"];
var smtpPort = builder.Configuration["Smtp:Port"];
var smtpUsername = builder.Configuration["Smtp:Username"];
var smtpPassword = builder.Configuration["Smtp:Password"];

if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(smtpPort) || string.IsNullOrEmpty(smtpUsername) || string.IsNullOrEmpty(smtpPassword))
{
    throw new ArgumentNullException("One or more SMTP configuration values are missing.");
}

builder.Services.AddSingleton(new SmtpClient
{
    Host = smtpHost,
    Port = int.TryParse(smtpPort, out int port) ? port : 587,
    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
    EnableSsl = true
});

var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<CRMSeeder>();

await seeder.Seed();


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

app.MapRazorPages();
app.Run();