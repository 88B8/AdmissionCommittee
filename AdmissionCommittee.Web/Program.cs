using AdmissionCommittee.Storage.Sql;
using AdmissionCommittee.Storage.Contracts;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.BL.Contracts;
using AdmissionCommittee.BL;
using Serilog;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();
Log.Logger = logger;

var microsoftLogger = new SerilogLoggerFactory(logger)
    .CreateLogger(nameof(Program));

builder.Services.AddScoped<IStorage<Entrant>>(provider =>
    new AdmissionCommitteeStorage(connectionString));

builder.Services.AddScoped<IEntrantManager>(provider =>
    new EntrantManager(provider.GetRequiredService<IStorage<Entrant>>(), microsoftLogger));

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
