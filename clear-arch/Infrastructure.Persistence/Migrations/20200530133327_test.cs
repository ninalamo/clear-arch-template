using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeAddress_City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "HomeAddress_Country",
                table: "People");

            migrationBuilder.DropColumn(
                name: "HomeAddress_State",
                table: "People");

            migrationBuilder.DropColumn(
                name: "HomeAddress_Street",
                table: "People");

            migrationBuilder.DropColumn(
                name: "HomeAddress_ZipCode",
                table: "People");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "Birthday", "CreatedBy", "CreatedOn", "FirstName", "LastName", "MiddleName", "ModifiedBy", "ModifiedOn", "NameSuffix" },
                values: new object[] { new Guid("883ea2a4-ec47-4062-aab6-d713cfa42875"), new DateTimeOffset(new DateTime(1986, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "John", "Doe", null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: new Guid("883ea2a4-ec47-4062-aab6-d713cfa42875"));

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress_City",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress_Country",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress_State",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress_Street",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress_ZipCode",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
