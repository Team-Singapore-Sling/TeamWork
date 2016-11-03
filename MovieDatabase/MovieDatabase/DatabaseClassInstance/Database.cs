using MovieDatabase.EntityData;

namespace MovieDatabase.DatabaseClassInstance
{
    public class Database : IDatabase
    {
        private static MoviesDatabaseOfTeamSingaporeSlingEntities database;

        public MoviesDatabaseOfTeamSingaporeSlingEntities GetInstance()
        {
            if (database == null)
            {
                database = new MoviesDatabaseOfTeamSingaporeSlingEntities();
            }

            return database;
        }
    }
}
