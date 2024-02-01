using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Adres : BaseEntity
    {
        public String Il { get; set; }
        public String Ilce { get; set; }
        public String AdresTarifi { get; set; }
    }
}
