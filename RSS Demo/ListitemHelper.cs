using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RSS_Demo
{
  
    public class ListItemsHelper
    {
               

        public static string getPodcastTitel(string url)
        {
            var xe = XElement.Load(url);
            var podcastTitel = xe.DescendantsAndSelf("channel").Elements("title").First().Value;

            return podcastTitel;
        }
        public static int getPodcastAntalAvsnitt(string url)
        {
            var xe = XElement.Load(url);       
            var antalAvsnitt = xe.DescendantsAndSelf("channel").Elements("title").First().Value.Count();

            //alternativt sökord title eller item        


            return antalAvsnitt;
        }



    }
}

