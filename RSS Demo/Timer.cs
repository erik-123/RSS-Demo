using RSS_Demo.Data;
using RSS_Demo.Mellanlager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RSS_Demo;
using System.Windows.Forms;



namespace TimerHanterare
{
    public class TimerHantering
    {      
        //private int interval = UpdateIntervalRepo.LoadUpdateInterval();
        private List<Podcast> podcastList = PodcastRepo.LoadPodcasts();


        public virtual void Timer(int interval)
        {
            if (interval > 0)
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timer.Interval = interval;
                timer.Enabled = true;
                

            }
        }

        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                podcastList = RssReader.GetNewEpisode(podcastList);              
                
                

            }
            catch (Exception) { }
        }
        public void TimerSend(ListView listview) 
        { 
            listview = FormSetup.CreatePodcastListview(podcastList, listview);
        
        }

    }
}

