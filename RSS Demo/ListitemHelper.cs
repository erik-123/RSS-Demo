using System.Linq;
using System.Xml.Linq;

namespace RSS_Demo.Mellanlager
{
    public static class ListItemsHelper
    {
        public static string GetPodcastTitel(string url)
        {
            var xe = XElement.Load(url);
            var podcastTitel = xe.DescendantsAndSelf("channel").Elements("title").First().Value;

            return podcastTitel;
        }

        public static int GetPodcastNumberofSections(string url)
        {
            var xe = XElement.Load(url);
            var antalAvsnitt = xe.DescendantsAndSelf("channel").Elements("title").First().Value.Count();

            //alternativt sökord title eller item

            return antalAvsnitt;
        }
    }
}