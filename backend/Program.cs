using HamburguerDoBenSystem.Backend.src.infra.config;
using Microsoft.EntityFrameworkCore;

// --- CRIA O BUILDER DA APLICAÇÃO WEB ---
var builder = WebApplication.CreateBuilder(args);

// --- REGISTRA O DBCONTEXT USANDO A CONNECTION STRING DO APPSETTINGS ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// --- HABILITA CONTROLLERS ---
builder.Services.AddControllers();

// --- DOCUMENTA E TESTA OS ENDPOINTS DA API ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- LIBERA ACESSO PARA OS FRONTENDS LOCAIS ---
const string corsPolicy = "FrontendsLocais";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        policy.WithOrigins(
                "http://localhost:8080",  
                "http://localhost:8081",  
                "http://localhost:8082",  
                "http://localhost:5173"   
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// --- CONSTROI A APLICAÇÃO ---
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// --- REDIRECT AUTOMÁTICO DE HTTP PARA HTTPS ---
app.UseHttpsRedirection();

// --- ATIVA A POLÍTICA DE CORS ---
app.UseCors(corsPolicy);

// --- AUTORIZAÇÃO ---
app.UseAuthorization();

// --- MAPEIA OS CONTROLLERS AUTOMATICAMENTE ---
app.MapControllers();

// --- RETORNA 200 SE A API ESTIVER VIVA ---
app.MapGet("/health", () => Results.Ok(new { status = "ok", timestamp = DateTime.UtcNow }));

// --- INICIA A APLICAÇÃO ---
app.Run();
