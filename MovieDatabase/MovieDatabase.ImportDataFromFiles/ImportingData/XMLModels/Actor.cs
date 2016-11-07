using System.Collections.Generic;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    public class Actor
    {
        [XmlElement("firstName")]
        public List<string> FirstName { get; set; }

        [XmlElement("lastName")]
        public List<string> LastName { get; set; }

        [XmlElement("age")]
        public List<string> Age { get; set; }

        [XmlElement("salary")]
        public List<string> Salary { get; set; }
    }
}