using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressInEnglish",
                table: "Customer",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 65);

            migrationBuilder.AlterColumn<string>(
                name: "AddressInArabic",
                table: "Customer",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 65);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AddressInEnglish",
                table: "Customer",
                type: "int",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(65)",
                oldMaxLength: 65);

            migrationBuilder.AlterColumn<int>(
                name: "AddressInArabic",
                table: "Customer",
                type: "int",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(65)",
                oldMaxLength: 65);
        }
    }
}
