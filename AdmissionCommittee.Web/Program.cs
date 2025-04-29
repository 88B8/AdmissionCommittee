using AdmissionCommittee.Storage.Sql;
using AdmissionCommittee.Storage.Contracts;
using AdmissionCommittee.BL.Contracts.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IStorage<Entrant>>(provider =>
    new AdmissionCommitteeStorage(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Настройка обработки ошибок и других middleware
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
