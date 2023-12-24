using Easy_Rent_API.Models.Vehicules;
using Microsoft.EntityFrameworkCore;
namespace Easy_Rent_API.Context
{
    public class EasyRentContext: DbContext 
    {
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<PowerSource>powerSources { get; set; }
        public DbSet<carTypology> carTypologies { get; set; }

        public EasyRentContext(DbContextOptions<EasyRentContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            addCreatedDate(modelBuilder);
        }

        private void addCreatedDate(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();

            foreach (var item in allEntities)
            {
                item.AddProperty("CreationDate", typeof(DateTimeOffset)).SetDefaultValueSql("sysdatetimeoffset()");

            }
        }
    }
}
