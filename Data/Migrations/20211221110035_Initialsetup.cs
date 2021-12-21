using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurcaseOrder.Data.Migrations
{
    public partial class Initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDraft = table.Column<bool>(type: "bit", nullable: false),
                    CustomerNameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PO_Customer_CustomerNameID",
                        column: x => x.CustomerNameID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRate = table.Column<int>(type: "int", nullable: false),
                    POID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_PO_POID",
                        column: x => x.POID,
                        principalTable: "PO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PO_CustomerNameID",
                table: "PO",
                column: "CustomerNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_POID",
                table: "Products",
                column: "POID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PO");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
