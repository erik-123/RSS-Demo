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
        private List<Podcast> podcastList = PodcastRepo.LoadPodcasts();
        public Form1()
        {
            InitializeComponent();
            categoryList = CategoryRepo.LoadCategories();
            foreach (string category in categoryList)
            {
                comboBoxKategori.Items.Add(category);
            }
            if(podcastList != null)
            {
                foreach(var podcast in podcastList)
                {
                    List<Episode> episodeList = podcast.EpisodeList;
                    listViewPodcasts.Items.Add(FormSetup.setPodcastListItems(podcast));
                    foreach(var episode in episodeList)
                    {
                        listViewEpisode.Items.Add(FormSetup.setAvsnittListItems(episode));
                    }
                }
            }

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
            try
            {
                if (Validering.KontrolleraOmURLArGiltig(textBox1.Text).Length > 0)
                {
                    if (Validering.kontrolleraOmTextfaltArTomt(textBox1) == false && Validering.KontrollOmComboBoxArTom(comboBoxKategori))
                    {
                        var podcast = rssReader.getPodcastFromURL(textBox1.Text, comboBoxKategori.Text, default);
                        int iteration = 0; 

                        foreach(var podcastInList in podcastList)
                        {
                            var podcastLookup = podcastList.Where(podcastX => podcastInList.Title == podcast.Title);
                            iteration++;
                            if(podcastLookup.Count() > 0)
                            {
                                MessageBox.Show("Podcasten är redan inläst");
                            }
                            else if((podcastLookup.Count() == 0)&&(podcastList.Count() == iteration))
                            {
                                var lvi = new ListViewItem(new[] { podcast.Title, podcast.Category, podcast.EpisodeCount.ToString() });
                                podcastList.Add(podcast);
                                listViewPodcasts.Items.Add(lvi);
                                PodcastRepo.SavePodcasts(podcastList);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Du har skrivit in ett felaktigt url!");
                }
            }
            catch (WebException) { }
            }

        private void buttonLaggTillKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validering.kontrolleraOmTextfaltArTomt(textBoxKategori) == false && Validering.kontrollOmTextfaltHarSiffra(textBoxKategori) == true)
                {
                    string kategoriInput = textBoxKategori.Text.Trim();

                    if (kategoriInput.Length != 0)
                    {
                        listaKategorier.Items.Add(kategoriInput);
                        comboBoxKategori.Items.Add(kategoriInput);
                        categoryList.Add(kategoriInput);

                    }
                    textBoxKategori.Clear();

                }
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
                MessageBox.Show("Du måste välja en kategori, innan du kan ändra", "Felmeddelande", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(listViewPodcasts.SelectedItems.Count > 0)
            {
                var podcastLookup = podcastList.Where(podcast => podcast.Title == listViewPodcasts.SelectedItems[0].Text).FirstOrDefault();
                if(podcastLookup != null)
                {
                    var episodeList = podcastLookup.EpisodeList;
                    foreach(var episode in episodeList)
                    {
                        listViewEpisode.Items.Add(FormSetup.setAvsnittListItems(episode));
                    }
                }
            }
        }

        private void listViewEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPodcasts.SelectedItems.Count > 0)
            {
                var podcastLookup = podcastList.Where(podcast => podcast.Title == listViewPodcasts.SelectedItems[0].Text).FirstOrDefault();
                if (podcastLookup != null)
                {
                    var episodeList = podcastLookup.EpisodeList;
                    if(listViewEpisode.SelectedItems.Count > 0)
                    {
                        var episodeLookup = episodeList.Where(episode => episode.Title == listViewEpisode.SelectedItems[0].Text).FirstOrDefault();
                        Uri uri = new Uri(episodeLookup.EpisodeLink);
                        episodeDetailsTextBox.Text = episodeLookup.Description +" "+ uri;
                    }
                    
                    
                }
            }
        }
    }
}
