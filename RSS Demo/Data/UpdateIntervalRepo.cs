using System.IO;
using System.Xml.Serialization;

namespace RSS_Demo.Data
{
    internal static class UpdateIntervalRepo
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
                return 10;
            }
        }

        static public void SaveUpdateInterval(int updateInterval)
        {
            var xmlSerializer = new XmlSerializer(typeof(int));
            File.Delete("./updateintervall.xml");

            using (var fileStream = File.OpenWrite("./updateIntervall.xml"))
            {
                var writer = new StreamWriter(fileStream);
                xmlSerializer.Serialize(writer, updateInterval);
            }
        }
    }
}