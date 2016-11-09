using ImportToMySql;
using MovieDatabase.DatabaseClassInstance;
using MovieDatabase.ExportDataToFiles.ExportingDataToFilesClasses;
using MovieDatabase.ImportDataFromFiles;
using MovieDatabase.ImportDataFromFiles.ImportingData;
using System;

namespace MovieDatabase.Start
{
    public class Startup
    {
        public static void Main()
        {
            IDatabase db = new Database();

            //read from zip file & populate the database with more data + create updates pdf, xml & json files
            var reader = new ReadExcelFromZip();
            var movies = reader.SelectExcelFilesFromZip("../../../../Movies.zip");


            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Name);
            }

            var import = new MoviesImportToSql();
            import.Import(movies);

            Console.WriteLine("Importing data from xml...");
            //Importing data from xml
            XmlImporter.ImportXml(db);

            //Console.WriteLine("Importing data to Mongo...");
            //Importing data to MongoDB
            //ImportToMongo.ImportToMongo.ImportData();

            Console.WriteLine("Generating xml files...");
            //Generating Xml file report
            var generateXMLFile = new XMLGenerator();
            generateXMLFile.Generate(db);

            Console.WriteLine("Generating json files...");
            //Generating Json file reports
            var generateJsonReports = new JSONGenerator();
            generateJsonReports.Generate(db);

            Console.WriteLine("Generating pdf reports...");
            //Generating Pdf fle reports
            var generatePdfReports = new PDFGenerator();
            generatePdfReports.Generate(db);

            //Sending data to MySql
            //var sendDataToMySQL = new MySqlManager();
            //sendDataToMySQL.SendDataToMySql();

            //Exporting data from MySql to excel file
            var mySqlExcelExport = new MySqlManager();
            mySqlExcelExport.ExportDataFromMySql();
        }
    }
}
