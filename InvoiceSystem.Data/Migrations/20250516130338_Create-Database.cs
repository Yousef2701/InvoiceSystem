using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    VatNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CR = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NameInArabic = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.VatNo);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBranch",
                columns: table => new
                {
                    CompanyVatNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranch", x => new { x.CompanyVatNo, x.City });
                    table.ForeignKey(
                        name: "FK_CompanyBranch_Company_CompanyVatNo",
                        column: x => x.CompanyVatNo,
                        principalTable: "Company",
                        principalColumn: "VatNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CompanyVatNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NameInArabic = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    AddressInArabic = table.Column<int>(type: "int", maxLength: 65, nullable: false),
                    AddressInEnglish = table.Column<int>(type: "int", maxLength: 65, nullable: false),
                    CustomerVatNo = table.Column<int>(type: "int", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => new { x.CompanyVatNo, x.Phone });
                    table.ForeignKey(
                        name: "FK_Customer_Company_CompanyVatNo",
                        column: x => x.CompanyVatNo,
                        principalTable: "Company",
                        principalColumn: "VatNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceNo = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyVatNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TaxPercent = table.Column<double>(type: "float", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    TotalInvoicePriceBeforeTax = table.Column<double>(type: "float", nullable: false),
                    TotalInvoicePriceAfterTax = table.Column<double>(type: "float", nullable: false),
                    PaymentWay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyVatNo",
                        column: x => x.CompanyVatNo,
                        principalTable: "Company",
                        principalColumn: "VatNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProduct",
                columns: table => new
                {
                    InvoiceNo = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    PiecePrice = table.Column<double>(type: "float", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProduct", x => new { x.InvoiceNo, x.ProductName });
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_Invoice_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyVatNo",
                table: "Invoice",
                column: "CompanyVatNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyBranch");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "InvoiceProduct");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
