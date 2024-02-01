using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Yazar : BaseEntity
    {
        public String AdSoyad { get; set; }
        public String Biyografi { get; set; } 
    }
}
