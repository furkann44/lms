using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Emanet : BaseEntity
    {
        public int UyeId { get; set; }
        public int KitapId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public int Month { get; set; } = DateTime.Now.Month; 
        public int Total { get; set; }
        public string MonthName
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.Month);
            }
        }

        public virtual Kitap Kitap { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
