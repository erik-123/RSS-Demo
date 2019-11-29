using RSS_Demo.Data;
using RSS_Demo.Mellanlager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSS_Demo.Logik
{
    class PodcastHandler
    {
        static private List<string> categoryList = CategoryRepo.LoadCategories();
        static private List<Podcast> podcastList = PodcastRepo.LoadPodcasts();
        static private Podcast newPodcast;
        public PodcastHandler()
        {
        }

        public static void saveData(string repo)
        {
            switch (repo)
            {
                case "pod":
                        PodcastRepo.SavePodcasts(podcastList);
                    break;
                case "cat":
                        CategoryRepo.SaveCategories(categoryList);
                    break;
                default:
                    CategoryRepo.SaveCategories(categoryList);
                    PodcastRepo.SavePodcasts(podcastList);
                    break;
            }

        }
        static public Podcast getPodcast(string podcastTitle)
        {
            var podcastLookup = podcastList.Where(podcastX => podcastX.Title == podcastTitle).FirstOrDefault();
            return podcastLookup;
        }
        static public void updatePodcast(string category, int interval, string selectedPodcast)
        {
            if (podcastList.Count() > 0)
            {
                var podcastLookup = podcastList.Where(podcastX => podcastX.Title == selectedPodcast).FirstOrDefault();
                
                if (podcastLookup.EpisodeCount > 0)
                {
                    if (podcastLookup.Category == category && podcastLookup.UpdateInterval == interval)
                    {
                        MessageBox.Show("Värdena som angavs är redan satta för podcasten, inga ändringar har gjorts");
                    }
                    else
                    {
                        podcastLookup.UpdateInterval = interval;
                        podcastLookup.Category = category;
                        MessageBox.Show("Podcasten är uppdaterad");
                    }
                }
            }
        }
        static public void addPodcast(string url, string category, int interval)
        {
            var podcast = RssReader.GetPodcastFromURL(url, category, interval);
            int iteration = 0;
            if (podcastList.Count() > 0)
            {
                foreach (var podcastInList in podcastList)
                {
                    var podcastLookup = podcastList.Where(podcastX => podcastInList.Title == podcast.Title);
                    iteration++;
                    if (podcastLookup.Count() > 0)
                    {
                        MessageBox.Show("Podcasten är redan inläst");
                        
                    }
                    else if(podcastLookup.Count() == 0 && podcastList.Count() == iteration)
                    {
                        podcastList.Add(podcast);
                        PodcastRepo.SavePodcasts(podcastList);
                    }
                }
            }
            else
            {
                podcastList.Add(podcast);
                PodcastRepo.SavePodcasts(podcastList);
            }
        }
        static public void removePodcast(int podcastIndex)
        {
            
            var grej2 = podcastList.ElementAt(podcastIndex);
            podcastList.RemoveAt(podcastIndex);
            PodcastRepo.SavePodcasts(podcastList);
            
        }
        static public List<string> getCategories()
        {
            return categoryList;
        }
        static public ListView getCategoryListview(ListView categoryListview)
        {
            return FormSetup.CreateCategoryListview(categoryList, categoryListview);
        }
        static public void addCategory(string categoryName)
        {
            categoryList.Add(categoryName);
            MessageBox.Show("Kategori tillagd");
        }
        static public int podcastListCount()
        {
            return podcastList.Count();
        }
        static public bool podcastCategoryLookup(string selectedCategory)
        {
            var podcastLookup = podcastList.Where(podcast => podcast.Category == selectedCategory).ToList();
            if(podcastLookup.Count > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Inga podcasts tillhör kategorin: " + selectedCategory);
                return false;
            }
        }

        
        static public ListView updateEpisodeListview(ListView episodeListview, ListView podcastListview)
        {
            var listViewEpisode = FormSetup.CreateEpisodeListview(podcastList.Where(podcast => podcast.Title == podcastListview.SelectedItems[0].Text).FirstOrDefault()?.EpisodeList, episodeListview);
            return listViewEpisode;
        }
        static public ListView updatePodcastListview(ListView podcastListview, bool episodeAdded)
        {
            ListView listViewPodcasts;
            if (episodeAdded)
            {
                listViewPodcasts = FormSetup.CreatePodcastListview(RssReader.GetNewEpisode(podcastList), podcastListview);
            }
            else
            {
                listViewPodcasts = FormSetup.CreatePodcastListview(podcastList, podcastListview);
            }
            return listViewPodcasts; 
        }
        static public ListView updatePodcastListview(ListView podcastListview, string selectedCategory)
        {
            var podcastLookup = podcastList.Where(podcast => podcast.Category == selectedCategory).ToList();
                var listViewPodcasts = FormSetup.CreatePodcastListview(podcastLookup, podcastListview);
                return listViewPodcasts;
        }
        static public ListView updateCategoryListview(ListView categoryListview)
        {




            var newCategoryListview = FormSetup.CreateCategoryListview(categoryList, categoryListview);
            
            return newCategoryListview;
        }
        static public string updateEpisodeDetails(ListView episodeListview, ListView podcastListview)
        {
            var podcastLookup = podcastList.Where(podcast => podcast.Title == podcastListview.SelectedItems[0].Text).FirstOrDefault();
            var episodeLookup = podcastLookup.EpisodeList.Where(episode => episode.Title == episodeListview.SelectedItems[0].Text).FirstOrDefault();
            if (episodeLookup != null)
            {
                string episodeDetailsText = episodeLookup.Description + " " + episodeLookup.EpisodeLink;
                return episodeDetailsText;
            }
            return "";
        }
    }

}
