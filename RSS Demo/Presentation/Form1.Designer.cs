using System;

namespace RSS_Demo
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Visa alla podcasts");
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonURL = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxUpdateInterval = new System.Windows.Forms.ComboBox();
            this.podcastListview = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Avsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryListview = new System.Windows.Forms.ListView();
            this.buttonLaggTillKategori = new System.Windows.Forms.Button();
            this.buttonTaBortKategori = new System.Windows.Forms.Button();
            this.textBoxKategori = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSparaKategorier = new System.Windows.Forms.Button();
            this.episodeListview = new System.Windows.Forms.ListView();
            this.columnAvnittNamn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPubliceringsdatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSpeltid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAvnittLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.episodeDetailsTextBox = new System.Windows.Forms.TextBox();
            this.buttonSaveUpdateInterval = new System.Windows.Forms.Button();
            this.buttonTabortPodcast = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Intervall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(10, 32);
            this.textBoxURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(145, 20);
            this.textBoxURL.TabIndex = 0;
            // 
            // buttonURL
            // 
            this.buttonURL.Location = new System.Drawing.Point(166, 236);
            this.buttonURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonURL.Name = "buttonURL";
            this.buttonURL.Size = new System.Drawing.Size(133, 28);
            this.buttonURL.TabIndex = 1;
            this.buttonURL.Text = "Lagg till";
            this.buttonURL.UseVisualStyleBackColor = true;
            this.buttonURL.Click += new System.EventHandler(this.ButtonURL_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.categoryCombobox);
            this.groupBox1.Controls.Add(this.textBoxURL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxUpdateInterval);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(160, 497);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ControlBox";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kategori";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL-RSS";
            // 
            // comboBoxKategori
            // 
            this.categoryCombobox.FormattingEnabled = true;
            this.categoryCombobox.Location = new System.Drawing.Point(10, 69);
            this.categoryCombobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoryCombobox.Name = "comboBoxKategori";
            this.categoryCombobox.Size = new System.Drawing.Size(92, 21);
            this.categoryCombobox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "UppdateringFrekvens";
            // 
            // comboBoxUpdateInterval
            // 
            this.comboBoxUpdateInterval.FormattingEnabled = true;
            this.comboBoxUpdateInterval.Items.AddRange(new object[] {
            "10 min",
            "5 min ",
            "1 min"});
            this.comboBoxUpdateInterval.Location = new System.Drawing.Point(11, 107);
            this.comboBoxUpdateInterval.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxUpdateInterval.Name = "comboBoxUpdateInterval";
            this.comboBoxUpdateInterval.Size = new System.Drawing.Size(92, 21);
            this.comboBoxUpdateInterval.TabIndex = 2;
            // 
            // podcastListview
            // 
            this.podcastListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Kategori,
            this.Avsnitt,
            this.Intervall});
            this.podcastListview.HideSelection = false;
            this.podcastListview.Location = new System.Drawing.Point(166, 43);
            this.podcastListview.Margin = new System.Windows.Forms.Padding(4);
            this.podcastListview.Name = "podcastListview";
            this.podcastListview.Size = new System.Drawing.Size(438, 185);
            this.podcastListview.TabIndex = 15;
            this.podcastListview.UseCompatibleStateImageBehavior = false;
            this.podcastListview.View = System.Windows.Forms.View.Details;
            this.podcastListview.SelectedIndexChanged += new System.EventHandler(this.ListViewPodcasts_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 150;
            // 
            // Kategori
            // 
            this.Kategori.Text = "Kategori";
            this.Kategori.Width = 100;
            // 
            // Avsnitt
            // 
            this.Avsnitt.Text = "Antal avsnitt";
            this.Avsnitt.Width = 120;
            // 
            // listaKategorier
            // 
            this.categoryListview.HideSelection = false;
            this.categoryListview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.categoryListview.Location = new System.Drawing.Point(637, 32);
            this.categoryListview.Margin = new System.Windows.Forms.Padding(4);
            this.categoryListview.Name = "listaKategorier";
            this.categoryListview.Size = new System.Drawing.Size(366, 193);
            this.categoryListview.TabIndex = 16;
            this.categoryListview.UseCompatibleStateImageBehavior = false;
            this.categoryListview.View = System.Windows.Forms.View.List;
            this.categoryListview.SelectedIndexChanged += new System.EventHandler(this.ListaKategorier_SelectedIndexChanged);
            // 
            // buttonLaggTillKategori
            // 
            this.buttonLaggTillKategori.Location = new System.Drawing.Point(717, 231);
            this.buttonLaggTillKategori.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLaggTillKategori.Name = "buttonLaggTillKategori";
            this.buttonLaggTillKategori.Size = new System.Drawing.Size(75, 25);
            this.buttonLaggTillKategori.TabIndex = 17;
            this.buttonLaggTillKategori.Text = "Lägg till";
            this.buttonLaggTillKategori.UseVisualStyleBackColor = true;
            this.buttonLaggTillKategori.Click += new System.EventHandler(this.ButtonLaggTillKategori_Click);
            // 
            // buttonTaBortKategori
            // 
            this.buttonTaBortKategori.Location = new System.Drawing.Point(800, 231);
            this.buttonTaBortKategori.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTaBortKategori.Name = "buttonTaBortKategori";
            this.buttonTaBortKategori.Size = new System.Drawing.Size(75, 25);
            this.buttonTaBortKategori.TabIndex = 18;
            this.buttonTaBortKategori.Text = "Ta bort...";
            this.buttonTaBortKategori.UseVisualStyleBackColor = true;
            this.buttonTaBortKategori.Click += new System.EventHandler(this.ButtonTaBortKategori_Click);
            // 
            // textBoxKategori
            // 
            this.textBoxKategori.Location = new System.Drawing.Point(637, 262);
            this.textBoxKategori.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxKategori.Name = "textBoxKategori";
            this.textBoxKategori.Size = new System.Drawing.Size(237, 20);
            this.textBoxKategori.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Kategorier";
            // 
            // buttonSparaKategorier
            // 
            this.buttonSparaKategorier.Location = new System.Drawing.Point(637, 231);
            this.buttonSparaKategorier.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSparaKategorier.Name = "buttonSparaKategorier";
            this.buttonSparaKategorier.Size = new System.Drawing.Size(74, 25);
            this.buttonSparaKategorier.TabIndex = 22;
            this.buttonSparaKategorier.Text = "Spara";
            this.buttonSparaKategorier.UseVisualStyleBackColor = true;
            this.buttonSparaKategorier.Click += new System.EventHandler(this.ButtonSparaKategorier_Click);
            // 
            // listViewEpisode
            // 
            this.episodeListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAvnittNamn,
            this.columnPubliceringsdatum,
            this.columnSpeltid,
            this.columnAvnittLink});
            this.episodeListview.HideSelection = false;
            this.episodeListview.Location = new System.Drawing.Point(166, 282);
            this.episodeListview.Margin = new System.Windows.Forms.Padding(4);
            this.episodeListview.Name = "listViewEpisode";
            this.episodeListview.Size = new System.Drawing.Size(438, 201);
            this.episodeListview.TabIndex = 25;
            this.episodeListview.UseCompatibleStateImageBehavior = false;
            this.episodeListview.View = System.Windows.Forms.View.Details;
            this.episodeListview.SelectedIndexChanged += new System.EventHandler(this.ListViewEpisode_SelectedIndexChanged);
            // 
            // columnAvnittNamn
            // 
            this.columnAvnittNamn.Text = "Avsnitt Namn";
            this.columnAvnittNamn.Width = 150;
            // 
            // columnPubliceringsdatum
            // 
            this.columnPubliceringsdatum.Text = "Publiceringsdatum";
            this.columnPubliceringsdatum.Width = 101;
            // 
            // columnSpeltid
            // 
            this.columnSpeltid.Text = "Speltid";
            // 
            // columnAvnittLink
            // 
            this.columnAvnittLink.Text = "Länk";
            // 
            // episodeDetailsTextBox
            // 
            this.episodeDetailsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.episodeDetailsTextBox.Location = new System.Drawing.Point(637, 295);
            this.episodeDetailsTextBox.Multiline = true;
            this.episodeDetailsTextBox.Name = "episodeDetailsTextBox";
            this.episodeDetailsTextBox.Size = new System.Drawing.Size(366, 190);
            this.episodeDetailsTextBox.TabIndex = 26;
            // 
            // buttonSaveUpdateInterval
            // 
            this.buttonSaveUpdateInterval.Location = new System.Drawing.Point(264, 13);
            this.buttonSaveUpdateInterval.Name = "buttonSaveUpdateInterval";
            this.buttonSaveUpdateInterval.Size = new System.Drawing.Size(164, 23);
            this.buttonSaveUpdateInterval.TabIndex = 27;
            this.buttonSaveUpdateInterval.Text = "Spara uppdateringsintervall";
            this.buttonSaveUpdateInterval.UseVisualStyleBackColor = true;
            this.buttonSaveUpdateInterval.Click += new System.EventHandler(this.ButtonSaveUpdateInterval_Click);
            // 
            // buttonTabortPodcast
            // 
            this.buttonTabortPodcast.Location = new System.Drawing.Point(459, 236);
            this.buttonTabortPodcast.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTabortPodcast.Name = "buttonTabortPodcast";
            this.buttonTabortPodcast.Size = new System.Drawing.Size(145, 28);
            this.buttonTabortPodcast.TabIndex = 30;
            this.buttonTabortPodcast.Text = "Ta bort podcast";
            this.buttonTabortPodcast.UseVisualStyleBackColor = true;
            this.buttonTabortPodcast.Click += new System.EventHandler(this.ButtonTaBortPodcast_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 28);
            this.button1.TabIndex = 31;
            this.button1.Text = "Ändra Podcast";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Intervall
            // 
            this.Intervall.Text = "Intervall";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 497);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonTabortPodcast);
            this.Controls.Add(this.buttonSaveUpdateInterval);
            this.Controls.Add(this.episodeDetailsTextBox);
            this.Controls.Add(this.episodeListview);
            this.Controls.Add(this.buttonURL);
            this.Controls.Add(this.buttonSparaKategorier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxKategori);
            this.Controls.Add(this.buttonTaBortKategori);
            this.Controls.Add(this.buttonLaggTillKategori);
            this.Controls.Add(this.categoryListview);
            this.Controls.Add(this.podcastListview);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form";
            this.Text = "Podcast";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Button buttonURL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryCombobox;
        private System.Windows.Forms.ComboBox comboBoxUpdateInterval;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListView podcastListview;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Kategori;
        private System.Windows.Forms.ColumnHeader Avsnitt;
        private System.Windows.Forms.ListView categoryListview;
        private System.Windows.Forms.Button buttonLaggTillKategori;
        private System.Windows.Forms.Button buttonTaBortKategori;
        private System.Windows.Forms.TextBox textBoxKategori;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSparaKategorier;
        private System.Windows.Forms.ListView episodeListview;
        private System.Windows.Forms.ColumnHeader columnAvnittNamn;
        private System.Windows.Forms.ColumnHeader columnPubliceringsdatum;
        private System.Windows.Forms.ColumnHeader columnSpeltid;
        private System.Windows.Forms.ColumnHeader columnAvnittLink;
        private System.Windows.Forms.TextBox episodeDetailsTextBox;
        private System.Windows.Forms.Button buttonSaveUpdateInterval;
        private System.Windows.Forms.Button buttonTabortPodcast;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader Intervall;
    }
}

