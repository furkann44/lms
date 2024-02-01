using Dapper;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Services
{
    public class SqlLog : LogBase
    {
        private static string connectionString;
        private readonly LogBase log;
        private readonly EventLog _eventLog;

        public SqlLog(IConfiguration configuraiton, LogBase logBase, EventLog eventLog)
        {
            connectionString = configuraiton.GetValue<string>("DbInfo:ConnectionString");
            log = logBase;
            _eventLog = eventLog;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public override void LogEkle(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("insert into emanetlog(emanetid) values(@EmanetId)", id);
            }
            _eventLog.SetNextLogger(log);
        }
    }

    public class EventLog : LogBase
    {
        private readonly ILogger _logger;
        private readonly LogBase _logBase;
        private readonly EmanetService eService;
        private readonly TextLog _textLog;

        public EventLog(IConfiguration configuraiton, EmanetService emanetService, ILogger logger, TextLog textLog, LogBase logBase)
        {
            eService = emanetService;
            _logger = logger;
            _textLog = textLog;
            _logBase = logBase;
        }
        public override void LogEkle(int id)
        {

            _logger.LogInformation(id, "Eklenen nesne {id}", id);
            var find = eService.FindById(id);

            if (find == null)
            {
                _logger.LogWarning(id, "Nesne {id} bulunamadı", id);

            }
            _textLog.SetNextLogger(_logBase);
            new ObjectResult(id);

        }
    }

    public class TextLog : LogBase
    {
        public override void LogEkle(int id)
        {
            var logPath = System.IO.Path.GetTempFileName();
            var logFile = System.IO.File.Create(logPath);
            var logWritter = new System.IO.StreamWriter(logFile);
            logWritter.WriteLine(id);
            logWritter.Dispose();
        }
    }
}
