using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async (DataContext db) => {
    return await db.Products.ToListAsync();
});

app.Run();
