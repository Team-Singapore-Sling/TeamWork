using System.Collections.Generic;
using MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels;
using System.IO;
using System.Xml.Serialization;
using MovieDatabase.EntityData;
using Genre = MovieDatabase.EntityData.Genre;

namespace MovieDatabase.ImportDataFromFiles.ImportingData
{
    public class XmlImporter
    {
        private const string XmlPath = @"..\..\..\ImportedFiles\MoviesImport.xml";

        public static void ImportXml()
        {
            using (var reader = new StreamReader(XmlPath))
            {
                var serializer = new XmlSerializer(
                     typeof(List<Movie>),
                     new XmlRootAttribute("movies"));

                var allMovies = (IEnumerable<Movie>)serializer.Deserialize(reader);

                var db = new MoviesDatabaseOfTeamSingaporeSlingEntities();

                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                foreach (var movie in allMovies)
                {
                    var newGenres = new List<Genre>();

                    foreach (var genre in movie.Genres)
                    {
                        var newGenre = new Genre
                        {
                            Name = genre.GenreName
                        };

                        newGenres.Add(newGenre);
                    }

                    var allEmployees = new List<Employee>();

                    for (var a = 0; a < movie.Actors.FirstName.Count; a++)
                    {
                        var actor = new Employee()
                        {
                            FirstName = movie.Actors.FirstName[a],
                            LastName = movie.Actors.LastName[a],
                            Age = movie.Actors.Age[a],
                            Salary = movie.Actors.Salary[a],
                            IsDirector = false
                        };

                        allEmployees.Add(actor);
                    }

                    var director = new Employee()
                    {
                        FirstName = movie.Director.FirstName,
                        LastName = movie.Director.LastName,
                        Age = movie.Director.Age,
                        Salary = movie.Director.Salary,
                        IsDirector = true
                    };

                    allEmployees.Add(director);

                    var movieToBase = new Movy
                    {
                        Name = movie.Name,
                        Duration = movie.Duration,
                        Description = movie.Description,
                        Rating = movie.Rating,
                        Year = movie.Year,
                        Genres = newGenres,
                        Employees = allEmployees
                    };

                    db.Movies.Add(movieToBase);
                    db.SaveChanges();
                }

                db.Configuration.AutoDetectChangesEnabled = true;
                db.Configuration.ValidateOnSaveEnabled = true;
            }
        }
    }
}
