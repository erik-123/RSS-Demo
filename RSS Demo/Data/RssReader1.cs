using RSS_Demo.Logik;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RSS_Demo.Data
{
    internal class RssReader
    {
        public static Podcast GetPodcastFromURL(string url, string category, int updateInterval)
        {
            var podcastData = XDocument.Load(url);
            XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            var episodeData = podcastData.Descendants("item");
            var podcast = new Podcast();
            List<Episode> episodeList = new List<Episode>();

            foreach (var item in episodeData)
            {
                var episode = new Episode
                {
                    Title = item.Element("title")?.Value ?? "",
                    Description = item.Element("description")?.Value ?? "",
                    Runtime = item.Element(ns + "duration")?.Value ?? "",
                    EpisodeLink = item.Element("link")?.Value ?? "",
                    PubDate = item.Element("pubDate")?.Value ?? ""
                };
                episodeList.Add(episode);
            }
            podcast.Title = podcastData.Descendants("title").FirstOrDefault().Value;
            podcast.Description = podcastData.Descendants("description").FirstOrDefault().Value;
            podcast.Link = podcastData.Descendants("link").FirstOrDefault().Value;
            podcast.FeedLink = url;
            podcast.Category = category;
            podcast.UpdateInterval = updateInterval;
            podcast.EpisodeCount = episodeList.Count();
            podcast.EpisodeList = episodeList;
            return podcast;
        }

        public static List<Podcast> GetNewEpisode1(List<Podcast> newPodcastList)
        {
            for (var i = 0; i < newPodcastList.Count(); i++)
            {
                XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";

                var podcastData = XDocument.Load(newPodcastList[i].FeedLink);

                var episodeData = podcastData.Descendants("item");
                List<Episode> episodeList = new List<Episode>();

                foreach (var item in episodeData)
                {
                    var episode = new Episode
                    {
                        Title = item.Element("title")?.Value ?? "",
                        Description = item.Element("description")?.Value ?? "",
                        Runtime = item.Element(ns + "duration")?.Value ?? "",
                        EpisodeLink = item.Element("link")?.Value ?? "",
                        PubDate = item.Element("pubDate")?.Value ?? ""
                    };
                    episodeList.Add(episode);
                }

                var newEpisodesList = episodeList.Except(newPodcastList[i].EpisodeList).ToList();

                if (newEpisodesList.ElementAt(0).Title != newPodcastList[i].EpisodeList.ElementAt(0).Title)
                {
                    newPodcastList[i].EpisodeList = newEpisodesList;
                    newPodcastList[i].EpisodeCount = newPodcastList[i].EpisodeList.Count();
                    newPodcastList[newPodcastList.IndexOf(newPodcastList[i])] = newPodcastList[i];
                }
            }
            return newPodcastList;
        }
        public static void GetNewEpisode()
        {
            Form.timerCounter++;
        }








        public static string GetNewEpisodes(Podcast podcast)
        {
            var podcastsToGet = XDocument.Load(podcast.FeedLink).Descendants("item").Count() - podcast.EpisodeList.Count();
            if (podcastsToGet > 0)
            {
                for (var i = 0; i < podcastsToGet - 1; i++)
                {
                    podcast.EpisodeList.Reverse();
                    podcast.EpisodeList.Add(createEpisode(XDocument.Load(podcast.FeedLink).Descendants("item").ElementAt(i)));
                    podcast.EpisodeList.Reverse();

                }
                return podcast.Title + " " + podcastsToGet;
            }
            return "";
        }
        static private Episode createEpisode(XElement episodeElements)
        {
            XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            var episode = new Episode
                {
                    Title = episodeElements.Element("title")?.Value ?? "",
                    Description = episodeElements.Element("description")?.Value ?? "",
                    Runtime = episodeElements.Element(ns + "duration")?.Value ?? "",
                    EpisodeLink = episodeElements.Element("link")?.Value ?? "",
                    PubDate = episodeElements.Element("pubDate")?.Value ?? ""
                };
            return episode;
        }
            
        
    }
}