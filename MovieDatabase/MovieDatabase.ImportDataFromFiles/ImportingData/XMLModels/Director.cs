using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    public class Director
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }

        [XmlElement("salary")]
        public decimal Salary { get; set; }
    }
}