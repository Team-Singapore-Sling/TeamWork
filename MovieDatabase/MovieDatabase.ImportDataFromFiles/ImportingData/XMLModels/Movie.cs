using System.Collections.Generic;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    public class Movie
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("duration")]
        public string Duration { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("rating")]
        public string Rating { get; set; }

        [XmlElement("year")]
        public string Year { get; set; }

        [XmlElement("genres")]
        public List<Genre> Genres { get; set; }

        [XmlElement("directors")]
        public Director Director { get; set; }

        [XmlElement("actors")]
        public Actor Actors { get; set; }
    }
}