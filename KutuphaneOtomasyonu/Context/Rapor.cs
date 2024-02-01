using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Context
{
    public partial class Rapor
    {
        public int Id { get; set; }
        public int? Emanetid { get; set; }

        public virtual Emanet Emanet { get; set; }
    }
}
