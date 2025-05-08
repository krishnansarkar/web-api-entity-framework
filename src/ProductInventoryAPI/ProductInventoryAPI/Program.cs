using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.Models;
using ProductInventoryAPI.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async (DataContext db) => {
    return await db.Products.ToListAsync();
});

app.MapGet("/products{id}", async (Guid id, DataContext db) => {
    var product = await db.Products.FindAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.MapPost("/products", async (CreateProductDto product, DataContext db) => {
    var newProduct = new Product {
        Id = Guid.NewGuid(),
        Name = product.Name,
        Quantity = product.Quantity,
        Price = product.Price
    };
    db.Products.Add(newProduct);
    await db.SaveChangesAsync();
    return Results.Created($"/products/{newProduct.Id}", newProduct);
});

app.MapPut("/products/{id}", async (Guid id, UpdateProductDto product, DataContext db) => {
    var existingProduct = await db.Products.FindAsync(id);
    if (existingProduct is null) {
        return Results.NotFound();
    }
    existingProduct.Name = product.Name;
    existingProduct.Quantity = product.Quantity;
    existingProduct.Price = product.Price;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPut("/products/{id}/{quantity}", async (Guid id, int quantity, DataContext db) => {
    var product = await db.Products.FindAsync(id);
    if (product is null) {
        return Results.NotFound();
    }
    product.Quantity = quantity;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/products/{id}", async (Guid id, DataContext db) => {
    var product = await db.Products.FindAsync(id);
    if (product is null) {
        return Results.NotFound();
    }
    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
