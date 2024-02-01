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
    public class YayinEviService : ConnectionService,IService<YayinEvi>
    {
        
        public YayinEviService(IConfiguration configuration) : base(configuration)
        {
            getConnection(configuration);
        }
  
        public void Add(YayinEvi item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into yayinevi(ad,adresid) values(@Ad,@AdresId)", item);
            }
        }

        public IEnumerable<YayinEvi> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<YayinEvi>("select * from yayinevi");
            }
        }

        public YayinEvi FindById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<YayinEvi>("select * from yayinevi where id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from yayinevi evi where id = @Id", new { Id = id });
            }
        }

        public IEnumerable<YayinEvi> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(YayinEvi item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("update yayinevi set ad = @Ad, adresid = @AdresId where id = @Id", item);
            }
        }
    }
}
