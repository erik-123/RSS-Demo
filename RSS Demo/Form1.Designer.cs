using System;

namespace RSS_Demo
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxKategori = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxUpdateInterval = new System.Windows.Forms.ComboBox();
            this.listViewPodcasts = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Avsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listaKategorier = new System.Windows.Forms.ListView();
            this.buttonLaggTillKategori = new System.Windows.Forms.Button();
            this.buttonTaBortKategori = new System.Windows.Forms.Button();
            this.textBoxKategori = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAndra = new System.Windows.Forms.Button();
            this.buttonSparaKategorier = new System.Windows.Forms.Button();
            this.listViewEpisode = new System.Windows.Forms.ListView();
            this.columnAvnittNamn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPubliceringsdatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSpeltid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAvnittLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.episodeDetailsTextBox = new System.Windows.Forms.TextBox();
            this.buttonSaveUpdateInterval = new System.Windows.Forms.Button();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.labelUpdateCountdown = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 39);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 129);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Lagg till";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxKategori);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(213, 612);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ControlBox";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 178);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "Ta bort";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kategori";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL-RSS";
            // 
            // comboBoxKategori
            // 
            this.comboBoxKategori.FormattingEnabled = true;
            this.comboBoxKategori.Location = new System.Drawing.Point(13, 85);
            this.comboBoxKategori.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.comboBoxKategori.Name = "comboBoxKategori";
            this.comboBoxKategori.Size = new System.Drawing.Size(121, 24);
            this.comboBoxKategori.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
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
            this.comboBoxUpdateInterval.Location = new System.Drawing.Point(221, 20);
            this.comboBoxUpdateInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxUpdateInterval.Name = "comboBoxUpdateInterval";
            this.comboBoxUpdateInterval.Size = new System.Drawing.Size(121, 24);
            this.comboBoxUpdateInterval.TabIndex = 2;
            this.comboBoxUpdateInterval.SelectedIndexChanged += new System.EventHandler(this.ComboBoxUpdateInterval_SelectedIndexChanged);
            // 
            // listViewPodcasts
            // 
            this.listViewPodcasts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Kategori,
            this.Avsnitt});
            this.listViewPodcasts.HideSelection = false;
            this.listViewPodcasts.Location = new System.Drawing.Point(221, 53);
            this.listViewPodcasts.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listViewPodcasts.Name = "listViewPodcasts";
            this.listViewPodcasts.Size = new System.Drawing.Size(583, 227);
            this.listViewPodcasts.TabIndex = 15;
            this.listViewPodcasts.UseCompatibleStateImageBehavior = false;
            this.listViewPodcasts.View = System.Windows.Forms.View.Details;
            this.listViewPodcasts.SelectedIndexChanged += new System.EventHandler(this.ListViewPodcasts_SelectedIndexChanged);
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
            this.listaKategorier.HideSelection = false;
            this.listaKategorier.Location = new System.Drawing.Point(849, 39);
            this.listaKategorier.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listaKategorier.Name = "listaKategorier";
            this.listaKategorier.Size = new System.Drawing.Size(487, 237);
            this.listaKategorier.TabIndex = 16;
            this.listaKategorier.UseCompatibleStateImageBehavior = false;
            this.listaKategorier.View = System.Windows.Forms.View.List;
            this.listaKategorier.SelectedIndexChanged += new System.EventHandler(this.ListaKategorier_SelectedIndexChanged);
            // 
            // buttonLaggTillKategori
            // 
            this.buttonLaggTillKategori.Location = new System.Drawing.Point(1048, 282);
            this.buttonLaggTillKategori.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonLaggTillKategori.Name = "buttonLaggTillKategori";
            this.buttonLaggTillKategori.Size = new System.Drawing.Size(100, 28);
            this.buttonLaggTillKategori.TabIndex = 17;
            this.buttonLaggTillKategori.Text = "Lägg till";
            this.buttonLaggTillKategori.UseVisualStyleBackColor = true;
            this.buttonLaggTillKategori.Click += new System.EventHandler(this.ButtonLaggTillKategori_Click);
            // 
            // buttonTaBortKategori
            // 
            this.buttonTaBortKategori.Location = new System.Drawing.Point(1159, 284);
            this.buttonTaBortKategori.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonTaBortKategori.Name = "buttonTaBortKategori";
            this.buttonTaBortKategori.Size = new System.Drawing.Size(100, 28);
            this.buttonTaBortKategori.TabIndex = 18;
            this.buttonTaBortKategori.Text = "Ta bort...";
            this.buttonTaBortKategori.UseVisualStyleBackColor = true;
            this.buttonTaBortKategori.Click += new System.EventHandler(this.ButtonTaBortKategori_Click);
            // 
            // textBoxKategori
            // 
            this.textBoxKategori.Location = new System.Drawing.Point(849, 322);
            this.textBoxKategori.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBoxKategori.Name = "textBoxKategori";
            this.textBoxKategori.Size = new System.Drawing.Size(315, 22);
            this.textBoxKategori.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(845, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Kategorier";
            // 
            // buttonAndra
            // 
            this.buttonAndra.Location = new System.Drawing.Point(849, 284);
            this.buttonAndra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAndra.Name = "buttonAndra";
            this.buttonAndra.Size = new System.Drawing.Size(87, 26);
            this.buttonAndra.TabIndex = 21;
            this.buttonAndra.Text = "Andra";
            this.buttonAndra.UseVisualStyleBackColor = true;
            this.buttonAndra.Click += new System.EventHandler(this.ButtonAndra_Click);
            // 
            // buttonSparaKategorier
            // 
            this.buttonSparaKategorier.Location = new System.Drawing.Point(941, 284);
            this.buttonSparaKategorier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSparaKategorier.Name = "buttonSparaKategorier";
            this.buttonSparaKategorier.Size = new System.Drawing.Size(99, 23);
            this.buttonSparaKategorier.TabIndex = 22;
            this.buttonSparaKategorier.Text = "Spara";
            this.buttonSparaKategorier.UseVisualStyleBackColor = true;
            this.buttonSparaKategorier.Click += new System.EventHandler(this.ButtonSparaKategorier_Click);
            // 
            // listViewEpisode
            // 
            this.listViewEpisode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAvnittNamn,
            this.columnPubliceringsdatum,
            this.columnSpeltid,
            this.columnAvnittLink});
            this.listViewEpisode.HideSelection = false;
            this.listViewEpisode.Location = new System.Drawing.Point(221, 347);
            this.listViewEpisode.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listViewEpisode.Name = "listViewEpisode";
            this.listViewEpisode.Size = new System.Drawing.Size(583, 246);
            this.listViewEpisode.TabIndex = 25;
            this.listViewEpisode.UseCompatibleStateImageBehavior = false;
            this.listViewEpisode.View = System.Windows.Forms.View.Details;
            this.listViewEpisode.SelectedIndexChanged += new System.EventHandler(this.ListViewEpisode_SelectedIndexChanged);
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
            this.episodeDetailsTextBox.Location = new System.Drawing.Point(849, 363);
            this.episodeDetailsTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.episodeDetailsTextBox.Multiline = true;
            this.episodeDetailsTextBox.Name = "episodeDetailsTextBox";
            this.episodeDetailsTextBox.Size = new System.Drawing.Size(487, 233);
            this.episodeDetailsTextBox.TabIndex = 26;
            // 
            // buttonSaveUpdateInterval
            // 
            this.buttonSaveUpdateInterval.Location = new System.Drawing.Point(352, 16);
            this.buttonSaveUpdateInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSaveUpdateInterval.Name = "buttonSaveUpdateInterval";
            this.buttonSaveUpdateInterval.Size = new System.Drawing.Size(219, 28);
            this.buttonSaveUpdateInterval.TabIndex = 27;
            this.buttonSaveUpdateInterval.Text = "Spara uppdateringsintervall";
            this.buttonSaveUpdateInterval.UseVisualStyleBackColor = true;
            this.buttonSaveUpdateInterval.Click += new System.EventHandler(this.ButtonSaveUpdateInterval_Click);
            // 
            // labelUpdate
            // 
            this.labelUpdate.AutoSize = true;
            this.labelUpdate.Location = new System.Drawing.Point(220, 297);
            this.labelUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(135, 17);
            this.labelUpdate.TabIndex = 28;
            this.labelUpdate.Text = "Hämtar podcast om:";
            // 
            // labelUpdateCountdown
            // 
            this.labelUpdateCountdown.AutoSize = true;
            this.labelUpdateCountdown.Location = new System.Drawing.Point(352, 297);
            this.labelUpdateCountdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUpdateCountdown.Name = "labelUpdateCountdown";
            this.labelUpdateCountdown.Size = new System.Drawing.Size(16, 17);
            this.labelUpdateCountdown.TabIndex = 29;
            this.labelUpdateCountdown.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(461, 297);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 28);
            this.button3.TabIndex = 30;
            this.button3.Text = "Ta bort podcast";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 612);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelUpdateCountdown);
            this.Controls.Add(this.labelUpdate);
            this.Controls.Add(this.buttonSaveUpdateInterval);
            this.Controls.Add(this.episodeDetailsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewEpisode);
            this.Controls.Add(this.buttonSparaKategorier);
            this.Controls.Add(this.buttonAndra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxUpdateInterval);
            this.Controls.Add(this.textBoxKategori);
            this.Controls.Add(this.buttonTaBortKategori);
            this.Controls.Add(this.buttonLaggTillKategori);
            this.Controls.Add(this.listaKategorier);
            this.Controls.Add(this.listViewPodcasts);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
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

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxKategori;
        private System.Windows.Forms.ComboBox comboBoxUpdateInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewPodcasts;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Kategori;
        private System.Windows.Forms.ColumnHeader Avsnitt;
        private System.Windows.Forms.ListView listaKategorier;
        private System.Windows.Forms.Button buttonLaggTillKategori;
        private System.Windows.Forms.Button buttonTaBortKategori;
        private System.Windows.Forms.TextBox textBoxKategori;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAndra;
        private System.Windows.Forms.Button buttonSparaKategorier;
        private System.Windows.Forms.ListView listViewEpisode;
        private System.Windows.Forms.ColumnHeader columnAvnittNamn;
        private System.Windows.Forms.ColumnHeader columnPubliceringsdatum;
        private System.Windows.Forms.ColumnHeader columnSpeltid;
        private System.Windows.Forms.ColumnHeader columnAvnittLink;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox episodeDetailsTextBox;
        private System.Windows.Forms.Button buttonSaveUpdateInterval;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.Label labelUpdateCountdown;
        private System.Windows.Forms.Button button3;
    }
}

