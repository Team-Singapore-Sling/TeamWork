using System.Xml.Serialization;

namespace MovieDatabase.ImportingData.XMLModels
{
    public class Actor
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Age")]
        public string Age { get; set; }
    }
}