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
var users = new List<User>
{
    new User { Id = 1, Name = "João Silva", Email = "joao.silva@email.com", CreatedAt = DateTime.UtcNow.AddDays(-30) },
    new User { Id = 2, Name = "Maria Santos", Email = "maria.santos@email.com", CreatedAt = DateTime.UtcNow.AddDays(-15) },
    new User { Id = 3, Name = "Pedro Oliveira", Email = "pedro.oliveira@email.com", CreatedAt = DateTime.UtcNow.AddDays(-7) }
};

// Endpoints
app.MapGet("/users", () =>
{
    app.Logger.LogInformation("Listando todos os usuários");
    return Results.Ok(users);
})
.WithName("GetUsers")
.WithTags("Users")
.Produces<List<User>>(StatusCodes.Status200OK);

app.MapGet("/users/{id:int}", (int id) =>
{
    app.Logger.LogInformation("Buscando usuário com ID: {UserId}", id);
    
    var user = users.FirstOrDefault(u => u.Id == id);
    
    if (user == null)
    {
        app.Logger.LogWarning("Usuário com ID {UserId} não encontrado", id);
        return Results.NotFound(new { message = $"Usuário com ID {id} não encontrado" });
    }
    
    return Results.Ok(user);
})
.WithName("GetUserById")
.WithTags("Users")
.Produces<User>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapPost("/users", (CreateUserRequest request) =>
{
    app.Logger.LogInformation("Criando novo usuário: {UserEmail}", request.Email);
    
    if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email))
    {
        return Results.BadRequest(new { message = "Nome e email são obrigatórios" });
    }
    
    if (users.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
    {
        app.Logger.LogWarning("Tentativa de criar usuário com email duplicado: {UserEmail}", request.Email);
        return Results.Conflict(new { message = "Email já está em uso" });
    }
    
    var newUser = new User
    {
        Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
        Name = request.Name,
        Email = request.Email,
        CreatedAt = DateTime.UtcNow
    };
    
    users.Add(newUser);
    
    app.Logger.LogInformation("Usuário criado com sucesso. ID: {UserId}", newUser.Id);
    return Results.Created($"/users/{newUser.Id}", newUser);
})
.WithName("CreateUser")
.WithTags("Users")
.Produces<User>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status409Conflict);

app.MapPut("/users/{id:int}", (int id, UpdateUserRequest request) =>
{
    app.Logger.LogInformation("Atualizando usuário com ID: {UserId}", id);
    
    var user = users.FirstOrDefault(u => u.Id == id);
    
    if (user == null)
    {
        app.Logger.LogWarning("Usuário com ID {UserId} não encontrado", id);
        return Results.NotFound(new { message = $"Usuário com ID {id} não encontrado" });
    }
    
    if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email))
    {
        return Results.BadRequest(new { message = "Nome e email são obrigatórios" });
    }
    
    var existingUserWithEmail = users.FirstOrDefault(u => u.Id != id && u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));
    if (existingUserWithEmail != null)
    {
        app.Logger.LogWarning("Tentativa de atualizar usuário com email duplicado: {UserEmail}", request.Email);
        return Results.Conflict(new { message = "Email já está em uso por outro usuário" });
    }
    
    var index = users.FindIndex(u => u.Id == id);
    users[index] = user with { Name = request.Name, Email = request.Email };
    
    app.Logger.LogInformation("Usuário atualizado com sucesso. ID: {UserId}", id);
    return Results.Ok(users[index]);
})
.WithName("UpdateUser")
.WithTags("Users")
.Produces<User>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status409Conflict);

app.MapDelete("/users/{id:int}", (int id) =>
{
    app.Logger.LogInformation("Removendo usuário com ID: {UserId}", id);
    
    var user = users.FirstOrDefault(u => u.Id == id);
    
    if (user == null)
    {
        app.Logger.LogWarning("Usuário com ID {UserId} não encontrado", id);
        return Results.NotFound(new { message = $"Usuário com ID {id} não encontrado" });
    }
    
    users.Remove(user);
    app.Logger.LogInformation("Usuário removido com sucesso. ID: {UserId}", id);
    return Results.NoContent();
})
.WithName("DeleteUser")
.WithTags("Users")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/", () => Results.Ok(new { 
    service = "UserApi", 
    version = "1.0.0",
    status = "running",
    endpoints = new[] { "/users", "/health", "/swagger" }
}))
.WithName("Root")
.WithTags("Info");

app.Run();

// Models
record User
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}

record CreateUserRequest
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}

record UpdateUserRequest
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
