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
    public class YazarService : ConnectionService, IService<Yazar>
    {
        public YazarService(IConfiguration configuraiton) : base(configuraiton)
        {
            getConnection(configuraiton);
        }

        public void Add(Yazar item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into yazar(adsoyad,biyografi) values(@AdSoyad,@Biyografi)", item);
            }
        }

        public IEnumerable<Yazar> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Yazar>("select * from yazar");
            }
        }

        public Yazar FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Yazar>("select * from yazar where id = @Id", new { Id = id }).FirstOrDefault(); ;
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from yazar where id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Yazar> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Yazar item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("update yazar set adsoyad = @AdSoyad, biyografi = @Biyografi where id = @Id", item);
            }
        }
    }
}
