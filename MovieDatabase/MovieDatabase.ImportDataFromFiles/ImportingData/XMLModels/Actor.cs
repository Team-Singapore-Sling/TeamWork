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
        public List<int> Age { get; set; }

        [XmlElement("salary")]
        public List<decimal> Salary { get; set; }
    }
}