using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace H3_Airport_ModelFirst.Models
{
    public partial class H3_Airport_ModelFirstContext : DbContext
    {
        public H3_Airport_ModelFirstContext()
        {
        }

        public H3_Airport_ModelFirstContext(DbContextOptions<H3_Airport_ModelFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=H3_Airport_ModelFirst;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("Airline");

                entity.HasIndex(e => e.Name, "UQ__Airline__737584F6EC37D1A2")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(130);
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("Airport");

                entity.HasIndex(e => e.Iata, "UQ__Airport__82F6AFF4D211D861")
                    .IsUnique();

                entity.Property(e => e.Iata)
                    .HasMaxLength(3)
                    .HasColumnName("IATA");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.ToTable("Plane");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Planes)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Plane__AirlineId__2C3393D0");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("Route");

                entity.HasOne(d => d.FromAirport)
                    .WithMany(p => p.RouteFromAirports)
                    .HasForeignKey(d => d.FromAirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Route__FromAirpo__30F848ED");

                entity.HasOne(d => d.OperatorAirline)
                    .WithMany(p => p.RouteOperatorAirlines)
                    .HasForeignKey(d => d.OperatorAirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Route__PlaneId__2F10007B");

                entity.HasOne(d => d.OwnerAirline)
                    .WithMany(p => p.RouteOwnerAirlines)
                    .HasForeignKey(d => d.OwnerAirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Route__OwnerAirl__300424B4");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.PlaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Route__PlaneId__32E0915F");

                entity.HasOne(d => d.ToAirport)
                    .WithMany(p => p.RouteToAirports)
                    .HasForeignKey(d => d.ToAirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Route__ToAirport__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
