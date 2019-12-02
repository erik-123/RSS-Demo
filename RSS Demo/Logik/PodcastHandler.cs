using RSS_Demo.Data;
using RSS_Demo.Logik;
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
        
        public PodcastHandler()
        {
        }
        static public ComboBox updateComboBox(ComboBox comboBox)
        {
            if (categoryList.Count > 0)
            {
                foreach (var category in categoryList)
                {
                    comboBox.Items.Add(category);
                }
                comboBox.Items.RemoveAt(0);
            }
            return comboBox;
        }
        static public void testmetod(ListView podcastListview, ListView episodeListview)
        {
            if(getPodcast(podcastListview.SelectedItems[0].Text).EpisodeList.ElementAt(episodeListview.SelectedItems[0].Index).Description != "")
            {

                var grej = getPodcast(podcastListview.SelectedItems[0].Text).EpisodeList.ElementAt(episodeListview.SelectedItems[0].Index).Description;
                MessageBox.Show("yes");
            }
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
        static public bool lookupTrue(string searchWord, string listType)
        {
            switch (listType)
            {
                case "podcast":
                        if(podcastList.Where(podcastX => podcastX.Title == searchWord).Count() > 0)
                        {
                            return true;
                        }
                        else if(podcastList.Where(podcastX => podcastX.Category == searchWord).Count() > 0)
                        {
                            return true;
                        }
                    break;
                case "category":
                    if (categoryList.Contains(searchWord))
                    {
                        return true;
                    }
                    break;
                
            }
            return false;
        }
        static public Podcast getPodcast(string podcastTitle)
        {
            return podcastList.Where(podcastX => podcastX.Title == podcastTitle).FirstOrDefault();
        }
        
        static public List<Podcast> getPodcasts(int interval)
        {
            return podcastList.Where(podcastX => podcastX.UpdateInterval == interval).ToList();
        }
        static public List<Podcast> getPodcasts(string category)
        {
            if(lookupTrue(category, "podcast"))
                    {
                return podcastList.Where(podcastX => podcastX.Category == category).ToList();
            }
                    else
            {
            
                return podcastList;
            }
        }
        static public void updatePodcast(string category, int interval, string selectedPodcast)
        {
            if (podcastList.Count() > 0)
            {
                var podcast = getPodcast(selectedPodcast);
                    if (podcast.Category == category && podcast.UpdateInterval == interval)
                    {
                        MessageBox.Show("Värdena som angavs är redan satta för podcasten, inga ändringar har gjorts");
                    }
                    else
                    {
                        podcast.UpdateInterval = interval;
                        podcast.Category = category;
                        MessageBox.Show("Podcasten är uppdaterad");
                    }
                
            }
        }
        static public string updateEpisodes(int interval)
        
        
        {
            return RssReader.GetNewEpisodes(getPodcasts(interval));
        }
        static public void addPodcast(string url, string category, int interval)
        {
            var podcast = RssReader.GetPodcastFromURL(url, category, interval);
            int iteration = 0;
            if (podcastList.Count() > 0)
            {
                foreach (var podcastInList in podcastList)
                {
                    
                    iteration++;
                    if (lookupTrue(podcastInList.Title, "podcast"))
                    {
                        MessageBox.Show("Podcasten är redan inläst");
                        
                    }
                    else if(!lookupTrue(podcastInList.Title, "podcast") && podcastList.Count() == iteration)
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
            podcastList.RemoveAt(podcastIndex);
            PodcastRepo.SavePodcasts(podcastList);
        }
        static public ListView updateCategoryListview(ListView categoryListview)
        {
            return FormSetup.CreateCategoryListview(categoryList, categoryListview);
        }
        static public void addCategory(string categoryName)
        {
            categoryList.Add(categoryName);
            MessageBox.Show("Kategori tillagd");
        }
        static public void updateCategory(string categoryName, int categoryIndex)
        {
            if(Validering.validateSelectedCategory(categoryList[categoryIndex], "edit"))
            {
                categoryList.RemoveAt(categoryIndex);
                categoryList.Add(categoryName);
                MessageBox.Show("Kategori uppdaterad");
            }
            

        }
        static public void removeCategory(string category)
        {
            categoryList.Remove(category);
        }
        static public int podcastListCount()
        {
            return podcastList.Count();
        }
        

        
        static public ListView updateEpisodeListview(ListView episodeListview, string selectedPodcast)
        {
            return FormSetup.CreateEpisodeListview(podcastList.Where(podcast => podcast.Title == selectedPodcast).FirstOrDefault()?.EpisodeList, episodeListview);
            
        }
        static public ListView updatePodcastListview(ListView podcastListview)
        {
            return podcastListview = FormSetup.CreatePodcastListview(podcastList, podcastListview);
        }
        static public ListView updatePodcastListview(ListView podcastListview, string selectedCategory)
        {
                return FormSetup.CreatePodcastListview(getPodcasts(selectedCategory), podcastListview);
        }
        
        static public string updateEpisodeDetails(ListView episodeListview, ListView podcastListview)
        {
            
            
                var episodeInfo = getPodcast(podcastListview.SelectedItems[0].Text).EpisodeList.ElementAt(episodeListview.SelectedItems[0].Index);
                return episodeInfo.Description + " \n" + episodeInfo.EpisodeLink;
            
            
        }
    }

}
