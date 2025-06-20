using ClientsManagement_Api.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientsManagement_Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ContatoModel> Contatos { get; set; }
    public DbSet<EnderecoModel> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ClienteModel>()
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cliente)
            .HasForeignKey<EnderecoModel>(e => e.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClienteModel>()
            .HasOne(c => c.Contato)
            .WithOne(ct => ct.Cliente)
            .HasForeignKey<ContatoModel>(ct => ct.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}