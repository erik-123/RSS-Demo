using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using RSS_Demo.Data;
using RSS_Demo.Mellanlager;
using System.Net;
//using System.ServiceModel.Web;//





namespace RSS_Demo
{
    public partial class Form1 : Form
    {
        private List<string> categoryList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            categoryList = CategoryRepo.LoadCategories();
            foreach(string category in categoryList)
            {
                comboBoxKategori.Items.Add(category);
            }


            var podcastList = PodcastRepo.LoadPodcasts();

            var podcast = podcastList.ElementAt(0);

            var episodeList = podcast.EpisodeList;

            //var episode = episodeList.ElementAt(0);

           // listViewEpisode.Items.Add(FormSetup.setAvsnittListItems(episode));





            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //hämtar podcast titel och lägger till den  i en ListView
            var titel = ListItemsHelper.getPodcastTitel(textBox1.Text);
            listViewPodcasts.Items.Add(titel);

            
            
        }

        private void buttonLaggTillKategori_Click(object sender, EventArgs e)
        {
            try {
                string kategoriInput = textBoxKategori.Text.Trim();

                if (kategoriInput.Length != 0)
                {
                    listaKategorier.Items.Add(kategoriInput);
                    comboBoxKategori.Items.Add(kategoriInput);
                    categoryList.Add(kategoriInput);
                    
                }
                textBoxKategori.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Något gick fel vid inläsningen av kategorin.");
            }
        }
        private void buttonTaBortKategori_Click(object sender, EventArgs e)
        {
            comboBoxKategori.Items.RemoveAt(0);
            listaKategorier.Items.Remove(listaKategorier.SelectedItems[0]);

        }

        private void buttonAndra_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxKategori.Items[0] = textBoxKategori.Text; ;
                comboBoxKategori.SelectedValue = textBoxKategori.Text;
                comboBoxKategori.Text = textBoxKategori.Text;
                listaKategorier.SelectedItems[0].Text = textBoxKategori.Text;

                textBoxKategori.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Du måste välja en kategori, innan du kan ändra", "Felmeddelande",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSparaKategorier_Click(object sender, EventArgs e)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof());
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the
            // user file and close it.
            CategoryRepo.SaveCategories(categoryList);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
