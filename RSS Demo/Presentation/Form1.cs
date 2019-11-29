using InterfaceMeddelande;
using RSS_Demo.Data;
using RSS_Demo.Logik;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace RSS_Demo
{
    public partial class Form : System.Windows.Forms.Form, IMessage
    {
        private AsyncTimer timer;
        readonly private List<string> categoryList = CategoryRepo.LoadCategories();
        readonly private List<Podcast> podcastList = PodcastRepo.LoadPodcasts();
        private int interval = UpdateIntervalRepo.LoadUpdateInterval();
        private readonly MessageController ctrl;
        private readonly GreetingMsg greeting = new HolidayGreeting();

        public Form()
        {
            InitializeComponent();

            MessageBox.Show(greeting.Greet());

            ctrl = new MessageController(this);
            podcastListview = PodcastHandler.updatePodcastListview(podcastListview, false);
            categoryListview = PodcastHandler.getCategoryListview(categoryListview);
            foreach(var category in PodcastHandler.getCategories() )
            {
                categoryCombobox.Items.Add(category);
            }
            
            //FormSetup.CreateCategoryListview(categoryList, listaKategorier);
            //if (categoryList.Count > 0)
            //{
            //    foreach (var category in categoryList)
            //    {
            //        comboBoxKategori.Items.Add(category);
            //    }
            //    comboBoxKategori.Items.RemoveAt(0);
            //}

            //if (podcastList.Count > 0)
            //{
            //    if (interval > 0)
            //    {
            //        string uppdateringsIntervall = (interval).ToString() + " min";
            //        comboBoxUpdateInterval.SelectedIndex = comboBoxUpdateInterval.FindStringExact(uppdateringsIntervall);
            //        StartTimer(interval);
            //    }
            //    FormSetup.CreatePodcastListview(podcastList, podcastListview);
            //    FormSetup.CreateEpisodeListview(podcastList.First().EpisodeList, listViewEpisode);
            //    podcastListview.Items[0].Selected = true;
            //}

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }
        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void Message()
        {
            MessageBox.Show("Kategorierna har sparats!");
        }

        private void ButtonURL_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validering.CheckIfURLIsValid(textBoxURL.Text).Length > 0)
                {
                    if (Validering.CheckIfComboboxIsEmpty(categoryCombobox))
                    {
                        PodcastHandler.addPodcast(textBoxURL.Text, categoryCombobox.Text, Int32.Parse(comboBoxUpdateInterval.Text.Substring(0, 1)));
                        podcastListview = PodcastHandler.updatePodcastListview(podcastListview, false);
                    }
                }
            }
            catch (WebException) { }
        }

        private void ButtonLaggTillKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validering.CheckIfTextfieldsIsEmpty(textBoxKategori) && Validering.CheckIfTextfieldsHasANumber(textBoxKategori))
                {
                    if (Validering.CheckIfCategoryIsAvailable(textBoxKategori))
                    {
                        string kategoriInput = textBoxKategori.Text.Trim();

                        if (kategoriInput.Length != 0)
                        {
                            categoryListview.Items.Add(kategoriInput);
                            categoryCombobox.Items.Add(kategoriInput);
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
                categoryCombobox.Items.RemoveAt(0);
                categoryListview.Items.Remove(categoryListview.SelectedItems[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Den valda kategorin kunde inte tas bort!");
            }
        }

        

        private void ButtonSparaKategorier_Click(object sender, EventArgs e)
        {

            PodcastHandler.saveData("cat");


            ctrl.InterfaceMessage();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the
            // user file and close it.

            PodcastHandler.saveData("all");
        }

        

        private void ListViewPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (podcastListview.SelectedItems.Count > 0)
            {
                var podcastData = PodcastHandler.getPodcast(podcastListview.SelectedItems.ToString());
                episodeListview.BeginUpdate();
                episodeListview = PodcastHandler.updateEpisodeListview(episodeListview, podcastListview);
                episodeListview.EndUpdate();
                episodeListview.Items[0].Selected = true;
            }
        }

        private void ListViewEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (episodeListview.SelectedItems.Count > 0)
            {
                episodeDetailsTextBox.Text = PodcastHandler.updateEpisodeDetails(episodeListview, podcastListview);
            }
        }

        private void ListaKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((categoryListview.SelectedItems.Count > 0))
            {
                if (categoryListview.SelectedItems[0].Text == "Visa alla podcasts" && podcastListview.Items.Count > 0)
                {
                    podcastListview.BeginUpdate();
                    podcastListview = PodcastHandler.updatePodcastListview(podcastListview, false);
                    podcastListview.EndUpdate();
                    podcastListview.Items[0].Selected = true;
                }
                else if (podcastListview.Items.Count > 0 && PodcastHandler.podcastCategoryLookup(categoryListview.SelectedItems[0].Text))
                {
                    podcastListview.BeginUpdate();
                    podcastListview = PodcastHandler.updatePodcastListview(podcastListview, categoryListview.SelectedItems[0].Text);
                    podcastListview.EndUpdate();
                    podcastListview.Items[0].Selected = true;
                }
                else if (podcastListview.Items.Count == 0)
                {

                    MessageBox.Show("Du har inte lagt till några podcasts än");

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
                timer = new AsyncTimer(TimeSpan.FromMinutes(interval), GetNewEpisodes);

                timer.Start();
            }
        }

        public void GetNewEpisodes()
        {
            if (podcastListview.InvokeRequired)
            {

                podcastListview.Invoke((MethodInvoker)GetNewEpisodes);
            }
            else
            {
                
                podcastListview.BeginUpdate();
                podcastListview = PodcastHandler.updatePodcastListview(podcastListview, true);
                podcastListview.EndUpdate();
                
                
                if (podcastListview.Items.Count > 0)
                {
                    podcastListview.Items[0].Selected = true;
                }
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

        

        private void ButtonTaBortPodcast_Click(object sender, EventArgs e)
        {
            if (podcastListview.SelectedItems.Count > 0)
            {
                PodcastHandler.removePodcast(podcastListview.SelectedIndices[0]);
                
                if(PodcastHandler.podcastListCount() > 0)
                {
                    podcastListview = PodcastHandler.updatePodcastListview(podcastListview, false);
                    podcastListview.Items[0].Selected = true;
                }
                else
                {
                    podcastListview.Items.Clear();
                    episodeListview.Items.Clear();
                    episodeDetailsTextBox.Clear();
                }
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if(podcastListview.SelectedItems.Count > 0)
            {
                if(categoryCombobox.Text.Length == 0 || comboBoxUpdateInterval.Text.Length == 0)
                {
                    MessageBox.Show("Vänligen fyll i både kategori och uppdateringsintervall för att ändra");
                }
                else
                {
                    PodcastHandler.updatePodcast(categoryCombobox.Text, Int32.Parse(comboBoxUpdateInterval.Text.Substring(0, 1)), podcastListview.SelectedItems[0].Text);
                    podcastListview = PodcastHandler.updatePodcastListview(podcastListview, false);
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en podcast att ändra");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            RssReader.GetNewEpisodes(podcastList.ElementAt(0));
        }
    }
}