using KutuphaneOtomasyonu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Services
{
    public abstract class BridgeServices<T> where T : BaseEntity
    {
        public IService<Kitap> kitapService;
        public IService<Uye> uyeService;

        public abstract Task<IEnumerable<T>> BridgeSearch(string searchString);
        public abstract Task<IEnumerable<T>> BridgePagination(int limit, int offset); 

    }
     
}
