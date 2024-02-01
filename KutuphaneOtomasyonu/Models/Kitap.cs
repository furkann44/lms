using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Kitap : BaseEntity
    {
        public String Ad { get; set; }
        public int SayfaSayisi { get; set; }
        public int BasimSayisi { get; set; }
        public int yayineviid { get; set; }
        public int yazarid { get; set; }
        public int kategoriid { get; set; } 
        public int count { get; set; }
        public virtual Yazar Yazar{ get; set; }
        public virtual Kategori Kategori{ get; set; }
        public virtual YayinEvi YayinEvi { get; set; }
    }
}
