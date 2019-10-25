using RSS_Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSS_Demo.Mellanlager
{
    class FormSetup
    {
        public FormSetup() { }
        static public ListViewItem setPodcastListItems(Podcast podcast)
        {
          


            ListViewItem podcastItem = new ListViewItem(podcast.Title);
            podcastItem.SubItems.Add(podcast.Category);
            
            podcastItem.SubItems.Add(podcast.Intervall.ToString());



            return podcastItem;
        }
        static public ListViewItem setAvsnittListItems(Episode episode)
        {



            ListViewItem podcastItem = new ListViewItem(episode.Title);
            podcastItem.SubItems.Add(episode.Title);

            podcastItem.SubItems.Add(episode.PubDate.ToString());

            podcastItem.SubItems.Add(episode.Runtime);

            podcastItem.SubItems.Add(episode.EpisodeLink);



            return podcastItem;
        }

    }
}
