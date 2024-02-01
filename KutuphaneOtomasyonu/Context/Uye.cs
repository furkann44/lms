using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Uye
    {
        public Uye()
        {
            Emanet = new HashSet<Emanet>();
        }

        public int Id { get; set; }
        public string Adsoyad { get; set; }
        public long? Telefon { get; set; }
        public string Cinsiyet { get; set; }
        public int? Kutuphaneid { get; set; }

        public virtual Kutuphane Kutuphane { get; set; }
        public virtual ICollection<Emanet> Emanet { get; set; }
    }
}
