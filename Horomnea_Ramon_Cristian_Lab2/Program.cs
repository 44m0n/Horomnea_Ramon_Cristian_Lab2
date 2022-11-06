using Horomnea_Ramon_Cristian_Lab2.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Horomnea_Ramon_Cristian_Lab2Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Horomnea_Ramon_Cristian_Lab2Context") ??
                      throw new InvalidOperationException(
                          "Connection string 'Horomnea_Ramon_Cristian_Lab2Context' not found.")));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();