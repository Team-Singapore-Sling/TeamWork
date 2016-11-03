using MovieDatabase.EntityData;

namespace MovieDatabase.DatabaseClassInstance
{
    public interface IDatabase
    {
        MoviesDatabaseOfTeamSingaporeSlingEntities GetInstance();
    }
}
