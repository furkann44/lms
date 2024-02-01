using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KutuphaneOtomasyonu.Context
{
    public partial class dbKutuphaneContext : DbContext
    {
        public dbKutuphaneContext()
        {
        }

        public dbKutuphaneContext(DbContextOptions<dbKutuphaneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Emanet> Emanet { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kitap> Kitap { get; set; }
        public virtual DbSet<Kutuphane> Kutuphane { get; set; }
        public virtual DbSet<Rapor> Rapor { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yayinevi> Yayinevi { get; set; }
        public virtual DbSet<Yazar> Yazar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=dbKutuphane;Username=postgres;Password=123qwe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.ToTable("adres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adrestarifi)
                    .HasColumnName("adrestarifi")
                    .HasColumnType("character varying");

                entity.Property(e => e.Il)
                    .HasColumnName("il")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ilce)
                    .HasColumnName("ilce")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Emanet>(entity =>
            {
                entity.ToTable("emanet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Kitapid).HasColumnName("kitapid");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("character varying");

                entity.Property(e => e.Uyeid).HasColumnName("uyeid");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Kitap)
                    .WithMany(p => p.Emanet)
                    .HasForeignKey(d => d.Kitapid)
                    .HasConstraintName("emanet_kitapid_fkey");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.Emanet)
                    .HasForeignKey(d => d.Uyeid)
                    .HasConstraintName("emanet_uyeid_fkey");
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("kategori");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasColumnName("ad")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Kitap>(entity =>
            {
                entity.ToTable("kitap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasColumnName("ad")
                    .HasColumnType("character varying");

                entity.Property(e => e.Basimsayisi).HasColumnName("basimsayisi");

                entity.Property(e => e.Kategoriid).HasColumnName("kategoriid");

                entity.Property(e => e.Sayfasayisi).HasColumnName("sayfasayisi");

                entity.Property(e => e.Yayineviid).HasColumnName("yayineviid");

                entity.Property(e => e.Yazarid).HasColumnName("yazarid");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Kitap)
                    .HasForeignKey(d => d.Kategoriid)
                    .HasConstraintName("kitap_kategoriid_fkey");

                entity.HasOne(d => d.Yayinevi)
                    .WithMany(p => p.Kitap)
                    .HasForeignKey(d => d.Yayineviid)
                    .HasConstraintName("kitap_yayineviid_fkey");

                entity.HasOne(d => d.Yazar)
                    .WithMany(p => p.Kitap)
                    .HasForeignKey(d => d.Yazarid)
                    .HasConstraintName("kitap_yazarid_fkey");
            });

            modelBuilder.Entity<Kutuphane>(entity =>
            {
                entity.ToTable("kutuphane");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasColumnName("ad")
                    .HasColumnType("character varying");

                entity.Property(e => e.Adresid).HasColumnName("adresid");

                entity.HasOne(d => d.Adres)
                    .WithMany(p => p.Kutuphane)
                    .HasForeignKey(d => d.Adresid)
                    .HasConstraintName("kutuphane_adresid_fkey");
            });

            modelBuilder.Entity<Rapor>(entity =>
            {
                entity.ToTable("rapor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Emanetid).HasColumnName("emanetid");

                entity.HasOne(d => d.Emanet)
                    .WithMany(p => p.Rapor)
                    .HasForeignKey(d => d.Emanetid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("rapor_emanetid_fkey");
            });

            modelBuilder.Entity<Uye>(entity =>
            {
                entity.ToTable("uye");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adsoyad)
                    .HasColumnName("adsoyad")
                    .HasColumnType("character varying");

                entity.Property(e => e.Cinsiyet)
                    .HasColumnName("cinsiyet")
                    .HasColumnType("character varying");

                entity.Property(e => e.Kutuphaneid).HasColumnName("kutuphaneid");

                entity.Property(e => e.Telefon).HasColumnName("telefon");

                entity.HasOne(d => d.Kutuphane)
                    .WithMany(p => p.Uye)
                    .HasForeignKey(d => d.Kutuphaneid)
                    .HasConstraintName("uye_kutuphaneid_fkey");
            });

            modelBuilder.Entity<Yayinevi>(entity =>
            {
                entity.ToTable("yayinevi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasColumnName("ad")
                    .HasColumnType("character varying");

                entity.Property(e => e.Adresid).HasColumnName("adresid");

                entity.HasOne(d => d.Adres)
                    .WithMany(p => p.Yayinevi)
                    .HasForeignKey(d => d.Adresid)
                    .HasConstraintName("yayinevi_adres_fkey");
            });

            modelBuilder.Entity<Yazar>(entity =>
            {
                entity.ToTable("yazar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adsoyad)
                    .HasColumnName("adsoyad")
                    .HasColumnType("character varying");

                entity.Property(e => e.Biyografi)
                    .HasColumnName("biyografi")
                    .HasColumnType("character varying");

                entity.Property(e => e.Dogumtarihi)
                    .HasColumnName("dogumtarihi")
                    .HasColumnType("date");
            });
        }
    }
}
