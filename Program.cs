using CsvLogParser.Model;
using CsvLogParser.Services;
using CsvParser.Database;
using Newtonsoft.Json;
using System.Configuration;

internal class Program
{
    private static void Main()
    {
        try
        {
            var context = new CsvLogParserDbContext();
            var databaseServices = new DatabaseServices(context);

            string path = ConfigurationManager.AppSettings["FilePath"];

            var logList = CsvLogParser.Services.CsvParser.ParseFileToList(path);

            logList.ForEach(l =>
            {
                if (!databaseServices.CheckIfExistsInDb(l))
                {
                    databaseServices.SaveToDb(l);
                }
            });

            Console.WriteLine("Please type in the query, write column name first and then followed by the search keyword (search keyword can be partial with an asterisk *), for e.g. deviceVendor = Microsoft");
            var query = Console.ReadLine();
            var queryArray = query.Split(" = ");

            var foundLogs = databaseServices.SearchLogList(queryArray[0], queryArray[1]);
            int logCount = foundLogs.Count();

            var results = new ResultWrapper()
            {
                SearchQuery = query,
                LogCount = logCount,
                Result = foundLogs
            };

            foreach (var result in results.Result)
            {
                string output = JsonConvert.SerializeObject(results, Formatting.Indented);
                Console.WriteLine(output);
            }

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error, please see the exception message for more details: {ex.Message}");
        }
    }
}