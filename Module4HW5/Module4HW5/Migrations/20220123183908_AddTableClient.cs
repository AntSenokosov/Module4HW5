using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module4HW5.Migrations
{
    public partial class AddTableClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "v.g@gmail.com", "Vlad", "Gricak", "+380663424343" },
                    { 2, "s.n@gmail.com", "Stas", "Nizik", "+380995323373" },
                    { 3, "d.l@gmail.com", "Danil", "Levinskiy", "+380673436442" },
                    { 4, "v.t@gmail.com", "Vova", "Tkachenko", "+380987543234" },
                    { 5, "d.p@gmail.com", "Dmitriy", "Pyatak", "+380992346342" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 500000m, 1, "Project for study", new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1200000m, 2, "Game", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 78000m, 1, "Web application", new DateTime(2021, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 230000m, 4, "Desktop application", new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 10000m, 3, "Database development", new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
