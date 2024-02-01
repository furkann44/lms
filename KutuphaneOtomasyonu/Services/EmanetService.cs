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
    public class EmanetService : ConnectionService, IService<Emanet>
    { 

        public EmanetService(IConfiguration configuration) : base(configuration)
        {
            getConnection(configuration);
        }
   
        public void Add(Emanet item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into emanet(kitapid,uyeid,month,year) values(@KitapId,@UyeId,@Month,@Year)", item);
            }
        }

        public IEnumerable<Emanet> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Emanet>("select * from emanet");
            }
        }

        public Emanet FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Emanet>("select * from emanet where id = @Id", new { Id = id }).FirstOrDefault(); ;
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from emanet where id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Emanet> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Emanet item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("update emanet set kitapid = @KitapId, uyeid = @UyeId, month = @Month, year = @Year where id = @Id", item);
            }
        }
    }
}
