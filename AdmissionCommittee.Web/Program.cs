using AdmissionCommittee.Storage.Sql;
using AdmissionCommittee.Storage.Contracts;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.BL.Contracts;
using AdmissionCommittee.BL;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();
Log.Logger = logger;

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(logger));

builder.Services.AddScoped<IStorage<Entrant>, AdmissionCommitteeStorage>();
builder.Services.AddScoped<IEntrantManager, EntrantManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=Entrants}/{action=Index}/{id?}");

app.Run();
