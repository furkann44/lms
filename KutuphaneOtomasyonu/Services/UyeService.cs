using Dapper;
using KutuphaneOtomasyonu.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Services
{
    public class UyeService : ConnectionService, IService<Uye>
    { 

        public UyeService(IConfiguration configuration) : base(configuration)
        {
            getConnection(configuration);
        }
  
        public void Add(Uye item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into uye(adsoyad,telefon,cinsiyet,kutuphaneid) values(@AdSoyad,@Telefon,@Cinsiyet,@KutuphaneId)", item);
            }
        }

        public IEnumerable<Uye> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Uye>("select * from uye");
            }
        }

        public Uye FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Uye>("select * from uye where id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from uye where id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Uye> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Uye item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into uye(adsoyad,telefon,cinsiyet,kutuphaneid) values(@Ad,@Telefon,@Cinsiyet,@KutuphaneId) where id = @Id", item);
            }
        }
    }
}
