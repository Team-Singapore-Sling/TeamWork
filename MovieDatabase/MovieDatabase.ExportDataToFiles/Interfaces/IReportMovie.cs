using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;

namespace MovieDatabase.ExportDataToFiles.Interfaces
{
    public interface IReportMovie
    {
        string MovieName { get; set; }

        string Description { get; set; }

        string Duration { get; set; }

        DateTime Year { get; set; }

        List<Genre> Genres { get; set; }

        List<Employee> Directors { get; set; }

        List<Employee> Actors { get; set; }
    }
}
