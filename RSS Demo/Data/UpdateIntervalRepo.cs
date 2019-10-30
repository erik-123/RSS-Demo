using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSS_Demo.Data
{
    static class UpdateIntervalRepo
    {
        static public int LoadUpdateInterval()
        {
            var xmlSerializer = new XmlSerializer(typeof(int));
            try
            {
                using (var filestream = File.OpenRead("./updateIntervall.xml"))
                {
                    return (int)xmlSerializer.Deserialize(filestream);
                }
            }
            catch (FileNotFoundException)
            {
                return 0;
            }
        }
        static public void SaveUpdateInterval(int updateInterval)
        {
            var xmlSerializer = new XmlSerializer(typeof(int));

            using (var fileStream = File.OpenWrite("./updateIntervall.xml"))
            {
                var writer = new StreamWriter(fileStream);
                xmlSerializer.Serialize(writer, updateInterval);
            }
        }
    }
}
