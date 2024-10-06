using System.Text.Json.Serialization;

namespace X_Hackathon.Domain
{
    public class PackingList
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("Shipper's Name")]
        public string ShippersName { get; set; } = string.Empty;

        [JsonPropertyName("Reference Number")]
        public string ReferenceNumber { get; set; } = string.Empty;

        [JsonPropertyName("Type of Goods")]
        public string TypeOfGoods { get; set; } = string.Empty;

        [JsonPropertyName("Origin")]
        public string Origin { get; set; } = string.Empty;

        [JsonPropertyName("Destiniation")]
        public string Destination { get; set; } = string.Empty;

        [JsonPropertyName("Number of Pieces")]
        public string NumberOfPieces { get; set; } = string.Empty;

        [JsonPropertyName("Total weight")]
        public string TotalWeight { get; set; } = string.Empty;

        [JsonPropertyName("volume")]
        public string Volume { get; set; } = string.Empty;

        [JsonPropertyName("Url")]
        public string FileUrl { get; set; } = string.Empty;
    }
}
