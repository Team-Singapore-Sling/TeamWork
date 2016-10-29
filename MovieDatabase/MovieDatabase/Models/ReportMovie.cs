using MovieDatabase.EntityData;
using MovieDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Models
{
    public class ReportMovie : IReportMovie
    {
        public string MovieName { get; set; }

        public string Description { get; set; }

        public string Duration { get; set; }

        public DateTime Year { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Employee> Directors { get; set; }

        public List<Employee> Actors { get; set; }
    }
}
