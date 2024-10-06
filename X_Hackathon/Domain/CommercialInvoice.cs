using System.Text.Json.Serialization;

namespace X_Hackathon.Domain
{
    public class CommercialInvoice
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("Shipper's Name")]
        public string ShippersName { get; set; } = string.Empty;

        [JsonPropertyName("Reference Number")]
        public string ReferenceNumber { get; set; } = string.Empty;

        [JsonPropertyName("Code Identifier")]
        public string CodeIdentifier { get; set; } = string.Empty;

        [JsonPropertyName("The amount")]
        public string Amount { get; set; } = string.Empty;

        [JsonPropertyName("Type of Goods")]
        public string TypeOfGoods { get; set; } = string.Empty;

        [JsonPropertyName("Origin")]
        public string Origin { get; set; } = string.Empty;

        [JsonPropertyName("Destination")]
        public string Destination { get; set; } = string.Empty;

        [JsonPropertyName("Number of Pieces")]
        public string NumberOfPieces { get; set; } = string.Empty;

        [JsonPropertyName("weight")]
        public string Weight { get; set; } = string.Empty;

        [JsonPropertyName("volume")]
        public string Volume { get; set; } = string.Empty;


        [JsonPropertyName("AWBNumber")]
        public string AWBNumber { get; set; } = string.Empty;
        [JsonPropertyName("Url")]
        public string FileUrl { get; set; } = string.Empty;
    }
}
