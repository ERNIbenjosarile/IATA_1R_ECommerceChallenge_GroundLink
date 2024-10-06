using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X_Hackathon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "AirwayBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberOfPieces",
                table: "AirwayBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "AirwayBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfGoods",
                table: "AirwayBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Volume",
                table: "AirwayBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "AirwayBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AirwayBills");

            migrationBuilder.DropColumn(
                name: "NumberOfPieces",
                table: "AirwayBills");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "AirwayBills");

            migrationBuilder.DropColumn(
                name: "TypeOfGoods",
                table: "AirwayBills");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "AirwayBills");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AirwayBills");
        }
    }
}
