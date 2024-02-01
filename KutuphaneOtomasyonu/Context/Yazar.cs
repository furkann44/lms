using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Yazar
    {
        public Yazar()
        {
            Kitap = new HashSet<Kitap>();
        }

        public int Id { get; set; }
        public string Adsoyad { get; set; }
        public string Biyografi { get; set; }
        public DateTime? Dogumtarihi { get; set; }

        public virtual ICollection<Kitap> Kitap { get; set; }
    }
}
