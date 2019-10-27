using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RSS_Demo
{
  
    public class ListItemsHelper
    {
               

        public static string getPodcastTitel(string url)
        {
            try
            {
                var xe = XElement.Load(url);
                var podcastTitel = xe.DescendantsAndSelf("channel").Elements("title").First().Value;

                return podcastTitel;
            }
            catch (FileNotFoundException) 
                {
                var errormessage = ("Ogiltig url");
                MessageBox.Show("URL:en som du angav, är felaktig","Felmeddelande", 
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return errormessage;

                }
        }
        public static int getPodcastAntalAvsnitt(string url)
        {
            try
            {
                var xe = XElement.Load(url);
                var antalAvsnitt = xe.DescendantsAndSelf("channel").Elements("title").First().Value.Count();

                //alternativt sökord title eller item        


                return antalAvsnitt;
            }
            catch (FileNotFoundException e)
            {
                int test = 5;
                Console.WriteLine(e);
                return test;


            }
            



        }



        }
}

