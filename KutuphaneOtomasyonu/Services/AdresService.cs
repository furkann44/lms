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
    public class AdresService : ConnectionService,IService<Adres>
    {
       
        public AdresService (IConfiguration configuration) : base(configuration)
        {
            getConnection(configuration);
        }
         

        public void Add(Adres item)
        {
            using ( IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into adres(il,ilce,adrestarifi) values(@Il,@Ilce,@AdresTarifi)", item);
            }
        }

        public IEnumerable<Adres> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Adres>("select * from adres");
            }
        }

        public Adres FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Adres>("select * from adres where id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from adres where id = @Id",new { Id = id });
            }
        }

        public IEnumerable<Adres> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Adres item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("update adres set il = @Il, ilce = @Ilce, adrestarifi = @AdresTarifi where id = @Id", item);
            }
        }
    }
}
