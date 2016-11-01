using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;

namespace MovieDatabase.ImportDataFromFiles
{
    public class MoviesImportToSql : ImportToSQL
    {
        public override void Import(IEnumerable<object> dataType)
        {
            foreach (var movie in dataType)
            {
                this.db.Movies.Add((Movy)movie);
            }

            db.SaveChanges();

        }


    }
}
