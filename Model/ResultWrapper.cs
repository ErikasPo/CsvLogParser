using CsvLogParser.Database.Entities;
using Newtonsoft.Json;

namespace CsvLogParser.Model
{
    public class ResultWrapper
    {
        [JsonProperty("searchQuery")]
        public string SearchQuery { get; set; }

        [JsonProperty("logCount")]
        public int LogCount { get; set; }

        [JsonProperty("result")]
        public List<Log> Result { get; set; }
    }
}