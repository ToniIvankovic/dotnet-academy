using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.ToniIvankovic.Data.Db.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonBook");

            migrationBuilder.CreateTable(
                name: "RentingInstance",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Date_rented = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentingInstance", x => new { x.Date_rented, x.PersonId, x.BookId });
                    table.ForeignKey(
                        name: "FK_RentingInstance_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentingInstance_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentingInstance_BookId",
                table: "RentingInstance",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RentingInstance_PersonId",
                table: "RentingInstance",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentingInstance");

            migrationBuilder.CreateTable(
                name: "PersonBook",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonBook", x => new { x.BookId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonBook_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonBook_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonBook_PersonId",
                table: "PersonBook",
                column: "PersonId");
        }
    }
}
