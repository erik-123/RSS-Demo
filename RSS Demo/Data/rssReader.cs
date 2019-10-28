using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RSS_Demo.Data
{
    class rssReader
    {
        public static Podcast getPodcastFromURL(string url, string category, int intervall)
        {
            
            var i = 0;
            var podcastData = XDocument.Load(url);
            XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            var episodeData = podcastData.Descendants("item");
            var podcast = new Podcast();
            var episode = new Episode();
            List<Episode> episodeList = new List<Episode>();



            //DescendantsAndSelf("channel").Elements("title").First().Value.Count();
            
            foreach (var item in episodeData)
            {
                episode.Title = item.Element("title").Value;
                episode.Description = item.Element("description").Value;
                episode.Runtime = item.Element(ns + "duration").Value;
                episode.EpisodeLink = item.Element("link").Value;
                episode.PubDate = item.Element("pubDate").Value;
                episodeList.Add(episode);
                i++;
            }
            podcast.Title = podcastData.Descendants("title").FirstOrDefault().Value;
            podcast.Description = podcastData.Descendants("title").FirstOrDefault().Value;
            podcast.Link = podcastData.Descendants("link").FirstOrDefault().Value;
            podcast.Intervall = intervall;
            podcast.Category = category;
            podcast.EpisodeCount = i;
            podcast.EpisodeList = episodeList;
            return podcast;
        }
    }
}
