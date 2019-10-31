using RSS_Demo.Data;
using RSS_Demo.Mellanlager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Timers;
using System.Windows.Forms;





namespace RSS_Demo
{
    public partial class Form1 : Form
    {
        readonly private List<string> categoryList = CategoryRepo.LoadCategories();
        private List<Podcast> podcastList = PodcastRepo.LoadPodcasts();
        private int interval = UpdateIntervalRepo.LoadUpdateInterval();

        public Form1()
        {
            InitializeComponent();
            FormSetup.CreateCategoryListview(categoryList, listaKategorier);
            
            if (podcastList.Count > 0)
            {
                if (interval > 0)
                {
                    string uppdateringsIntervall = (interval / 1000 / 60).ToString() + " min";
                    comboBoxUpdateInterval.SelectedIndex = comboBoxUpdateInterval.FindStringExact(uppdateringsIntervall);
                    Timer(interval);
                }
                FormSetup.CreatePodcastListview(podcastList, listViewPodcasts);
                FormSetup.CreateEpisodeListview(podcastList.First().EpisodeList, listViewEpisode);
            }

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validering.KontrolleraOmURLArGiltig(textBox1.Text).Length > 0)
                {
                    if (Validering.KontrollOmComboBoxArTom(comboBoxKategori))
                    {
                        var podcast = RssReader.GetPodcastFromURL(textBox1.Text, comboBoxKategori.Text);
                        int iteration = 0;


                        if (podcastList.Count() < 0)
                        {
                            foreach (var podcastInList in podcastList)
                            {


                                var podcastLookup = podcastList.Where(podcastX => podcastInList.Title == podcast.Title);
                                iteration++;
                                if (podcastLookup.Count() > 0)
                                {
                                    MessageBox.Show("Podcasten är redan inläst");
                                }
                                else if ((podcastLookup.Count() == 0) && (podcastList.Count() == iteration))
                                {
                                    var lvi = new ListViewItem(new[] { podcast.Title, podcast.Category, podcast.EpisodeCount.ToString() });
                                    podcastList.Add(podcast);
                                    listViewPodcasts.Items.Add(lvi);
                                    PodcastRepo.SavePodcasts(podcastList);
                                }
                            }
                        }
                        else
                        {
                            podcastList.Add(podcast);
                            var lvi = new ListViewItem(new[] { podcast.Title, podcast.Category, podcast.EpisodeCount.ToString() });
                            podcastList.Add(podcast);
                            listViewPodcasts.Items.Add(lvi);
                            PodcastRepo.SavePodcasts(podcastList);

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

        private void ButtonLaggTillKategori_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Validering.KontrolleraOmTextfaltArTomt(textBoxKategori) == false && Validering.KontrollOmTextfaltHarSiffra(textBoxKategori) == true)
                {
                    if (Validering.kontrolleraOmKategoriFinns(textBoxKategori))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Något gick fel vid inläsningen av kategorin.");
            }
        }
        private void ButtonTaBortKategori_Click(object sender, EventArgs e)
        {
          
            try
            {
                comboBoxKategori.Items.RemoveAt(0);
                listaKategorier.Items.Remove(listaKategorier.SelectedItems[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Den valda kategorin kunde inte tas bort!");

            }


        }
       

        private void ButtonAndra_Click(object sender, EventArgs e)
        {
            
            try
            {
                comboBoxKategori.Items[0] = textBoxKategori.Text; ;
                comboBoxKategori.SelectedValue = textBoxKategori.Text;
                comboBoxKategori.Text = textBoxKategori.Text;
                listaKategorier.SelectedItems[0].Text = textBoxKategori.Text;


                

                textBoxKategori.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Du måste välja en kategori, innan du kan ändra", "Felmeddelande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonSparaKategorier_Click(object sender, EventArgs e)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof());

            CategoryRepo.SaveCategories(categoryList);

            MessageBox.Show("Kategorierna har sparats!");

        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the
            // user file and close it.

            CategoryRepo.SaveCategories(categoryList);
            PodcastRepo.SavePodcasts(podcastList);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListViewPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPodcasts.SelectedItems.Count > 0)
            {
                listViewEpisode.BeginUpdate();
                listViewEpisode = FormSetup.CreateEpisodeListview(podcastList.ElementAt(listViewPodcasts.SelectedIndices[0]).EpisodeList, listViewEpisode);
                listViewEpisode.Items[0].Selected = true;
                listViewEpisode.EndUpdate();
            }
        }

        private void ListViewEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEpisode.SelectedItems.Count > 0)
            {
                var podcastLookup = podcastList.Where(podcast => podcast.Title == listViewPodcasts.SelectedItems[0].Text).FirstOrDefault();
                var episodeLookup = podcastLookup.EpisodeList.Where(episode => episode.Title == listViewEpisode.SelectedItems[0].Text).FirstOrDefault();

                episodeDetailsTextBox.Text = episodeLookup.Description + " " + episodeLookup.EpisodeLink;
            }
        }

        private void ListaKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaKategorier.SelectedItems.Count > 0)
            {
                var podcastLookup = podcastList.Where(podcast => podcast.Category == listaKategorier.SelectedItems[0].Text).ToList();

                if (podcastLookup != null)
                {

                    listViewPodcasts.BeginUpdate();
                    listViewPodcasts = FormSetup.CreatePodcastListview(podcastLookup, listViewPodcasts);
                    listViewPodcasts.Items[0].Selected = true;
                    listViewPodcasts.EndUpdate();
                }
            }
        }

        public void Timer(int interval)
        {
            if (interval > 0)
            {
                using (System.Timers.Timer timer = new System.Timers.Timer())
                {
                    timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    timer.Interval = interval;
                    timer.Enabled = true;
                }

            }
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try{ 
                podcastList = RssReader.GetNewEpisode(podcastList); 
                listViewPodcasts = FormSetup.CreatePodcastListview(podcastList, listViewPodcasts);
                
            }
            catch(Exception) { }
        }

        private void ButtonSaveUpdateInterval_Click(object sender, EventArgs e)
        {
            switch (comboBoxUpdateInterval.Text)
            {
                case "10 min":
                    interval = 600000;
                    break;
                case "5 min":
                    interval = 300000;
                    break;
                case "1 min":
                    interval = 60000;
                    break;
            }
            UpdateIntervalRepo.SaveUpdateInterval(interval);
            //behöver funktion för att skriva över timer interval, eller skriva över hela timern med en ny
        }

        private void ComboBoxUpdateInterval_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (listViewPodcasts.SelectedItems.Count > 0)
            {

                var newPodlist = podcastList;
                newPodlist.RemoveAt(listViewPodcasts.SelectedIndices[0]);
                PodcastRepo.SavePodcasts(newPodlist);
                listViewPodcasts = FormSetup.CreatePodcastListview(podcastList, listViewPodcasts);
            }
        }
    }
}
