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
                    Title = item.Element("title")?.Value ?? "",
                    Description = item.Element("description")?.Value ?? "",
                    Runtime = item.Element(ns + "duration")?.Value ?? "",
                    EpisodeLink = item.Element("link")?.Value ?? "",
                    PubDate = item.Element("pubDate")?.Value ?? ""
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

        public static List<Podcast> GetNewEpisode(List<Podcast> newPodcastList)
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
    }
}