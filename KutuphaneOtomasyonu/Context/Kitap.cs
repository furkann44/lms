using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Kitap
    {
        public Kitap()
        {
            Emanet = new HashSet<Emanet>();
        }

        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Ad { get; set; } 

        public int? Sayfasayisi { get; set; }
        public int? Basimsayisi { get; set; }
        public int? Yayineviid { get; set; }
        public int? Yazarid { get; set; }
        public int? Kategoriid { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual Yayinevi Yayinevi { get; set; }
        public virtual Yazar Yazar { get; set; }
        public virtual ICollection<Emanet> Emanet { get; set; }
    }
}
