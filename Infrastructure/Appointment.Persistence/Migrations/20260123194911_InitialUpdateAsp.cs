using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdateAsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TCKimlikNo",
                table: "AspNetUsers",
                newName: "DateOfBirth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "AspNetUsers",
                newName: "TCKimlikNo");
        }
    }
}
