using ProductInventoryAPI.Models.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", () => {
    var products = new List<Product>
    {
        new Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 10.0m },
        new Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 20.0m },
        new Product { Id = Guid.NewGuid(), Name = "Product 3", Price = 30.0m }
    };
    return products;
});

app.Run();
