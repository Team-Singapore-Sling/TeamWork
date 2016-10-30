using System.Collections.Generic;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    [XmlRoot("Cinema")]
    public class Cinema
    {
        [XmlElement("Movie")]
        public List<Movie> Movies { get; set; }
    }
}
