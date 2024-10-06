using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace X_Hackathon.Domain
{
    public class AirwayBill
    {
        public long Id { get; set; }

        [JsonPropertyName("volume")]
        public string Volume { get; set; } = string.Empty;

        [JsonPropertyName("weight")]
        public string Weight { get; set; } = string.Empty;

        [JsonPropertyName("Number of Pieces")]
        public string NumberOfPieces { get; set; } = string.Empty;


        [JsonPropertyName("Origin")]
        public string Origin { get; set; } = string.Empty;


        [JsonPropertyName("Type of Goods")]
        public string TypeOfGoods { get; set; } = string.Empty;

        [JsonPropertyName("The amount")]
        public string Amount { get; set; } = string.Empty;

        [JsonPropertyName("Reference Number")]
        public string ExternalReference { get; set; } = string.Empty;

        [JsonPropertyName("Destination")]
        public string ArrivalLocation { get; set; } = string.Empty;

        [JsonPropertyName("Shipper's name")]
        public string ShippingInfo { get; set; } = string.Empty;

        [JsonPropertyName("Url")]
        public string FileUrl { get; set; } = string.Empty;


        [JsonPropertyName("Risks")]
        public string Risks { get; set; } = string.Empty;


        [JsonPropertyName("Missing Documentation")]
        public string MissingDocumentation { get; set; } = string.Empty;


        [JsonPropertyName("MisDeclaration")]
        public string Misdeclarations { get; set; } = string.Empty;
    }
}
