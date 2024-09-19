using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Events.Core.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Organizer = table.Column<string>(type: "varchar(150)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "varchar(100)", nullable: false),
                    Topic = table.Column<string>(type: "varchar(150)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    MeetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    Street = table.Column<string>(type: "varchar(150)", nullable: false),
                    PostCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    MeetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meetups",
                columns: new[] { "Id", "CreatedBy", "Date", "IsPrivate", "Name", "Organizer" },
                values: new object[,]
                {
                    { 1, new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce"), new DateTime(2024, 9, 29, 13, 43, 54, 275, DateTimeKind.Local).AddTicks(5477), true, "Dot Net Users", "Microsoft" },
                    { 2, new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce"), new DateTime(2024, 9, 20, 13, 43, 54, 275, DateTimeKind.Local).AddTicks(5540), true, "SQL Users", "Microsoft" },
                    { 3, new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce"), new DateTime(2024, 10, 11, 13, 43, 54, 275, DateTimeKind.Local).AddTicks(5545), false, "Code Campers", "Code Campers" },
                    { 4, new Guid("0b1b9bc2-4e6d-4096-8295-29e91ce47fce"), new DateTime(2024, 12, 28, 13, 43, 54, 275, DateTimeKind.Local).AddTicks(5548), true, "Wine Lovers", "Napa Valley Wine Growers" }
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "Id", "Author", "Description", "MeetupId", "Topic" },
                values: new object[,]
                {
                    { 1, "James", "Coding with Visual Studio and C#", 1, "C#" },
                    { 2, "Ben C", "Building algorithms with AI and C#", 1, "Algorithms" },
                    { 3, "Peter", "Creating data mats in open source environments", 2, "SSRS with Python" },
                    { 4, "Lisa", "Camping site tips for Florida vacationers", 3, "Camping" },
                    { 5, "Laura", "Guide to Napa Valley wine tours.", 4, "Napa Valley wines" },
                    { 6, "Scott", "What is a good wine? Learn how to test and grade wines.", 4, "Wine fundamentals" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "MeetupId", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Tampa", 1, "33547", "2547 Nature Walk Drive" },
                    { 2, "Orlando", 2, "44547", "1500 International Drive" },
                    { 3, "Atlanta", 3, "75549", "235 Presidents Drive" },
                    { 4, "Clearwater", 4, "33500", "205 Tampa Drive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_MeetupId",
                table: "Lectures",
                column: "MeetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MeetupId",
                table: "Locations",
                column: "MeetupId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Meetups");
        }
    }
}
