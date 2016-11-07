using System;
using MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels;
using System.IO;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData
{
    public class XmlImporter
    {
        private const string XmlPath = "../../../ImportedFiles/MoviesImport.xml";

       public static void ImportXml()
        {
            using (var reader = new StreamReader(XmlPath))
            {
                var xmlSerializer = new XmlSerializer(typeof(Cinema));
                var xmlDeserializer = xmlSerializer.Deserialize(reader);
            }
        }
    }
}
