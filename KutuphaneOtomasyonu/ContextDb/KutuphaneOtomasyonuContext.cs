using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonu.Models
{
    public class KutuphaneOtomasyonuContext : DbContext
    {
        public KutuphaneOtomasyonuContext (DbContextOptions<KutuphaneOtomasyonuContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("User ID=postgres;Password=123qwe;Host=localhost;Port=5432;Database=dbKutuphane;Pooling=true;");
    


    public virtual DbSet<Kitap> Kitap { get; set; }
        public virtual DbSet<Kategori> kategori { get; set; }
        public virtual DbSet<Yazar> yazar { get; set; }
        public virtual DbSet<YayinEvi> yayinEvi { get; set; }
        public virtual DbSet<Uye> Uye{ get; set; }
    }
}
