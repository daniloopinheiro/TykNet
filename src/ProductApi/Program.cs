var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.UseHealthChecks("/health");

// In-memory data store (para demonstração)
var products = new List<Product>
{
    new Product { Id = 1, Name = "Notebook", Price = 3500.00m, Description = "Notebook gamer de alta performance" },
    new Product { Id = 2, Name = "Mouse", Price = 120.00m, Description = "Mouse óptico sem fio" },
    new Product { Id = 3, Name = "Teclado", Price = 250.00m, Description = "Teclado mecânico RGB" },
    new Product { Id = 4, Name = "Monitor", Price = 1200.00m, Description = "Monitor 27 polegadas 4K" }
};

// Endpoints
app.MapGet("/products", () =>
{
    app.Logger.LogInformation("Listando todos os produtos");
    return Results.Ok(products);
})
.WithName("GetProducts")
.WithTags("Products")
.Produces<List<Product>>(StatusCodes.Status200OK);

app.MapGet("/products/{id:int}", (int id) =>
{
    app.Logger.LogInformation("Buscando produto com ID: {ProductId}", id);
    
    var product = products.FirstOrDefault(p => p.Id == id);
    
    if (product == null)
    {
        app.Logger.LogWarning("Produto com ID {ProductId} não encontrado", id);
        return Results.NotFound(new { message = $"Produto com ID {id} não encontrado" });
    }
    
    return Results.Ok(product);
})
.WithName("GetProductById")
.WithTags("Products")
.Produces<Product>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapPost("/products", (CreateProductRequest request) =>
{
    app.Logger.LogInformation("Criando novo produto: {ProductName}", request.Name);
    
    if (string.IsNullOrWhiteSpace(request.Name) || request.Price <= 0)
    {
        return Results.BadRequest(new { message = "Nome e preço válidos são obrigatórios" });
    }
    
    var newProduct = new Product
    {
        Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1,
        Name = request.Name,
        Price = request.Price,
        Description = request.Description
    };
    
    products.Add(newProduct);
    
    app.Logger.LogInformation("Produto criado com sucesso. ID: {ProductId}", newProduct.Id);
    return Results.Created($"/products/{newProduct.Id}", newProduct);
})
.WithName("CreateProduct")
.WithTags("Products")
.Produces<Product>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

app.MapDelete("/products/{id:int}", (int id) =>
{
    app.Logger.LogInformation("Removendo produto com ID: {ProductId}", id);
    
    var product = products.FirstOrDefault(p => p.Id == id);
    
    if (product == null)
    {
        app.Logger.LogWarning("Produto com ID {ProductId} não encontrado", id);
        return Results.NotFound(new { message = $"Produto com ID {id} não encontrado" });
    }
    
    products.Remove(product);
    app.Logger.LogInformation("Produto removido com sucesso. ID: {ProductId}", id);
    return Results.NoContent();
})
.WithName("DeleteProduct")
.WithTags("Products")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/", () => Results.Ok(new { 
    service = "ProductApi", 
    version = "1.0.0",
    status = "running",
    endpoints = new[] { "/products", "/health", "/swagger" }
}))
.WithName("Root")
.WithTags("Info");

app.Run();

// Models
record Product
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string? Description { get; init; }
}

record CreateProductRequest
{
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string? Description { get; init; }
}
