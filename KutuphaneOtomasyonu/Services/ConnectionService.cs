using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Services
{
    public class ConnectionService
    {
        private static string connectionString; 
        public static string config;

        public ConnectionService(IConfiguration configuraiton)
        {
            connectionString = configuraiton.GetValue<string>("DbInfo:ConnectionString");
            if (connectionString != null)
            {
                config = connectionString;
            } 
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public static NpgsqlConnection getConnection(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DbInfo:ConnectionString");
            var cs = connectionString;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }


        public string ConnectionString
        {
            get
            {
                return connectionString;
            }

        }

        public string Config
        {
            get
            {
                return config;
            }

        }
    }
}
