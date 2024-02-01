using KutuphaneOtomasyonu.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Services
{
    public abstract class LogBase 
    {
        
        protected LogBase NextLogger;

        public void SetNextLogger(LogBase logger)
        {
            this.NextLogger = logger;
        }
        abstract public void LogEkle(int id);
    }
}
