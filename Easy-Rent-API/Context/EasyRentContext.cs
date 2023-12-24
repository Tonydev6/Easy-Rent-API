using Easy_Rent_API.Entities.Vehicules;
using Easy_Rent_API.Models.Vehicules;
using Microsoft.EntityFrameworkCore;
namespace Easy_Rent_API.Context
{
    public class EasyRentContext : DbContext
    {
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<PowerSource> powerSources { get; set; }
        public DbSet<carTypology> carTypologies { get; set; }
        public DbSet<Transmission> transmitions { get; set; }


        public EasyRentContext(DbContextOptions<EasyRentContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            addCreatedDate(modelBuilder);
            initialiseTransmission(modelBuilder);
        }

        private void addCreatedDate(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();

            foreach (var item in allEntities)
            {
                item.AddProperty("CreationDate", typeof(DateTimeOffset)).SetDefaultValueSql("sysdatetimeoffset()");

            }
        }

        private void initialiseTransmission(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = TransmitionEnum.manual, description = nameof(TransmitionEnum.manual) });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = TransmitionEnum.automatic, description = nameof(TransmitionEnum.automatic) });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = TransmitionEnum.semiAutomatic, description = nameof(TransmitionEnum.semiAutomatic) });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = TransmitionEnum.continuoslyVariableTransmission, description = "Continuosly Variable Transmission" });


        }
    }
}
