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
var orders = new List<Order>
{
    new Order 
    { 
        Id = 1, 
        UserId = 1, 
        Items = new List<OrderItem>
        {
            new OrderItem { ProductId = 1, Quantity = 1, Price = 3500.00m },
            new OrderItem { ProductId = 2, Quantity = 2, Price = 120.00m }
        },
        Total = 3740.00m,
        Status = "Completed",
        CreatedAt = DateTime.UtcNow.AddDays(-5)
    },
    new Order 
    { 
        Id = 2, 
        UserId = 2, 
        Items = new List<OrderItem>
        {
            new OrderItem { ProductId = 3, Quantity = 1, Price = 250.00m }
        },
        Total = 250.00m,
        Status = "Pending",
        CreatedAt = DateTime.UtcNow.AddDays(-2)
    }
};

// Endpoints
app.MapGet("/orders", () =>
{
    app.Logger.LogInformation("Listando todos os pedidos");
    return Results.Ok(orders);
})
.WithName("GetOrders")
.WithTags("Orders")
.Produces<List<Order>>(StatusCodes.Status200OK);

app.MapGet("/orders/{id:int}", (int id) =>
{
    app.Logger.LogInformation("Buscando pedido com ID: {OrderId}", id);
    
    var order = orders.FirstOrDefault(o => o.Id == id);
    
    if (order == null)
    {
        app.Logger.LogWarning("Pedido com ID {OrderId} não encontrado", id);
        return Results.NotFound(new { message = $"Pedido com ID {id} não encontrado" });
    }
    
    return Results.Ok(order);
})
.WithName("GetOrderById")
.WithTags("Orders")
.Produces<Order>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/orders/user/{userId:int}", (int userId) =>
{
    app.Logger.LogInformation("Buscando pedidos do usuário: {UserId}", userId);
    
    var userOrders = orders.Where(o => o.UserId == userId).ToList();
    
    return Results.Ok(userOrders);
})
.WithName("GetOrdersByUserId")
.WithTags("Orders")
.Produces<List<Order>>(StatusCodes.Status200OK);

app.MapPost("/orders", (CreateOrderRequest request) =>
{
    app.Logger.LogInformation("Criando novo pedido para usuário: {UserId}", request.UserId);
    
    if (request.UserId <= 0)
    {
        return Results.BadRequest(new { message = "UserId deve ser maior que zero" });
    }
    
    if (request.Items == null || !request.Items.Any())
    {
        return Results.BadRequest(new { message = "Pedido deve conter pelo menos um item" });
    }
    
    var total = request.Items.Sum(item => item.Price * item.Quantity);
    
    var newOrder = new Order
    {
        Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1,
        UserId = request.UserId,
        Items = request.Items.Select(item => new OrderItem
        {
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            Price = item.Price
        }).ToList(),
        Total = total,
        Status = "Pending",
        CreatedAt = DateTime.UtcNow
    };
    
    orders.Add(newOrder);
    
    app.Logger.LogInformation("Pedido criado com sucesso. ID: {OrderId}, Total: {Total}", newOrder.Id, newOrder.Total);
    return Results.Created($"/orders/{newOrder.Id}", newOrder);
})
.WithName("CreateOrder")
.WithTags("Orders")
.Produces<Order>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

app.MapPut("/orders/{id:int}/status", (int id, UpdateOrderStatusRequest request) =>
{
    app.Logger.LogInformation("Atualizando status do pedido {OrderId} para {Status}", id, request.Status);
    
    var order = orders.FirstOrDefault(o => o.Id == id);
    
    if (order == null)
    {
        app.Logger.LogWarning("Pedido com ID {OrderId} não encontrado", id);
        return Results.NotFound(new { message = $"Pedido com ID {id} não encontrado" });
    }
    
    var validStatuses = new[] { "Pending", "Processing", "Completed", "Cancelled" };
    if (!validStatuses.Contains(request.Status, StringComparer.OrdinalIgnoreCase))
    {
        return Results.BadRequest(new { message = $"Status inválido. Valores permitidos: {string.Join(", ", validStatuses)}" });
    }
    
    var index = orders.FindIndex(o => o.Id == id);
    orders[index] = order with { Status = request.Status };
    
    app.Logger.LogInformation("Status do pedido atualizado com sucesso. ID: {OrderId}", id);
    return Results.Ok(orders[index]);
})
.WithName("UpdateOrderStatus")
.WithTags("Orders")
.Produces<Order>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound);

app.MapDelete("/orders/{id:int}", (int id) =>
{
    app.Logger.LogInformation("Removendo pedido com ID: {OrderId}", id);
    
    var order = orders.FirstOrDefault(o => o.Id == id);
    
    if (order == null)
    {
        app.Logger.LogWarning("Pedido com ID {OrderId} não encontrado", id);
        return Results.NotFound(new { message = $"Pedido com ID {id} não encontrado" });
    }
    
    orders.Remove(order);
    app.Logger.LogInformation("Pedido removido com sucesso. ID: {OrderId}", id);
    return Results.NoContent();
})
.WithName("DeleteOrder")
.WithTags("Orders")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/", () => Results.Ok(new { 
    service = "OrderApi", 
    version = "1.0.0",
    status = "running",
    endpoints = new[] { "/orders", "/health", "/swagger" }
}))
.WithName("Root")
.WithTags("Info");

app.Run();

// Models
record Order
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public List<OrderItem> Items { get; init; } = new();
    public decimal Total { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}

record OrderItem
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}

record CreateOrderRequest
{
    public int UserId { get; init; }
    public List<CreateOrderItemRequest>? Items { get; init; }
}

record CreateOrderItemRequest
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}

record UpdateOrderStatusRequest
{
    public string Status { get; init; } = string.Empty;
}
