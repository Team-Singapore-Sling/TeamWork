using MovieDatabase.DatabaseClassinstance;
using MovieDatabase.DatabaseClassInstance;
using MovieDatabase.ExportDataToFiles.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.ExportDataToFiles.ExportingDataToFilesClasses
{
    public class JSONGenerator : IGenerator
    {
        public void Generate(IDatabase dbContext)
        {
            var db = dbContext.GetInstance();
            var movies = db.Movies
                             .OrderBy(m => m.Name)
                             .Select(m => new
                             {
                                 id = m.Id,
                                 name = m.Name,
                                 rating = m.Rating,
                                 year = m.Year,
                                 description = m.Description,
                                 duration = m.Duration,
                                 genres = m.Genres
                                           .Select(g => g.Name)
                                           .ToList(),
                                 directors = m.Employees
                                              .Where(e => e.IsDirector == true)
                                              .Select(ed => new
                                              {
                                                  firstname = ed.FirstName,
                                                  lastname = ed.LastName,
                                                  age = ed.Age,
                                                  salary = ed.Salary
                                              })
                                              .ToList(),
                                 actors = m.Employees
                                           .Where(e => e.IsDirector == false)
                                           .Select(em => new
                                           {
                                               firstname = em.FirstName,
                                               lastname = em.LastName,
                                               age = em.Age,
                                               salary = em.Salary
                                           })
                                           .ToList(),

                             })
                             .ToList();

            foreach (var movie in movies)
            {
                var jsonObject = JsonConvert.SerializeObject(movie, Newtonsoft.Json.Formatting.Indented);
                var address = "../../../ExportedFiles/JSON/" + movie.id + ".json";
                File.WriteAllText(address, jsonObject);
            }
        }
    }
}
