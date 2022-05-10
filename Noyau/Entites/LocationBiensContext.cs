using Microsoft.EntityFrameworkCore;

namespace Noyau
{
    public partial class LocationBiensContext : DbContext
    {
        public LocationBiensContext() 
        {
        }
        public LocationBiensContext(DbContextOptions<LocationBiensContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LocationBien;Trusted_Connection=True;");
        }

        public virtual DbSet<Bien> Biens { get; set; }
        public virtual DbSet<BienPropriete> BienProprietes { get; set; }
        public virtual DbSet<Commentaire> Commentaires { get; set; }
        public virtual DbSet<Internaute> Internautes { get; set; }
        public virtual DbSet<Proprietaire> Proprietaires { get; set; }
        public virtual DbSet<Propriete> Proprietes { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<TypeBien> TypeBiens { get; set; }


    }
}
