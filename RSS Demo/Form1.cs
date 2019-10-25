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
//using System.ServiceModel.Web;//




namespace RSS_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                XmlReader FD_readxml = XmlReader.Create(textBox1.Text);
                SyndicationFeed FD_feed = SyndicationFeed.Load(FD_readxml);

                TabPage FD_tab = new TabPage(FD_feed.Title.Text);



                tabControl1.TabPages.Add(FD_tab);

                ListBox FD_list = new ListBox();

                FD_tab.Controls.Add(FD_list);

                FD_list.Dock = DockStyle.Fill;
                FD_list.HorizontalScrollbar = true;

                foreach (SyndicationItem FD_item in FD_feed.Items)
                {
                    FD_list.Items.Add(FD_item.Title.Text);
                    FD_list.Items.Add(FD_item.Summary.Text);
                    FD_list.Items.Add("----------------");


                }


            } catch { }
        }

        private void buttonLaggTillKategori_Click(object sender, EventArgs e)
        {
            try {
                string kategoriInput = textBoxKategori.Text.Trim();

                if (kategoriInput.Length != 0)
                {
                    listaKategorier.Items.Add(kategoriInput);
                    comboBoxKategori.Items.Add(kategoriInput);
                    
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
