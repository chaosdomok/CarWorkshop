using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshop.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarWorkshopAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactDetails_Post",
                table: "CarWorkshops",
                newName: "ContactDetails_PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "CarWorkshops",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "CarWorkshops");

            migrationBuilder.RenameColumn(
                name: "ContactDetails_PostalCode",
                table: "CarWorkshops",
                newName: "ContactDetails_Post");
        }
    }
}
