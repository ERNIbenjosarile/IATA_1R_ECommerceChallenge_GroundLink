using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X_Hackathon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "PackingLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "CommercialInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "PackingLists");

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "CommercialInvoices");
        }
    }
}
