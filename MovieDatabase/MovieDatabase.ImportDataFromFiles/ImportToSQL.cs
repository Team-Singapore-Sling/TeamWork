using MovieDatabase.DatabaseClassInstance;
using System.Collections.Generic;

namespace MovieDatabase.ImportDataFromFiles
{
    public abstract class ImportToSQL
    {
        protected IDatabase db = new Database();

        public abstract void Import(IEnumerable<object> dataType);
    }
}
