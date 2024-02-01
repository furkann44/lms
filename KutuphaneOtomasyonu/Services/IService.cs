using KutuphaneOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Services
{
    public interface IService<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindById(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> Search(string searchString);
    }
}
