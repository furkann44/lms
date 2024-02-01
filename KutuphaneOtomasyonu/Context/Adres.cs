using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Adres
    {
        public Adres()
        {
            Kutuphane = new HashSet<Kutuphane>();
            Yayinevi = new HashSet<Yayinevi>();
        }

        public int Id { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Adrestarifi { get; set; }

        public virtual ICollection<Kutuphane> Kutuphane { get; set; }
        public virtual ICollection<Yayinevi> Yayinevi { get; set; }
    }
}
