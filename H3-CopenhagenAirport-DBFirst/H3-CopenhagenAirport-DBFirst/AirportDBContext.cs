using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace H3_CopenhagenAirport_DBFirst
{
    public partial class AirportDBContext : DbContext
    {
        public AirportDBContext()
        {
        }

        public AirportDBContext(DbContextOptions<AirportDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightOperator> FlightOperator { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Proute> Proute { get; set; }
        public virtual DbSet<ProuteOperator> ProuteOperator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AirportDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.Aiata)
                    .HasName("PK__Airport__19DAA9B4E74FDEE8");

                entity.Property(e => e.Aiata)
                    .HasColumnName("AIATA")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightOperator>(entity =>
            {
                entity.HasKey(e => new { e.FlightId, e.OperatorId, e.Liftoff });

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightOperator)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FlightOpe__Fligh__4C6B5938");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.FlightOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FlightOpe__Opera__4B7734FF");
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proute>(entity =>
            {
                entity.ToTable("PRoute");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DestinationNavigation)
                    .WithMany(p => p.ProuteDestinationNavigation)
                    .HasForeignKey(d => d.Destination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRoute__Destinat__489AC854");

                entity.HasOne(d => d.OriginNavigation)
                    .WithMany(p => p.ProuteOriginNavigation)
                    .HasForeignKey(d => d.Origin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRoute__Origin__47A6A41B");
            });

            modelBuilder.Entity<ProuteOperator>(entity =>
            {
                entity.HasKey(e => new { e.ProuteId, e.OperatorId });

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.ProuteOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProuteOpe__Opera__4A8310C6");

                entity.HasOne(d => d.Proute)
                    .WithMany(p => p.ProuteOperator)
                    .HasForeignKey(d => d.ProuteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProuteOpe__Prout__498EEC8D");
            });
        }
    }
}
