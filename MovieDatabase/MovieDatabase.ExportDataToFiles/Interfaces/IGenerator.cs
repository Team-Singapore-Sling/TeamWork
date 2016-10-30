using MovieDatabase.DatabaseClassinstance;

namespace MovieDatabase.ExportDataToFiles.Interfaces
{
    public interface IGenerator
    {
        void Generate(Database dbContext);
    }
}
