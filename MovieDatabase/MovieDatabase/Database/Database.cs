using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Database
{
    public class Database
    {
        public MoviesDatabaseOfTeamSingaporeSlingEntities GetInstance()
        {
            var database = new MoviesDatabaseOfTeamSingaporeSlingEntities();
            return database;
        }
    }
}
