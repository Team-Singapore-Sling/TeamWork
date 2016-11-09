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
using System.Data;

namespace ImportToMySql
{
    public class MySqlManager
    {
        public void SendDataToMySql()
        {
            string connectionString = "server=localhost;database=moviedatabase;uid=root;pwd=123456";

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

                Movie currentReport = JsonConvert.DeserializeObject<Movie>(fileContent);
                string replacedName = currentReport.Name.Replace("'", "");
                string replacedRating = currentReport.Rating.ToString().Replace(",", ".");
                string replacedDescription = currentReport.Description.ToString();
                string replacedYear = currentReport.Year.Month.ToString() + "-" + currentReport.Year.Day.ToString() + "-" + currentReport.Year.Year.ToString() +
                    " " + currentReport.Year.Hour.ToString() + ":" + currentReport.Year.Minute.ToString() + ":" + currentReport.Year.Second.ToString();
                string replacedDuration = currentReport.Duration.ToString();

                builder.Append(@"insert into movieratingreport(id, name, rating, description, year, duration) 
                 values(" + currentReport.Id + ", '" + replacedName + "', " + replacedRating + ", '" + replacedDescription + "', STR_TO_DATE('" + replacedYear + "', '%m-%d-%Y %H:%i:%s'), '" + replacedDuration + "');");

            }
            return builder.ToString();
        }

        public void ExportDataFromMySql()
        {
            const string connectionString = "server=localhost;database=moviedatabase;uid=root;pwd=123456";
            //List<string> tableNames = new List<string>() { "movieratingreport" };

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand com = new MySqlCommand("SELECT * FROM movieratingreport", connection);
            //Console.WriteLine(com);
            MySqlDataAdapter data = new MySqlDataAdapter(com);
            DataTable dat = new DataTable("movieratingreport");
            data.Fill(dat);

            dat.WriteXml(@"..\..\..\ExportedFiles\EXCEL\exportedData.xls");
        }

        private static IEnumerable<string> GetReportsFileNamesFromDirectory(string directoryPath)
        {
            IEnumerable<string> filePaths = Directory.GetFiles(directoryPath, "*", SearchOption.TopDirectoryOnly)
                            .Where(p => Regex.IsMatch(p, @".json\b"));

            return filePaths;
        }
    }
}
