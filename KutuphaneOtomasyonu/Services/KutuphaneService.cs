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
    public class KutuphaneService : ConnectionService, IService<Kutuphane>
    { 

        public KutuphaneService(IConfiguration configuration) : base(configuration)
        {
            getConnection(configuration);
        }
 

        public void Add(Kutuphane item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into kutuphane(ad,adresid) values(@Ad,@AdresId)", item);
            }
        }

        public IEnumerable<Kutuphane> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kutuphane>("select * from kutuphane");
            }
        }

        public Kutuphane FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kutuphane>("select * from kutuphane where id= @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from kutuphane where id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Kutuphane> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Kutuphane item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("update kutuphane set ad = @Ad, adresid = @AdresId where id = @Id", item);
            }
        }
    }
}
