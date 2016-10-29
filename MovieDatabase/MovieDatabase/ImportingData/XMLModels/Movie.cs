using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MovieDatabase.ImportingData.XMLModels
{
    public class Movie
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Duration")]
        public int Duration { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Rating")]
        public double Rating { get; set; }

        [XmlElement("Year")]
        public int Year { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Director")]
        public Director Director { get; set; }

        [XmlArray("Actors")]
        [XmlArrayItem("Actor")]
        public List<Actor> Actors { get; set; }
    }
}