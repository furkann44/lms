using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Emanet
    {
        public Emanet()
        {
            Rapor = new HashSet<Rapor>();
        }

        public int Id { get; set; }
        public int? Uyeid { get; set; }
        public int? Kitapid { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }

        public virtual Kitap Kitap { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual ICollection<Rapor> Rapor { get; set; }
    }
}
