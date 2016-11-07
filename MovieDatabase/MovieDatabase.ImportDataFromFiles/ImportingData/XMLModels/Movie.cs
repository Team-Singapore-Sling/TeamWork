using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    [Serializable]
    [XmlType("movie")]
    public class Movie
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("duration")]
        public string Duration { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("rating")]
        public double Rating { get; set; }

        [XmlElement("year")]
        public DateTime Year { get; set; }

        [XmlElement("genres")]
        public List<Genre> Genres { get; set; }

        [XmlElement("directors")]
        public Director Director { get; set; }

        [XmlElement("actors")]
        public Actor Actors { get; set; }
    }
}