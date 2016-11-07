using System.Collections.Generic;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    public class Genre
    {
        [XmlElement("name")]
        public List<string> GenreName { get; set; }
    }
}
