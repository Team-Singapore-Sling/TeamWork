using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Collections;
using ExportToMySql;

namespace ImportToMySql
{
    public class MySqlManager
    {
        public void SendDataToMySql()
        {
            string connectionString = "server=localhost;database=movierating;uid=root;pwd=1234";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd;

            connection.Open();
            cmd = connection.CreateCommand();
            //Console.WriteLine(GetJsonFilesData());
            cmd.CommandText = GetJsonFilesData();

            cmd.ExecuteNonQuery();
        }

        public string GetJsonFilesData()
        {

            var files = GetReportsFileNamesFromDirectory(@"..\..\..\ExportedFiles\JSON\");

            var builder = new StringBuilder();

            foreach (var file in files)
            {
                string fileContent = File.ReadAllText(file);
                try
                {
                    Movie currentReport = JsonConvert.DeserializeObject<Movie>(fileContent);
                    string replaced = currentReport.Name.Replace("'", "");
                    builder.Append("insert into movieratingreport(Id, MovieName, MovieRating)values(" + currentReport.Id + ", '" + replaced + "', " + currentReport.Rating + ");");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error Message::" + e);
                }

                
            }
            return builder.ToString();
        }

        private static IEnumerable<string> GetReportsFileNamesFromDirectory(string directoryPath)
        {
            IEnumerable<string> filePaths = Directory.GetFiles(directoryPath, "*", SearchOption.TopDirectoryOnly)
                            .Where(p => Regex.IsMatch(p, @".json\b"));

            return filePaths;
        }
    }
}
