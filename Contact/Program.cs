using Application.Services;
using Contact.Hubs;
using Infrastructure.Services;
using System.Diagnostics.Contracts;

var builder = WebApplication.CreateBuilder(args);
InfrastractureRegister.AddServices(builder);
ApplicationRegister.AddServices(builder);

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.MapHub<ContractHub>("/ContractHub");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
