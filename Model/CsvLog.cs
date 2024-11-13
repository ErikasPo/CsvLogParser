using Newtonsoft.Json;

namespace CsvLogParser.Model
{
    public class CsvLog
    {
        [JsonProperty("deviceVendor")]
        public string DeviceVendor { get; set; }

        [JsonProperty("deviceProduct")]
        public string DeviceProduct { get; set; }

        [JsonProperty("deviceVersion")]
        public float DeviceVersion { get; set; }

        [JsonProperty("signatureId")]
        public string SignatureId { get; set; }

        [JsonProperty("severity")]
        public int Severity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("rt")]
        public float Rt { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("shost")]
        public string Shost { get; set; }

        [JsonProperty("smac")]
        public string Smac { get; set; }

        [JsonProperty("dhost")]
        public string Dhost { get; set; }

        [JsonProperty("dmac")]
        public string Dmac { get; set; }

        [JsonProperty("suser")]
        public string Suser { get; set; }

        [JsonProperty("suid")]
        public string SuId { get; set; }

        [JsonProperty("externalId")]
        public int ExternalId { get; set; }

        [JsonProperty("cs1Label")]
        public string Cs1Label { get; set; }

        [JsonProperty("cs1")]
        public string Cs1 { get; set; }
    }
}