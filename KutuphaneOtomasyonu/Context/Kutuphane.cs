using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Kutuphane
    {
        public Kutuphane()
        {
            Uye = new HashSet<Uye>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public int? Adresid { get; set; }

        public virtual Adres Adres { get; set; }
        public virtual ICollection<Uye> Uye { get; set; }
    }
}
