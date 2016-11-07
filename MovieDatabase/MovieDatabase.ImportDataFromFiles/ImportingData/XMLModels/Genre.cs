using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    public class Genre
    {
        [XmlElement("name")]
        public string GenreName { get; set; }
    }
}
