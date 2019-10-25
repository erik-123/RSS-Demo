using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjektArbete.Data
{

    static class PodcastRepo
    {
        static public List<Podcast> LoadPodcasts()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
            try
            {
                using (var filestream = File.OpenRead("./podcast.xml"))
                {
                    return (List<Podcast>)xmlSerializer.Deserialize(filestream);
                }
            }
            catch (FileNotFoundException)
            {
                return new List<Podcast>();
            }
        }
        static public void SavePodcasts(List<Podcast> podcasts)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Podcast>));

            using (var fileStream = File.OpenWrite("./podcast.xml"))
            {
                var writer = new StreamWriter(fileStream);
                xmlSerializer.Serialize(writer, podcasts);
            }
        }
    }
}
