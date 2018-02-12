using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Asg2_hxg170230
{
    /// <summary>
    /// Data Parser class, to parse data in and out of the file.
    /// </summary>
    public class DataParser
    {

        public String fileName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataParser"/> class.
        /// </summary>
        public DataParser()
        {
            // fetch the file name from the config file.
            this.fileName = ConfigurationSettings.AppSettings.Get("DataFile");
        }

        /// <summary>
        /// Parses the data from file into a List of <see cref="Model"/> objects.
        /// </summary>
        /// <returns>Returns a list of <see cref="Model"/> objects.</returns>
        public List<Model> parseFile()
        {
            try
            {
                var fileStream = new FileStream(this.fileName, FileMode.OpenOrCreate, FileAccess.Read);
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

        /// <summary>
        /// Writes into the data list to file.
        /// </summary>
        /// <param name="dataList">The list of <see cref="Model"/> objects.</param>
        public void writeFile(List<Model> dataList)
        {
            try
            {
                List<string> data = new List<string>();
                dataList.ForEach(d => data.Add(d.ToString()));
                var fileStream = new FileStream(this.fileName, FileMode.Truncate, FileAccess.Write);

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
