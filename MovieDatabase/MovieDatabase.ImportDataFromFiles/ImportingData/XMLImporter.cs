using MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels;
using System.IO;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData
{
    public class XMLImporter
    {
       public static void ImportXML()
        {
            using (var reader = new StreamReader("../../../ImportedFiles/MoviesImport.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(Cinema));
                var xmlDeserializer = xmlSerializer.Deserialize(reader);
            }
        }
    }
}
