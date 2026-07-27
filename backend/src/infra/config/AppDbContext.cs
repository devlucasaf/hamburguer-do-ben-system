using HamburguerDoBenSystem.Backend.src.entity;
using HamburguerDoBenSystem.Backend.src.modules.identidade.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HamburguerDoBenSystem.Backend.src.infra.config;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    
    // --- RECEBE AS OPÇÕES DE CONFIGURAÇÃO DO EF ---
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // --- CONFIGURAÇÕES GLOBAIS DE ENTIDADES ---
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    // --- OVERRIDE PARA PREENCHER AUDITORIA AUTOMATICAMENTE ---
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AplicarAuditoria();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    // --- OVERRIDE SINCRONO ---
    public override int SaveChanges()
    {
        AplicarAuditoria();
        return base.SaveChanges();
    }

    // --- PERCORRE AS ENTIDADES RASTREADAS E SETA CREATEDAT/UPDATEDAT ---
    private void AplicarAuditoria()
    {
        DateTime dataHoraAtual = DateTime.UtcNow;

        IEnumerable<EntityEntry<AuditEntity>> entradas = ChangeTracker
            .Entries<AuditEntity>()
            .Where(entrada => entrada.State == EntityState.Added || entrada.State == EntityState.Modified);

        foreach (EntityEntry<AuditEntity> entrada in entradas)
        {
            if (entrada.State == EntityState.Added)
            {
                entrada.Entity.CreatedAt = dataHoraAtual;
                entrada.Entity.UpdatedAt = null;
            }
            else if (entrada.State == EntityState.Modified)
            {
                entrada.Entity.UpdatedAt = dataHoraAtual;
                entrada.Property(nameof(AuditEntity.CreatedAt)).IsModified = false;
            }
        }
    }
}