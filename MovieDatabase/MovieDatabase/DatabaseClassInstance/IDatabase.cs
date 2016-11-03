using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DatabaseClassInstance
{
    public interface IDatabase
    {
        MoviesDatabaseOfTeamSingaporeSlingEntities GetInstance();
    }
}
