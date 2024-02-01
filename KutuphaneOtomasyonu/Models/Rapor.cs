using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Rapor : BaseEntity
    {
        public int EmanetId { get; set; }
        public virtual Emanet Emanet { get; set; }
        public virtual Kitap Kitap { get; set; } 
        public virtual Uye Uye { get; set; }
    }
}
