using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
            List<Episode> episodeList = new List<Episode>();



            
            foreach (var item in episodeData)
            {
                var episode = new Episode();
                episode.Title = item.Element("title").Value;
                episode.Description = item.Element("description").Value;
                episode.Runtime = item.Element(ns + "duration").Value;
                episode.EpisodeLink = item.Element("link").Value;
                episode.PubDate = item.Element("pubDate").Value;
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
        public static List<Podcast> getNewEpisode(List<Podcast> podcastList)
        {

            foreach (var podcast in podcastList)
            {
                    
                    XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";

                    var podcastData = XDocument.Load(podcast.FeedLink);
                    
                    var episodeData = podcastData.Descendants("item").FirstOrDefault();
                    
                    var episodeLookup = podcast.EpisodeList.Where(episode => episode.Title == episodeData.Element("title").Value);
                    
                    if (episodeLookup.Count() == 0)
                    {
                        var episode = new Episode();
                        episode.Title = episodeData.Element("title").Value;
                        episode.Description = episodeData.Element("description").Value;
                        episode.Runtime = episodeData.Element(ns + "duration").Value;
                        episode.EpisodeLink = episodeData.Element("link").Value;
                        episode.PubDate = episodeData.Element("pubDate").Value;
                        podcast.EpisodeList.Add(episode);
                        podcastList[podcastList.FindIndex(ind => ind.Equals(podcast.Title))] = podcast;
                        return podcastList;
                    }
            }
            return null;
        }
        
    }
}
