using MovieDatabase.DatabaseClassInstance;
using MovieDatabase.DatabaseClassInstance;
using MovieDatabase.EntityData;
using MovieDatabase.ExportDataToFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MovieDatabase.ExportDataToFiles.ExportingDataToFilesClasses
{
    public class XMLGenerator : IGenerator
    {
        public void Generate(IDatabase dbContext)
        {
            XmlTextWriter writer = new XmlTextWriter("../../../ExportedFiles/Report.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("movies");
            var db = dbContext.GetInstance();
            var moviesData = db.Movies
                               .OrderBy(m => m.Name)
                               .ToList();

            foreach (var movieData in moviesData)
            {
                this.CreateNode(movieData, writer);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void CreateNode(Movy movie, XmlTextWriter writer)
        {
            var actors = movie.Employees
                               .Where(a => a.IsDirector == false)
                               .OrderBy(a => a.FirstName)
                               .ToList();

            var directors = movie.Employees
                                 .Where(d => d.IsDirector == true)
                                 .OrderBy(d => d.FirstName)
                                 .ToList();

            var genres = movie.Genres
                              .OrderBy(g => g.Name)
                              .ToList();
            writer.WriteStartElement("movie");
            writer.WriteStartElement("name");
            writer.WriteString(movie.Name);
            writer.WriteEndElement();
            writer.WriteStartElement("duration");
            writer.WriteString(movie.Duration);
            writer.WriteEndElement();
            writer.WriteStartElement("description");
            writer.WriteString(movie.Description);
            writer.WriteEndElement();
            writer.WriteStartElement("rating");
            writer.WriteString(movie.Rating.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("year");
            writer.WriteString(movie.Year.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("genres");

            foreach (var genre in genres)
            {
                writer.WriteStartElement("name");
                writer.WriteString(genre.Name);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteStartElement("directors");

            foreach (var director in directors)
            {
                writer.WriteStartElement("firstName");
                writer.WriteString(director.FirstName);
                writer.WriteEndElement();
                writer.WriteStartElement("lastName");
                writer.WriteString(director.LastName);
                writer.WriteEndElement();
                writer.WriteStartElement("age");
                writer.WriteString(director.Age.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("salary");
                writer.WriteString(director.Salary.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteStartElement("actors");

            foreach (var actor in actors)
            {
                writer.WriteStartElement("firstName");
                writer.WriteString(actor.FirstName);
                writer.WriteEndElement();
                writer.WriteStartElement("lastName");
                writer.WriteString(actor.LastName);
                writer.WriteEndElement();
                writer.WriteStartElement("age");
                writer.WriteString(actor.Age.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("salary");
                writer.WriteString(actor.Salary.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
