using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApp.Models
{
    public partial class s16491Context : DbContext
    {
        public s16491Context()
        {
        }

        public s16491Context(DbContextOptions<s16491Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaCala> PizzaCala { get; set; }
        public virtual DbSet<PizzaCustom> PizzaCustom { get; set; }
        public virtual DbSet<PizzaMenu> PizzaMenu { get; set; }
        public virtual DbSet<RodzajCiasta> RodzajCiasta { get; set; }
        public virtual DbSet<Rozmiar> Rozmiar { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16491;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("Admin_pk");

                entity.Property(e => e.IdAdmin).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("IdPizza");

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Sos");
            });

            modelBuilder.Entity<PizzaCala>(entity =>
            {
                entity.HasKey(e => e.IdPizzaCala)
                    .HasName("Pizza_Cala_pk");

                entity.ToTable("Pizza_Cala");

                entity.Property(e => e.IdPizzaCala)
                    .HasColumnName("IdPizza_Cala")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.IdRodzajCiasta).HasColumnName("IdRodzaj_Ciasta");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaCala)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Cala_Pizza");

                entity.HasOne(d => d.IdRodzajCiastaNavigation)
                    .WithMany(p => p.PizzaCala)
                    .HasForeignKey(d => d.IdRodzajCiasta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Cala_Rodzaj_ciasta");

                entity.HasOne(d => d.IdRozmiarNavigation)
                    .WithMany(p => p.PizzaCala)
                    .HasForeignKey(d => d.IdRozmiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Cala_Rozmiar");
            });

            modelBuilder.Entity<PizzaCustom>(entity =>
            {
                entity.HasKey(e => e.IdPizzaCala)
                    .HasName("Pizza_custom_pk");

                entity.ToTable("Pizza_custom");

                entity.Property(e => e.IdPizzaCala)
                    .HasColumnName("IdPizza_Cala")
                    .ValueGeneratedNever();

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_IdSkladnik");

                entity.Property(e => e.SosIdSos).HasColumnName("Sos_IdSos");

                entity.HasOne(d => d.IdPizzaCalaNavigation)
                    .WithOne(p => p.PizzaCustom)
                    .HasForeignKey<PizzaCustom>(d => d.IdPizzaCala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_10_Pizza_Cala");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.PizzaCustom)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_custom_Skladnik");

                entity.HasOne(d => d.SosIdSosNavigation)
                    .WithMany(p => p.PizzaCustom)
                    .HasForeignKey(d => d.SosIdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_custom_Sos");
            });

            modelBuilder.Entity<PizzaMenu>(entity =>
            {
                entity.HasKey(e => e.PizzaIdPizza)
                    .HasName("Pizza_menu_pk");

                entity.ToTable("Pizza_menu");

                entity.Property(e => e.PizzaIdPizza)
                    .HasColumnName("Pizza_IdPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_IdSkladnik");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithOne(p => p.PizzaMenu)
                    .HasForeignKey<PizzaMenu>(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_9_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.PizzaMenu)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_menu_Skladnik");
            });

            modelBuilder.Entity<RodzajCiasta>(entity =>
            {
                entity.HasKey(e => e.IdRodzajCiasta)
                    .HasName("Rodzaj_ciasta_pk");

                entity.ToTable("Rodzaj_ciasta");

                entity.Property(e => e.IdRodzajCiasta)
                    .HasColumnName("IdRodzaj_Ciasta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Rodzaj)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rozmiar>(entity =>
            {
                entity.HasKey(e => e.IdRozmiar)
                    .HasName("Rozmiar_pk");

                entity.Property(e => e.IdRozmiar).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Rozmiar1)
                    .IsRequired()
                    .HasColumnName("Rozmiar")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Skladnik1)
                    .IsRequired()
                    .HasColumnName("Skladnik")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.HasKey(e => e.IdSos)
                    .HasName("Sos_pk");

                entity.Property(e => e.IdSos).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Sos1)
                    .IsRequired()
                    .HasColumnName("Sos")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.CzasDostawy)
                    .HasColumnName("czas_Dostawy")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("data_Zamowienia")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.KosztCalkowity)
                    .HasColumnName("Koszt_Calkowity")
                    .HasColumnType("money");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaCalaIdPizzaCala).HasColumnName("Pizza_Cala_IdPizza_Cala");

                entity.HasOne(d => d.PizzaCalaIdPizzaCalaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PizzaCalaIdPizzaCala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Cala");
            });
        }
    }
}
