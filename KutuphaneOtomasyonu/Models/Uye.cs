using KutuphaneOtomasyonu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Uye : BaseEntity
    {
        public String AdSoyad { get; set; }
        public long Telefon { get; set; }
        public String Cinsiyet { get; set; }
        public int KutuphaneId { get; set; }

        public virtual Kutuphane Kutuphane { get; set; }

 
    }
}
