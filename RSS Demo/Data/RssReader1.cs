using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RSS_Demo.Data
{
    internal class RssReader
    {
        public static Podcast GetPodcastFromURL(string url, string category)
        {
            var i = 0;
            var podcastData = XDocument.Load(url);
            XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            var episodeData = podcastData.Descendants("item");
            var podcast = new Podcast();
            List<Episode> episodeList = new List<Episode>();

            foreach (var item in episodeData)
            {
                var episode = new Episode
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    Runtime = item.Element(ns + "duration").Value,
                    EpisodeLink = item.Element("link").Value,
                    PubDate = item.Element("pubDate").Value
                };
                episodeList.Add(episode);
                i++;
            }
            podcast.Title = podcastData.Descendants("title").FirstOrDefault().Value;
            podcast.Description = podcastData.Descendants("description").FirstOrDefault().Value;
            podcast.Link = podcastData.Descendants("link").FirstOrDefault().Value;
            podcast.FeedLink = url;
            podcast.Category = category;
            podcast.EpisodeCount = i;
            podcast.EpisodeList = episodeList;
            return podcast;
        }

        public static List<Podcast> GetNewEpisode(List<Podcast> podcastList)// Får in nya episoder
        {
            foreach (var podcast in podcastList)
            {
                XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";

                var podcastData = XDocument.Load(podcast.FeedLink);

                var episodeData = podcastData.Descendants("item").FirstOrDefault();

                var episodeLookup = podcast.EpisodeList.Where(episode => episode.Title == episodeData.Element("title").Value);

                if (episodeLookup.Count() == 0)
                {
                    var episode = new Episode
                    {
                        Title = episodeData.Element("title").Value,
                        Description = episodeData.Element("description").Value,
                        Runtime = episodeData.Element(ns + "duration").Value,
                        EpisodeLink = episodeData.Element("link").Value,
                        PubDate = episodeData.Element("pubDate").Value
                    };
                    podcast.EpisodeList.Add(episode);
                    podcastList[podcastList.FindIndex(ind => ind.Equals(podcast.Title))] = podcast;
                    return podcastList;
                }
            }
            return null;
        }
    }
}