using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace X_Hackathon.Domain
{
    public class Product
    {
        public long Id { get; set; }

        [JsonPropertyName("Shipping Info")]
        public string ShippingInfo { get; set; } = string.Empty;


        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("Reference Number")]
        public string ReferenceNumber { get; set; } = string.Empty;


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


        [JsonPropertyName("Urls")]
        public string FileUrls { get; set; } = string.Empty;


        [JsonPropertyName("Status")]
        public ApprovalStatus Status { get; set; } = ApprovalStatus.ForApproval;

        [JsonPropertyName("Risks")]
        public string Risks { get; set; } = string.Empty;


        [JsonPropertyName("Missing Documentation")]
        public string MissingDocumentation { get; set; } = string.Empty;


        [JsonPropertyName("MisDeclaration")]
        public string Misdeclarations { get; set; } = string.Empty;

    }
}
