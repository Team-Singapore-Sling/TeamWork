using MovieDatabase.DatabaseClassInstance;

namespace MovieDatabase.ExportDataToFiles.Interfaces
{
    public interface IGenerator
    {
        void Generate(IDatabase dbContext);
    }
}
