using BestSelling.API.ViewModels;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/best-selling-products", () => new List<Product> {
    new Product("Product A", 12.50m, 100),
    new Product("Product B", 33.99m, 200),
    new Product("Product C", 17.99m, 150),
    new Product("Product D", 23.00m, 50),
    new Product("Product E", 51.49m, 300)
});

app.Run();
