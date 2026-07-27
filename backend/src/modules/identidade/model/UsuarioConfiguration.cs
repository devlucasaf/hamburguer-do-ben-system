using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburguerDoBenSystem.Backend.src.modules.identidade.model;

// --- USUARIOCONFIGURATION: CONFIGURACAO FLUENT DA ENTIDADE USUARIO ---
// --- CARREGADA AUTOMATICAMENTE PELO AppDbContext.OnModelCreating VIA ApplyConfigurationsFromAssembly ---
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(usuario => usuario.Id);

        builder.HasIndex(usuario => usuario.Email)
            .IsUnique()
            .HasDatabaseName("idxUsuarioEmail");

        builder.HasIndex(usuario => usuario.Matricula)
            .IsUnique()
            .HasDatabaseName("idxUsuarioMatricula");
        
        builder.HasIndex(usuario => usuario.Cpf)
            .HasDatabaseName("idxUsuarioCpf");

        builder.HasIndex(usuario => usuario.Cargo)
            .HasDatabaseName("idxUsuarioCargo");
    }
}

