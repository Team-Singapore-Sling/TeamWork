using ImportToMySql;
using MovieDatabase.DatabaseClassInstance;
using MovieDatabase.ExportDataToFiles.ExportingDataToFilesClasses;
using MovieDatabase.ImportDataFromFiles;
using System;

namespace MovieDatabase.Start
{
    public class Startup
    {
        public static void Main()
        {
            //var db = new MoviesDatabaseOfTeamSingaporeSlingEntities();
            //var employees = db.Employees
            //                .Where(e => e.FirstName == "Tom")
            //                .Select(n =>
            //                new
            //                {
            //                    FirstName = n.FirstName,
            //                    LastName = n.LastName,
            //                    Salary = n.Salary,
            //                    Movies = n.Movies.Select(m => m.Name).ToList(),
            //                    IsDirector = n.IsDirector
            //                }
            //                    )
            //                .ToList();

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("The actor {0} {1} has participated in this movies:", employee.FirstName, employee.LastName);
            //    foreach (var movie in employee.Movies)
            //    {
            //        Console.WriteLine(movie);
            //    }
            //}

            //read from zip file & populate the database with more data + create updates pdf, xml & json files
            /*var reader = new ReadExcelFromZip();
            var movies = reader.SelectExcelFilesFromZip("../../../../Movies.zip");


            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Name);
            }

            var import = new MoviesImportToSql();
            import.Import(movies);*/

            IDatabase db = new Database();

            //Generating Xml file report
             //var generateXMLFile = new XMLGenerator();
             //generateXMLFile.Generate(db);
            //Generating Json file reports
             //var generateJsonReports = new JSONGenerator();
             //generateJsonReports.Generate(db);
            //Generating Pdf fle reports
            //var generatePdfReports = new PDFGenerator();
            //generatePdfReports.Generate(db);
            //Sending data to MySql
            var sendDataToMySQL = new MySqlManager();
            sendDataToMySQL.SendDataToMySql();
            //XMLImporter.ImportXML();

        }
    }
}
