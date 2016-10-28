using MovieDatabase.EntityData;
using MovieDatabase.ExportingDataToFilesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
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
            //Generating Xml file report
            var generateXMLFile = new XMLGenerator();
            generateXMLFile.XmlGenerate();
            //Generating Json file reports
            var generateJsonReports = new JSONGenerator();
            generateJsonReports.JsonGenerate();
        }
    }
}
