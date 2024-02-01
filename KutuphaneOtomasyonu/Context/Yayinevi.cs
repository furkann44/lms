using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Yayinevi
    {
        public Yayinevi()
        {
            Kitap = new HashSet<Kitap>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public int? Adresid { get; set; }

        public virtual Adres Adres { get; set; }
        public virtual ICollection<Kitap> Kitap { get; set; }
    }
}
