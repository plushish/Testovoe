using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using System.Data.Common;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("DBConection");
//builder.Services.AddDbContext<DbContext>(Options => Options.UseSqlServer(connString));
builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CompaniesDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CompaniesDbContext>();

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    DbInitializer.Initialize(db);
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

//app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
