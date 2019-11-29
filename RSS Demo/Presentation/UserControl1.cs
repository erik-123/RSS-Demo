using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSS_Demo.Mellanlager;
using RSS_Demo.Data;
using RSS_Demo.Logik;

namespace RSS_Demo.Presentation
{
    public partial class UserControl1 : UserControl
    {
        Podcast podcast;
        public UserControl1(List<string> categoryList, Podcast podcast)
        {
            InitializeComponent();
            this.podcast = podcast;
            foreach(string category in categoryList)
            {
                comboBox2.Items.Add(category);
            }
            comboBox1.SelectedIndex = categoryList.FindIndex(x => x.StartsWith(podcast.Category));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PodcastHandler.updatePodcast(comboBox2.Text, Int32.Parse(comboBox1.Text), podcast.Title);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
