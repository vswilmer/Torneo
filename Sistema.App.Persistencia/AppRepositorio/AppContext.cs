using Microsoft.EntityFrameworkCore;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia
{
    public class AppContext : DbContext
    {

        ///Cambio de nombre de atributos ///
        public DbSet<Arbitro> Arbitros { get; set; }
        public DbSet<DesempenoEquipo> Desempenos { get; set; }
        public DbSet<DirectorTecnico> DirectoresTecnicos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<EstadisticaPartido> EstadisticasPartidos { get; set; }
        public DbSet<Futbolista> Futbolistas { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<statsLocal> statsLocales { get; set; }
        public DbSet<StatsVisitante> StatsVisitantes { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SistemaData");
            }
        }
    }
}