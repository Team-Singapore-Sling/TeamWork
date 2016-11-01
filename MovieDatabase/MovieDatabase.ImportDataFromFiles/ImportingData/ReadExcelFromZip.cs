using MovieDatabase.EntityData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;

namespace MovieDatabase.ImportDataFromFiles
{
    public class ReadExcelFromZip
    {
        private const string pathToExtratTo = "../../../ExportedFiles/ExcelFiles";

        public List<Movy> SelectExcelFilesFromZip(string path)
        {
            var movies = new List<Movy>();

            using (ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Update))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if(entry.FullName.EndsWith(".xlsx"))
                    {
                        string pathOfExtractedFile = Path.Combine(pathToExtratTo, entry.Name);
                        entry.ExtractToFile(pathOfExtractedFile);
                        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathOfExtractedFile + ";Extended Properties='Excel 12.0 xml;HDR=Yes';";

                        OleDbConnection connection = new OleDbConnection(connectionString);

                        using (connection)
                        {
                            connection.Open();
                            var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                            movies = this.ReadExcelData(connection, sheetName);
                        }
                    }
                }
            }
            return movies;
        }

        private List<Movy> ReadExcelData(OleDbConnection conn, string sheetName)
        {
            Console.WriteLine("Reading data...");
            var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", conn);
            using (var oleDbDataAdapter = new OleDbDataAdapter(excelDbCommand))
            {
                DataSet ds = new DataSet();
                oleDbDataAdapter.Fill(ds);
                var movies = new List<Movy>();
                using (var reader = ds.CreateDataReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movy();
                        movie.Name = reader["Name"].ToString();
                        var readerRating = reader["Rating"].ToString();
                        double rat = double.Parse(readerRating);
                        movie.Rating = rat;
                        var d = reader["Year"];
                        movie.Year = (DateTime)(d);
                        movie.Duration = reader["Duration"].ToString();
                        movie.Description = reader["Description"].ToString();
                        movies.Add(movie);
                    }
                }

                return movies;
            }
        }
    }
}
