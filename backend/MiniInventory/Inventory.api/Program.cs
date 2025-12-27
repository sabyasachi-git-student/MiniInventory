using Inventory.Api.Data;
using Inventory.Api.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ CORS (React app)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
        policy
            .WithOrigins(
                "http://localhost:5173",
                "http://localhost:5175"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
    // .AllowCredentials()   // keep OFF unless you use cookies/auth
    );
});

// ✅ EF Core + SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

// ✅ GraphQL (Hot Chocolate)
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

// ✅ Routing first
app.UseRouting();

// ✅ CORS between routing and endpoints
app.UseCors("AllowReact");

// ✅ Apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// ✅ Map GraphQL endpoint
app.MapGraphQL("/graphql");

app.Run();
