using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportToMySql
{
    public class Movie
    {
        public Movie()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public double Rating { get; set; }

    }
}
