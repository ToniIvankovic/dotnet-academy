using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.ToniIvankovic.Data.Db.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Authors", "Genre", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Madeline Miller", 3, 5, "The Song of Achilles" },
                    { 2, "Suzane Collins", 4, 3, "The Hunger Games" },
                    { 3, "Domagoj Kusalić", 1, 1, "Napredno programiranje i algoritmi u C-u i C++-u" },
                    { 4, "Ray Bradburry", 4, 5, "Fahrenheti 451" },
                    { 5, "Andre Aciman", 5, 7, "Call Me By Your Name" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
