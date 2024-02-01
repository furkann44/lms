using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Kategori
    {
        public Kategori()
        {
            Kitap = new HashSet<Kitap>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }

        public virtual ICollection<Kitap> Kitap { get; set; }
    }
}
