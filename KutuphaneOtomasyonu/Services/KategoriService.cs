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
    public class KategoriService : ConnectionService, IService<Kategori>
    { 

        public KategoriService(IConfiguration configuration) : base(configuration) 
        {
            getConnection(configuration);
        }
         
        public void Add(Kategori item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into kategori(ad) values(@Ad)", item);
            }
        }

        public IEnumerable<Kategori> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kategori>("select * from kategori");
            }
        }

        public Kategori FindById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kategori>("select * from kategori where id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from kategori where id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Kategori> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Kategori item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("update kategori set ad = @Ad where id = @Id where id = @Id", item);
            }
        }
    }
}
