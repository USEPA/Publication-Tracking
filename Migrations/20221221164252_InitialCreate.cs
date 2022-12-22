using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicationTracking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubOrganization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointOfContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointOfContactOrganization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointOfContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointOfContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointOfContactMailCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: true),
                    PointOfContactOrganizationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedPublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEntered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnteredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");
        }
    }
}
