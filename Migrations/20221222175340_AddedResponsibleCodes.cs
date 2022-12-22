using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicationTracking.Migrations
{
    public partial class AddedResponsibleCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubOrganization",
                table: "Publications",
                newName: "ResponsibleCode");

            migrationBuilder.RenameColumn(
                name: "Organization",
                table: "Publications",
                newName: "AlphaDescriptor");

            migrationBuilder.CreateTable(
                name: "ResponsibleCodes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibleCodes", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsibleCodes");

            migrationBuilder.RenameColumn(
                name: "ResponsibleCode",
                table: "Publications",
                newName: "SubOrganization");

            migrationBuilder.RenameColumn(
                name: "AlphaDescriptor",
                table: "Publications",
                newName: "Organization");
        }
    }
}
