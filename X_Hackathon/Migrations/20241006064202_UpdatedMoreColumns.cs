using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X_Hackathon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMoreColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingInfo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AWBNumber",
                table: "CommercialInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingInfo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AWBNumber",
                table: "CommercialInvoices");
        }
    }
}
