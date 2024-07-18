using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session13.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    no = table.Column<long>(type: "bigint", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jrndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cost = table.Column<long>(type: "bigint", nullable: false),
                    cap = table.Column<long>(type: "bigint", nullable: false),
                    total = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CID = table.Column<int>(type: "int", nullable: false),
                    FID = table.Column<int>(type: "int", nullable: false),
                    Pass = table.Column<long>(type: "bigint", nullable: false),
                    BookDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookCost = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BID);
                    table.ForeignKey(
                        name: "FK_Booking_Customer_CID",
                        column: x => x.CID,
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Flight_FID",
                        column: x => x.FID,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CID",
                table: "Booking",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FID",
                table: "Booking",
                column: "FID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
