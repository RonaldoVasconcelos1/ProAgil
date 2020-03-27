using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base (options)
        {
        }
              public DbSet<Evento> Eventos {get; set;}
              public DbSet<Palestrante> Palestrantes {get; set;}
              public DbSet<PalestranteEvento> palestranteEventos {get; set;}
              public DbSet<RedeSocial> RedeSociais {get; set;}
              public DbSet<Lote> Lotes {get; set;}

                //esse metodo esta falando para o entity que o evento e palestranteID são primary key
              protected override void OnModelCreating(ModelBuilder modelBuilder){
                  modelBuilder.Entity<PalestranteEvento>()
                  .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
              }

    }
}
