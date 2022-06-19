using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class MyDB : DbContext
    {
        public MyDB() : base("name=cnx") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Chambre>().ToTable("chambres");
            modelBuilder.Entity<Hotel>().ToTable("hotels");
            modelBuilder.Entity<Classe>().ToTable("classes");
            modelBuilder.Entity<Categorie>().ToTable("categories");
            modelBuilder.Entity<Client>().ToTable("clients");
            modelBuilder.Entity<Reserver>().ToTable("reserver");
            modelBuilder.Entity<Prestation>().ToTable("prestations");
            modelBuilder.Entity<Consommation>().ToTable("consommation");
            // -------------------- Hotel has many chambre and chambre has one hotel ------------------------ //
            // -------------------- Hotel has one classe and classe has many hotel -------------------------- //
            modelBuilder.Entity<Hotel>()
            .HasOptional(c => c.Classe)
            .WithMany(h => h.hotels)
            .Map(x => x.MapKey("ClasseId"));
            // --------------------------------------------------------------------------------------------
            modelBuilder.Entity<Chambre>()
           .HasOptional(c => c.Categorie)
           .WithMany(h => h.chambres)
           .Map(x => x.MapKey("CategorieId"));
            // --------------------------------------------------------------------------------------------
            modelBuilder.Entity<Chambre>()
           .HasMany(c => c.reservers)
           .WithRequired(h => h.Chambre)
           .Map(x => x.MapKey("ChambreId")).WillCascadeOnDelete(true);
            // ------------------------------------------------------------------------------------------
            modelBuilder.Entity<Reserver>()
            .HasOptional(c => c.Client)
            .WithMany(h => h.reservers)
            .Map(x => x.MapKey("ClientId"));
            // ------------------------------------------------------------------------------------------
            modelBuilder.Entity<Consommation>()
            .HasOptional(c => c.Reserver)
            .WithMany(h => h.ConsommationList)
            .Map(x => x.MapKey("ReserverId"));
            // ------------------------------------------------------------------------------------------
            // --------------------------------Consomation - Prestation -----------------------------------------------------------
            modelBuilder.Entity<Consommation>()
           .HasOptional(c => c.Prestation)
           .WithMany(h => h.consommations)
           .Map(x => x.MapKey("PrestationId"));
            // -------------------------------- Hotel - Chambre ------------------------------------------------------------
            modelBuilder.Entity<Hotel>()
            .HasMany(c => c.chambres)
            .WithOptional(h => h.Hotel)
            .Map(x => x.MapKey("HotelId"));
            // --------------------------------------------------------------------------------------------


/*            modelBuilder.Entity<Consommation>()
            .HasOptional(c => c.Reserver)
            .WithMany(h => h.ConsommationList)
            .Map(x => x.MapKey("ReserverId"));*/


            /*
                         modelBuilder.Entity<Hotel>()
                        .HasMany(c => c.chambres)
                        .WithOptional(h => h.Hotel)
                        .Map(x => x.MapKey("HotelId"));*/
        }
        // ---------------------------------------------------------------------------------------------

        // 7 Relations 
        // 9 Classes 
        public virtual DbSet<Chambre> Chambres { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reserver> Reservers { get; set; }
        public virtual DbSet<Prestation> Prestations { get; set; }

        public virtual DbSet<Consommation> Consommations { get; set; }

   





    }
}
