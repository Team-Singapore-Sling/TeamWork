using MovieDatabase.ImportingData.XMLModels;
using System;
using System.IO;
using System.Xml.Serialization;

namespace MovieDatabase.ImportingData
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
