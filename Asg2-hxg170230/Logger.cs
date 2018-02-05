using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg2_hxg170230
{
    public class Logger
    {
        public static void log(Exception ex)
        {
            var fileName = ConfigurationSettings.AppSettings.Get("LogFile");
            var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            List<Model> list = new List<Model>();
            using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
            {
                var log = new StringBuilder(DateTime.Now.ToLongTimeString());
                log.Append(ex.ToString());
                streamWriter.WriteLineAsync(log.ToString());
            }

        }
    }
}
