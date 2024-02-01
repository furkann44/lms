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
    public class RaporService : ConnectionService, IService<Rapor>
    {

        public RaporService(IConfiguration configuration) : base(configuration)
        {
            getConnection(configuration);
        }

        

        public void Add(Rapor item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open(); 
            }
        }

        public IEnumerable<Rapor> FindAll()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Rapor>("select * from rapor");
            }
        }

        public Rapor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from rapor where id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Rapor> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Rapor item)
        {
            throw new NotImplementedException();
        }


       
    }
}
