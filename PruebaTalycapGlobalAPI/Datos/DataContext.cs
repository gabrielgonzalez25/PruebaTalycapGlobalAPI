using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTalycapGlobalAPI.Datos
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<LogisticaMaritima> LogisticaMaritima { get; set; }
        public DbSet<LogisticaTerrestre> LogisticaTerrestre { get; set; }
    }
}
