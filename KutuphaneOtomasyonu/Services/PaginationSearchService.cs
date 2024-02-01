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
    public class PaginationSearchService<T> : BridgeServices<T> where T : Models.BaseEntity
    {
        private string con;
        
        public PaginationSearchService(IConfiguration configuration)
        {
            con = configuration.GetValue<string>("DbInfo:ConnectionString");
        }
         

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(con);
            }
        }
         

        public override Task<IEnumerable<T>> BridgePagination(int limit, int offset)
        {
            var list = kitapService.FindAll();
            var tableName = typeof(T).Name;
            var query = "select * from @tableName order by id desc Limit @Limit Offset @Offset";
            var result = Connection.QueryAsync<T>(query, new { Limit = limit, Offset = offset });
            return result;
        }

        public override Task<IEnumerable<T>> BridgeSearch(string searchString)
        {
            var list = uyeService.Search(searchString);
            var tableName = typeof(T).Name;
            var query = "select * from @tableName where position (@SearchString in ad)>0";

            var asd = Connection.QueryAsync<T>(query, new { SearchString = searchString });
            return asd;
        }
    }
}
