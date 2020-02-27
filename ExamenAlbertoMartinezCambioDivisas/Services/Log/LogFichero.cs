using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Log
{
    //Escibir en TXt
    public class LogFichero : ILog
    {
        private readonly string path;
        public LogFichero()
        {

            this.path = AppDomain.CurrentDomain.BaseDirectory + "LogFiles";
            Directory.CreateDirectory(path);

        }
        public void EscribirLog(string message)
        {
            var fechaHoy = DateTime.Now;

            using (var sw = new StreamWriter(this.path + "/logfile.txt", true))
            {
                sw.WriteLine($"[{fechaHoy}] {message}");
            }
        }
    }
}