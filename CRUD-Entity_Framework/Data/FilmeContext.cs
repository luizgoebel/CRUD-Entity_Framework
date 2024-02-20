using CRUD_Entity_Framework.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Entity_Framework.Data;

public class FilmeContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Produtora> Produtoras { get; set; }
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração do relacionamento entre Filme e Produtora
        modelBuilder.Entity<Filme>()
            .HasOne(f => f.Produtora)
            .WithMany(p => p.Filmes)
            .HasForeignKey(f => f.ProdutoraId);
    }
}
