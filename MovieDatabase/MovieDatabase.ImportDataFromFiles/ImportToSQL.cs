using MovieDatabase.EntityData;
using System.Collections.Generic;

namespace MovieDatabase.ImportDataFromFiles
{
    public abstract class ImportToSQL
    {
        protected MoviesDatabaseOfTeamSingaporeSlingEntities db = new MoviesDatabaseOfTeamSingaporeSlingEntities();

        public abstract void Import(IEnumerable<object> dataType);
    }
}
