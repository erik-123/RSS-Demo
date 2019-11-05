using RSS_Demo.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RSS_Demo.Mellanlager
{
    internal class FormSetup
    {
        public FormSetup()
        {
        }

        static public ListView CreateCategoryListview(List<string> categoryList, ListView ListView)
        {
            var updatedListview = ListView;
            updatedListview.Items.Clear();
            foreach (var category in categoryList)
            {
                ListViewItem categoryItem = new ListViewItem(category);
                updatedListview.Items.Add(categoryItem);
            }
            return updatedListview;
        }

        static public ListView CreateEpisodeListview(List<Episode> episodeList, ListView episodeListView)
        {
            var updatedListview = episodeListView;
            updatedListview.Items.Clear();
            foreach (var episode in episodeList)
            {
                ListViewItem episodeItem = new ListViewItem(episode.Title);

                episodeItem.SubItems.Add(episode.PubDate);

                episodeItem.SubItems.Add(episode.Runtime);

                episodeItem.SubItems.Add(episode.EpisodeLink);

                updatedListview.Items.Add(episodeItem);
            }

            return updatedListview;
        }

        static public ListView CreatePodcastListview(List<Podcast> podcastList, ListView podcastListView)
        {
            if (podcastList.Count > 0)
            {
                var updatedListview = podcastListView;
                updatedListview.Items.Clear();

                foreach (var podcast in podcastList)
                {
                    ListViewItem podcastItem = new ListViewItem(podcast.Title);

                    podcastItem.SubItems.Add(podcast.Category);

                    podcastItem.SubItems.Add(podcast.EpisodeCount.ToString());

                    updatedListview.Items.Add(podcastItem);
                }

                return updatedListview;
            }
            return podcastListView;
        }
    }
}