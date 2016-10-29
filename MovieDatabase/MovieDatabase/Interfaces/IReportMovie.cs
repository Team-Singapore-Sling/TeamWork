using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Interfaces
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
