using MovieDatabase.DatabaseClassInstance;
using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DatabaseClassinstance
{
    public class Database : IDatabase
    {
        public MoviesDatabaseOfTeamSingaporeSlingEntities GetInstance()
        {
            var database = new MoviesDatabaseOfTeamSingaporeSlingEntities();
            return database;
        }
    }
}
