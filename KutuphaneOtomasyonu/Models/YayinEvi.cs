using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class YayinEvi : BaseEntity
    {
        public String Ad { get; set; }
        public int AdresId { get; set; }

        public virtual Adres Adres{ get; set; }
    }
}
