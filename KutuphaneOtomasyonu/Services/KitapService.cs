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
    public class KitapService : ConnectionService, IService<Kitap>
    {

        public KitapService(IConfiguration configuration) : base(configuration)
        {
            getConnection(configuration);
        }

        public void Add(Kitap kitap)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into kitap(ad,sayfasayisi,basimsayisi,yayineviid,yazarid,kategoriid) values(@Ad,@SayfaSayisi,@BasimSayisi,@YayinEviId,@YazarId,@KategoriId)", kitap);
            }
        }

        public IEnumerable<Kitap> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kitap>("select * from kitap ");
            }
        }

        public Kitap FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kitap>("select * from kitap where id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("delete from kitap where id = @Id", new { Id = id });
            }
        }

        public void Update(Kitap kitap)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("update kitap set ad = @Ad, sayfasayisi = @SayfaSayisi, basimsayisi = @BasimSayisi, yayineviid = @YayinEviId, yazarid =  @YazarId, kategoriid = @KategoriId where id = @Id", kitap);
            }
        }

        public IEnumerable<Kitap> Search(string searchString)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kitap>("select * from kitap where position (@ss in ad)>0", new { ss = searchString });
            }
        }

        public IEnumerable<Kitap> Pagination(int page, int pageSize)
        {
            int start = (page - 1) * pageSize;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kitap>("select * from kitap order by id asc limit @PageSize offset @Start", new { PageSize = pageSize, Start = start });
            }
        }
         
    }
}
