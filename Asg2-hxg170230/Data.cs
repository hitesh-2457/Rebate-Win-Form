using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Asg2_hxg170230
{
    public class DataParser
    {
        public List<Model> parseFile()
        {
            var fileName = ConfigurationSettings.AppSettings.Get("DataFile");
            try
            {
                var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
                List<Model> list = new List<Model>();
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(new Model(line.Split('\t')));
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                Logger.log(e);
            }
            return null;
        }

        public void writeFile(List<Model> dataList)
        {
            try
            {
                List<string> data = new List<string>();
                dataList.ForEach(d => data.Add(d.ToString()));
                
                var fileName = ConfigurationSettings.AppSettings.Get("DataFile");
                var fileStream = new FileStream(fileName, FileMode.Truncate, FileAccess.Write);
                
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    foreach (var line in data)
                    {
                        streamWriter.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.log(e);
            }
        }
    }
}
