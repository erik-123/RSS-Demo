using RSS_Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSS_Demo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {



            
            //var episod = new Episode("Hej", "det här är hej", default);

            //var episodLista = new List<Episode>();
            //episodLista.Add(episod);
            
            //var podcast = new Podcast("giant", "bomb", 1, "", "", episodLista);
            //var podcasts = new List<Podcast>();
            //podcasts.Add(podcast);
            
            //PodcastRepo.SavePodcasts(podcasts);



            //var hej = "";


            //PodcastRepo.SavePodcasts(podcasts);

            //podcasts = PodcastRepo.LoadPodcasts();

            //var giantBomb = podcasts.Where(podcast => podcast.Title == "abc").FirstOrDefault();
            //if (giantBomb != null)
            //{
            //    // we have found giantbomb
            //    var latestEpisode = giantBomb.EpisodeList.OrderByDescending(episode => episode.PubDate).FirstOrDefault();
            //}
            //var gamingPodcasts = podcasts.Where(podcast => podcast.Category == "gaming").ToList();
            //var giantBomb2 = (from podcast in podcasts
            //                  where podcast.Title == "giant"
            //                  select podcast)
            //                 .FirstOrDefault();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
