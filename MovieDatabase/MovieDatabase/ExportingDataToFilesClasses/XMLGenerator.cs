using MovieDatabase.DatabaseClassinstance;
using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MovieDatabase.ExportingDataToFilesClasses
{
    public class XMLGenerator
    {
        public void XmlGenerate()
        {
            XmlTextWriter writer = new XmlTextWriter("../../../ExportedFiles/Report.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            var database = new Database();
            var db = database.GetInstance();
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
                               .ToList();
            var directors = movie.Employees
                                 .Where(d => d.IsDirector == true)
                                 .ToList();
            writer.WriteStartElement("Movie");
            writer.WriteStartElement("Name");
            writer.WriteString(movie.Name);
            writer.WriteEndElement();
            writer.WriteStartElement("Diration");
            writer.WriteString(movie.Duration);
            writer.WriteEndElement();
            writer.WriteStartElement("Description");
            writer.WriteString(movie.Description);
            writer.WriteEndElement();
            writer.WriteStartElement("Rating");
            writer.WriteString(movie.Rating.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Year");
            writer.WriteString(movie.Year.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Directors");

            foreach (var director in directors)
            {
                writer.WriteStartElement("FirstName");
                writer.WriteString(director.FirstName);
                writer.WriteEndElement();
                writer.WriteStartElement("LastName");
                writer.WriteString(director.LastName);
                writer.WriteEndElement();
                writer.WriteStartElement("Age");
                writer.WriteString(director.Age.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("Salary");
                writer.WriteString(director.Salary.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteStartElement("Actors");

            foreach (var actor in actors)
            {
                writer.WriteStartElement("FirstName");
                writer.WriteString(actor.FirstName);
                writer.WriteEndElement();
                writer.WriteStartElement("LastName");
                writer.WriteString(actor.LastName);
                writer.WriteEndElement();
                writer.WriteStartElement("Age");
                writer.WriteString(actor.Age.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("Salary");
                writer.WriteString(actor.Salary.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
