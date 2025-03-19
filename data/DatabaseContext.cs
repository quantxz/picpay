using Microsoft.EntityFrameworkCore;
using Transference.Model;
using Usuarios.Model;

namespace Api.Context.Database;

public class DatabaseContext : DbContext {
    public DbSet<UsuariosModel> Usuarios { get; set; }
    public DbSet<TransferenceModel> Transferences { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=game.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}