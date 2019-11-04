using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RSS_Demo.Data
{
    internal static class PodcastRepo
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
            File.Delete("./podcast.xml");
            using (var fileStream = File.OpenWrite("./podcast.xml"))
            {
                var writer = new StreamWriter(fileStream);
                xmlSerializer.Serialize(writer, podcasts);
            }
        }
    }
}