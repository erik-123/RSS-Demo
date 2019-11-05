using InterfaceMeddelande;
using RSS_Demo.Data;
using RSS_Demo.Mellanlager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace RSS_Demo
{
    public partial class Form1 : Form, IMeddelande
    {
        private AsyncTimer timer;
        readonly private List<string> categoryList = CategoryRepo.LoadCategories();
        readonly private List<Podcast> podcastList = PodcastRepo.LoadPodcasts();
        private int interval = UpdateIntervalRepo.LoadUpdateInterval();
        private MessageController ctrl;
        private GreetingMsg greeting = new HolidayGreeting();

        public Form1()
        {
            InitializeComponent();

            MessageBox.Show(greeting.Greet());

            ctrl = new MessageController(this); //ny

            FormSetup.CreateCategoryListview(categoryList, listaKategorier);
            if (categoryList.Count > 0)
            {
                foreach (var category in categoryList)
                {
                    comboBoxKategori.Items.Add(category);
                }
                comboBoxKategori.Items.RemoveAt(0);
            }

            if (podcastList.Count > 0)
            {
                if (NyttInterval > 0)
                {
                    string uppdateringsIntervall = (interval).ToString() + " min";
                    comboBoxUpdateInterval.SelectedIndex = comboBoxUpdateInterval.FindStringExact(uppdateringsIntervall);
                    StartTimer(interval);
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

        public void Meddelande()
        {
            MessageBox.Show("Testar om interface för meddelande fungerar!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validering.KontrolleraOmURLArGiltig(textBoxURL.Text).Length > 0)
                {
                    if (Validering.KontrollOmComboBoxArTom(comboBoxKategori))
                    {
                        var podcast = RssReader.GetPodcastFromURL(textBoxURL.Text, comboBoxKategori.Text);
                        int iteration = 0;

                        if (podcastList.Count() > 0)
                        {
                            foreach (var podcastInList in podcastList)
                            {
                                var podcastLookup = podcastList.Where(podcastX => podcastInList.Title == podcast.Title);
                                iteration++;
                                if (podcastLookup.Count() > 0)
                                {
                                    MessageBox.Show("Podcasten är redan inläst");
                                    break;
                                }
                                else if ((podcastLookup.Count() == 0) && (podcastList.Count() == iteration))
                                {
                                    var lvi = new ListViewItem(new[] { podcast.Title, podcast.Category, podcast.EpisodeCount.ToString() });
                                    podcastList.Add(podcast);
                                    listViewPodcasts.Items.Add(lvi);
                                    PodcastRepo.SavePodcasts(podcastList);
                                    break;
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
            }
            catch (WebException) { }
        }

        private void ButtonLaggTillKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validering.KontrolleraOmTextfaltArTomt(textBoxKategori) && Validering.KontrollOmTextfaltHarSiffra(textBoxKategori))
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

        

        private void ButtonSparaKategorier_Click(object sender, EventArgs e)
        {

            CategoryRepo.SaveCategories(categoryList);

            MessageBox.Show("Kategorierna har sparats!");
            ctrl.InterfaceMeddelande();
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
                var hej = listViewPodcasts.SelectedItems[0];
                listViewEpisode.BeginUpdate();
                listViewEpisode = FormSetup.CreateEpisodeListview(podcastList.Where(podcast => podcast.Title == listViewPodcasts.SelectedItems[0].Text).FirstOrDefault().EpisodeList, listViewEpisode);
                listViewEpisode.EndUpdate();
                listViewEpisode.Items[0].Selected = true;
            }
        }

        private void ListViewEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEpisode.SelectedItems.Count > 0)
            {
                var podcastLookup = podcastList.Where(podcast => podcast.Title == listViewPodcasts.SelectedItems[0].Text).FirstOrDefault();
                var episodeLookup = podcastLookup.EpisodeList.Where(episode => episode.Title == listViewEpisode.SelectedItems[0].Text).FirstOrDefault();
                if (episodeLookup != null)
                {
                    episodeDetailsTextBox.Text = episodeLookup.Description + " " + episodeLookup.EpisodeLink;
                }
            }
        }

        private void ListaKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listaKategorier.SelectedItems.Count > 0))
            {
                if (listaKategorier.SelectedItems[0].Text == "Visa alla podcasts")
                {
                    listViewPodcasts.BeginUpdate();
                    listViewPodcasts = FormSetup.CreatePodcastListview(podcastList, listViewPodcasts);
                    listViewPodcasts.EndUpdate();
                    listViewPodcasts.Items[0].Selected = true;
                }
                else
                {
                    var podcastLookup = podcastList.Where(podcast => podcast.Category == listaKategorier.SelectedItems[0].Text).ToList();

                    if (podcastLookup.Count > 0)
                    {
                        listViewPodcasts.BeginUpdate();
                        listViewPodcasts = FormSetup.CreatePodcastListview(podcastLookup, listViewPodcasts);
                        listViewPodcasts.EndUpdate();
                        listViewPodcasts.Items[0].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("För tillfället tillhör inga podcasts kategorin \"" + listaKategorier.SelectedItems[0].Text + "\"");
                    }
                }
            }
        }

        public void StartTimer(int interval)
        {
            if (interval > 0)
            {
                if (timer != null)
                {
                    timer.Dispose();
                }
                timer = new AsyncTimer(TimeSpan.FromMinutes(interval), () =>
                {
                    //körs varje gång timern loopar
                    var newPodcastList = RssReader.GetNewEpisode(podcastList);
                    listViewPodcasts.BeginUpdate();
                    listViewPodcasts = FormSetup.CreatePodcastListview(newPodcastList, listViewPodcasts);
                    listViewPodcasts.EndUpdate();
                });

                timer.Start();
            }
        }

        private void ButtonSaveUpdateInterval_Click(object sender, EventArgs e)
        {
            switch (comboBoxUpdateInterval.Text)
            {
                case "10 min":
                    interval = 10;
                    break;

                case "5 min":
                    interval = 5;
                    break;

                case "1 min":
                    interval = 1;
                    break;
            }
            UpdateIntervalRepo.SaveUpdateInterval(interval);
            StartTimer(interval);
        }

        private void ComboBoxUpdateInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ButtonTaBortPodcast_Click(object sender, EventArgs e)
        {
            if (listViewPodcasts.SelectedItems.Count > 0)
            {
                var newPodlist = podcastList;
                newPodlist.RemoveAt(listViewPodcasts.SelectedIndices[0]);
                PodcastRepo.SavePodcasts(newPodlist);
                listViewPodcasts = FormSetup.CreatePodcastListview(newPodlist, listViewPodcasts);
            }
        }
    }
}