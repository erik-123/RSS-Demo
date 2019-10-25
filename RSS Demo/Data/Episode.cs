﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbete.Data
{
    public class Episode
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public Episode(string title, string description, DateTime pubDate)
        {
            this.Title = title;
            this.Description = description;
            this.PubDate = pubDate;
        }
        public Episode()
        { }
    }
}
