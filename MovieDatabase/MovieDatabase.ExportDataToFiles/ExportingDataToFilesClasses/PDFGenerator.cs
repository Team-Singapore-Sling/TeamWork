using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MovieDatabase.ExportDataToFiles.Models;
using MovieDatabase.DatabaseClassinstance;
using MovieDatabase.ExportDataToFiles.Interfaces;
using MovieDatabase.DatabaseClassInstance;

namespace MovieDatabase.ExportDataToFiles.ExportingDataToFilesClasses
{
    public class PDFGenerator : IGenerator
    {
        public void Generate(IDatabase dbContext)
        {
            FileStream fs = new FileStream("../../../ExportedFiles/MoviesReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None);

            Document document = new Document(this.CreatePdfRectangle());

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            this.FillDocument(document, dbContext.GetInstance());
        }

        private Rectangle CreatePdfRectangle()
        {
            Rectangle rect = new Rectangle(PageSize.A3);
            rect.BackgroundColor = new BaseColor(100, 100, 100);
            return rect;
        }

        private void FillDocument(Document document, MoviesDatabaseOfTeamSingaporeSlingEntities dbContext)
        {
            document.Open();

            this.GenerateData(document, dbContext);

            document.Close();
        }

        private void GenerateData(Document document, MoviesDatabaseOfTeamSingaporeSlingEntities dbContext)
        {
            var movies = dbContext.Movies
                                      .OrderBy(m => m.Name)
                                      .Select(m => new ReportMovie()
                                      {
                                          MovieName = m.Name,
                                          Description = m.Description,
                                          Duration = m.Duration,
                                          Year = m.Year,
                                          Genres = m.Genres.OrderBy(g => g.Name).ToList(),
                                          Directors = m.Employees.Where(d => d.IsDirector == true).ToList(),
                                          Actors = m.Employees.Where(a => a.IsDirector == false).ToList()
                                      })
                                      .ToList();

            PdfPTable table = new PdfPTable(7);

            int[] widths = new int[] { 20, 40, 20, 15, 20, 20, 25 };

            table.SetWidths(widths);

            table.AddCell(this.CreateCell(new Phrase("Movie name"), true));
            table.AddCell(this.CreateCell(new Phrase("Description"), true));
            table.AddCell(this.CreateCell(new Phrase("Duration"), true));
            table.AddCell(this.CreateCell(new Phrase("Year"), true));
            table.AddCell(this.CreateCell(new Phrase("Genre"), true));
            table.AddCell(this.CreateCell(new Phrase("Director"), true));
            table.AddCell(this.CreateCell(new Phrase("Actors"), true));

            this.InputData(movies, table);

            document.Add(table);
        }

        private void InputData(List<ReportMovie> movies, PdfPTable table)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                table.AddCell(this.CreateCell(new Phrase(movies[i].MovieName)));
                table.AddCell(this.CreateCell(new Phrase(movies[i].Description)));
                table.AddCell(this.CreateCell(new Phrase(movies[i].Duration)));
                table.AddCell(this.CreateCell(new Phrase(movies[i].Year.Year.ToString())));
                table.AddCell(this.CreateCell(new Phrase(this.ExtractGenres(movies[i].Genres))));
                table.AddCell(this.CreateCell(new Phrase(this.ExtractDirector(movies[i].Directors))));
                table.AddCell(this.CreateCell(new Phrase(this.ExtractActors(movies[i].Actors))));
            }
        }

        private string ExtractGenres(List<Genre> genres)
        {
            var result = new StringBuilder();

            for (int i = 0; i <= genres.Count - 1; i++)
            {
                if (i != genres.Count - 1)
                {
                    result.AppendLine(string.Format("{0},", genres[i].Name));
                }
                else
                {
                    result.Append(string.Format("{0}", genres[i].Name));
                }
            }

            return result.ToString();
        }

        private string ExtractDirector(List<Employee> director)
        {
            var result = new StringBuilder();

            for (int i = 0; i <= director.Count - 1; i++)
            {
                result.Append(string.Format("{0} {1}", director[i].FirstName, director[i].LastName));
            }

            return result.ToString();
        }

        private string ExtractActors(List<Employee> actors)
        {
            var result = new StringBuilder();

            for (int i = 0; i <= actors.Count - 1; i++)
            {
                if (i != actors.Count - 1)
                {
                    result.AppendLine(string.Format("{0} {1},", actors[i].FirstName, actors[i].LastName));
                }
                else
                {
                    result.Append(string.Format("{0} {1}", actors[i].FirstName, actors[i].LastName));
                }
            }

            return result.ToString();
        }

        private PdfPCell CreateCell(Phrase phrase, bool isHeader = false, int cellColspan = 0)
        {
            PdfPCell cell = new PdfPCell(phrase);
            if (isHeader)
            {
                cell.BackgroundColor = new BaseColor(102, 153, 153);
            }
            else
            {
                cell.BackgroundColor = new BaseColor(204, 204, 255);
            }

            cell.Colspan = cellColspan;
            cell.MinimumHeight = 25;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = 1;

            return cell;
        }
    }
}
